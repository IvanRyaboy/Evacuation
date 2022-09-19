using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenMenu : MonoBehaviour
{
    public bool IsEscPress = false;
    public bool CanExit = false;
    public int RandomSpawn1;
    AudioSource audioSource;
    public AudioSource audioSource1;

    public GameObject LevelMenu;
    public GameObject WLMenu;
    public GameObject Win;
    public GameObject Lose;
    public GameObject Type;
    public GameObject smoke;
    public GameObject fire;
    public GameObject FE;
    public GameObject FPSController;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Type.gameObject.SetActive(true);
        GetComponent<SC_FPSController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        audioSource.Pause();
    }
    
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Escape))
       {
           if (IsEscPress == false)
           {
               IsEscPress = true;
               LevelMenu.gameObject.SetActive(true);
               GetComponent<SC_FPSController>().enabled = false;
               Cursor.lockState = CursorLockMode.None;
               Cursor.visible = true;
               if (CanExit)
               {
                   audioSource.Pause();
               }
                
           }
           else
           {
               IsEscPress = false;
               LevelMenu.gameObject.SetActive(false);
               GetComponent<SC_FPSController>().enabled = true;
               Cursor.lockState = CursorLockMode.Locked;
               Cursor.visible = false;
               if (CanExit)
               {
                   audioSource.Play();
               }
           }
       }
    }
    public void ContinuePlay()
    {
        IsEscPress = false;
        LevelMenu.gameObject.SetActive(false);
        GetComponent<SC_FPSController>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (CanExit)
        {
            audioSource.Play();
        }
    }

    public void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex - 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
    
    public void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        WLMenu.gameObject.SetActive(false);
        Win.gameObject.SetActive(false);
        Lose.gameObject.SetActive(false);
        //audioSource.Stop();
    }

    public void Type1()
    {
        GetComponent<Spawn>().FuncSpawn();
        Type.gameObject.SetActive(false);
        fire.gameObject.SetActive(false);
        FE.gameObject.SetActive(false);
        GetComponent<antifire>().enabled = false;
        GetComponent<SC_FPSController>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        CanExit = true;
        audioSource.Play();
    }

    public void Type2()
    {
        GetComponent<Spawn>().FuncSpawn();
        GetComponent<antifire>().enabled = false;
        Type.gameObject.SetActive(false);
        smoke.gameObject.SetActive(false);
        fire.gameObject.SetActive(false);
        FE.gameObject.SetActive(false);
        GetComponent<SC_FPSController>().enabled = true;
        GetComponent <LoseTimer>().enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        CanExit = false;
        audioSource.Stop();
    }

    public void Type3()
    {
        RandomSpawn1 = Random.Range(0,38);
        Debug.Log(RandomSpawn1);
        switch (RandomSpawn1)
        {
            case 0: FPSController.transform.position = new Vector3(-76f, 10f, -9f); fire.transform.position = new Vector3(-78.28f, 8.539f, -11.502f);  break; //left 3 floor
            case 1: FPSController.transform.position = new Vector3(-50f, 10f, -9f); fire.transform.position = new Vector3(-55.13f, 8.539f, -1.472f); break;
            case 2: FPSController.transform.position = new Vector3(-30f, 10f, -9f); fire.transform.position = new Vector3(-26.22f, 8.539f, -11.393f); break;
            case 3: FPSController.transform.position = new Vector3(-5f, 10f, -9f); fire.transform.position = new Vector3(-19.03f, 8.539f, -11.393f); break;//306
            case 4: FPSController.transform.position = new Vector3(-17f, 10f, -22f); fire.transform.position = new Vector3(-21.53f, 8.539f, -20.06f); break;
            case 5: FPSController.transform.position = new Vector3(-40f, 10f, -22f); fire.transform.position = new Vector3(-45.017f, 8.539f, -28.85f); break;
            case 6: FPSController.transform.position = new Vector3(-67f, 10f, -22f); fire.transform.position = new Vector3(-58.687f, 8.539f, -25.069f); break;
            case 7: FPSController.transform.position = new Vector3(-76f, 6f, -22f); fire.transform.position = new Vector3(-58.45f, 4.875f, -27.36f); break; //left 2 floor
            case 8: FPSController.transform.position = new Vector3(-45f, 6f, -22f); fire.transform.position = new Vector3(-39.89f, 4.875f, -19.936f); break;
            case 9: FPSController.transform.position = new Vector3(-30f, 6f, -22f); fire.transform.position = new Vector3(-30.38f, 4.875f, -29.15f); break;
            case 10: FPSController.transform.position = new Vector3(-4f, 6f, -9f); fire.transform.position = new Vector3(-0.52f, 4.64f, -3.73f); break;
            case 11: FPSController.transform.position = new Vector3(-27f, 6f, -9f); fire.transform.position = new Vector3(-44.05f, 4.875f, -1.67f); break;
            case 12: FPSController.transform.position = new Vector3(-49f, 6f, -9f); fire.transform.position = new Vector3(-64.43f, 4.875f, -3.571f); break;
            case 13: FPSController.transform.position = new Vector3(-74f, 6f, -9f); fire.transform.position = new Vector3(-89.17f, 4.875f, -2.9f); break;
            case 14: FPSController.transform.position = new Vector3(-100f, 6f, -15f); fire.transform.position = new Vector3(-100.203f, 4.875f, -18.877f); break;
            case 15: FPSController.transform.position = new Vector3(-75f, 2f, -9f); fire.transform.position = new Vector3(-88.83f, 1f, -3.118f); break; //left 1 floor
            case 16: FPSController.transform.position = new Vector3(-50f, 2f, -9f); fire.transform.position = new Vector3(-64.423f, 1f, -1.35f); break;
            case 17: FPSController.transform.position = new Vector3(-28f, 2f, -9f); fire.transform.position = new Vector3(-26.17f, 1f, -1.35f); break;
            case 18: FPSController.transform.position = new Vector3(-32f, 2f, -22f); fire.transform.position = new Vector3(-34.052f, 1f, -26.96f); break;
            case 19: FPSController.transform.position = new Vector3(-60f, 2f, -22f); fire.transform.position = new Vector3(-62.886f, 1f, -26.96f); break;
            case 20: FPSController.transform.position = new Vector3(-140f, 1f, -14f); fire.transform.position = new Vector3(-141.94f, 0f, -8.097f); break; //right 1 floor
            case 21: FPSController.transform.position = new Vector3(-135f, 1f, -26f); fire.transform.position = new Vector3(-126.55f, 0f, -23.65f); break;
            case 22: FPSController.transform.position = new Vector3(-140f, 1f, -83f); fire.transform.position = new Vector3(-138.34f, 0f, -88.74f); break;//2
            case 23: FPSController.transform.position = new Vector3(-140f, 6f, -83f); fire.transform.position = new Vector3(-141.893f, 4.763f, -86.215f); break; //right 2 floor
            case 24: FPSController.transform.position = new Vector3(-135f, 6f, -62f); fire.transform.position = new Vector3(-129.896f, 4.691f, -62f); break;
            case 25: FPSController.transform.position = new Vector3(-135f, 6f, -43f); fire.transform.position = new Vector3(-128.244f, 4.691f, -50.3f); break;
            case 26: FPSController.transform.position = new Vector3(-140f, 6f, -12f); fire.transform.position = new Vector3(-127.45f, 4.691f, -12f); break;
            case 27: FPSController.transform.position = new Vector3(-140f, 10f, -14f); fire.transform.position = new Vector3(-141.65f, 8.91f, -7.081f); break; //right 3 floor
            case 28: FPSController.transform.position = new Vector3(-144f, 10f, -34f); fire.transform.position = new Vector3(-141.72f, 8.91f, -41.79f); break;
            case 29: FPSController.transform.position = new Vector3(-134f, 10f, -25f); fire.transform.position = new Vector3(-129.5f, 8.91f, -38.01f); break;
            case 30: FPSController.transform.position = new Vector3(-134f, 10f, -53f); fire.transform.position = new Vector3(-129.5f, 8.91f, -53.767f); break;
            case 31: FPSController.transform.position = new Vector3(-134f, 10f, -68f); fire.transform.position = new Vector3(-128.039f, 8.91f, -68.38f); break;
            case 32: FPSController.transform.position = new Vector3(-140f, 10f, -82f); fire.transform.position = new Vector3(-140f, 8.91f, -87.114f); break;
            case 33: FPSController.transform.position = new Vector3(-108f, 1f, -100f); fire.transform.position = new Vector3(-108.973f, 0f, -95.182f); break; //master 1 floor
            case 34: FPSController.transform.position = new Vector3(-90f, 1f, -118f); fire.transform.position = new Vector3(-91.73f, 0f, -112.7f); break; //1
            case 35: FPSController.transform.position = new Vector3(-70f, 1f, -120f); fire.transform.position = new Vector3(-73.464f, 0f, -118.294f); break; //2
            case 36: FPSController.transform.position = new Vector3(-63f, 1f, -144f); fire.transform.position = new Vector3(-59.569f, 0f, -144.169f); break;
            case 37: FPSController.transform.position = new Vector3(-100f, 5f, -100f); fire.transform.position = new Vector3(-113.548f, 4.2f, -98.601f); break; ////master 2 floor
        }
        Type.gameObject.SetActive(false);
        smoke.gameObject.SetActive(false);
        fire.gameObject.SetActive(true);
        FE.gameObject.SetActive(true);
        GetComponent<SC_FPSController>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        CanExit = false;
        audioSource.Stop();
        audioSource1.Play();
    }
}
