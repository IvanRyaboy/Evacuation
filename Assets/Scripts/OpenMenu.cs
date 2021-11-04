using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenMenu : MonoBehaviour
{
    public bool IsEscPress = false;
    AudioSource audioSource;
    [SerializeField] float TimeToWait = 60f;

    public GameObject LevelMenu;
    public GameObject LoseMenu;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space))
       {
           if (IsEscPress == false)
           {
               IsEscPress = true;
               LevelMenu.gameObject.SetActive(true);
               GetComponent<SC_FPSController>().enabled = false;
               Cursor.lockState = CursorLockMode.None;
               Cursor.visible = true;
               audioSource.Pause();
           }
           else
           {
               IsEscPress = false;
               LevelMenu.gameObject.SetActive(false);
               GetComponent<SC_FPSController>().enabled = true;
               Cursor.lockState = CursorLockMode.Locked;
               Cursor.visible = false;
               audioSource.Play();
           }
       }
        if (Time.timeSinceLevelLoad > TimeToWait)
        {
            LevelMenu.gameObject.SetActive(false);
            LoseMenu.gameObject.SetActive(true);
            GetComponent<SC_FPSController>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    public void ContinuePlay()
    {
        IsEscPress = false;
        LevelMenu.gameObject.SetActive(false);
        GetComponent<SC_FPSController>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
        LoseMenu.gameObject.SetActive(false);
    }
}
