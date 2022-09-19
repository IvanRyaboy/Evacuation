using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject pers;
    public GameObject smoke;
    public int RandomSpawn1;
    public int RandomSpawn2;

    // Start is called before the first frame update
    public void Start()
    {
        FuncSpawn();
    }

    public void FuncSpawn()
    {
        RandomSpawn1 = Random.Range(0, 38);
        Debug.Log(RandomSpawn1);
        switch (RandomSpawn1)
        {
            case 0: pers.transform.position = new Vector3(-76f, 10f, -9f); break; //left 3 floor
            case 1: pers.transform.position = new Vector3(-50f, 10f, -9f); break;
            case 2: pers.transform.position = new Vector3(-30f, 10f, -9f); break;
            case 3: pers.transform.position = new Vector3(-5f, 10f, -9f); break;
            case 4: pers.transform.position = new Vector3(-17f, 10f, -22f); break;
            case 5: pers.transform.position = new Vector3(-40f, 10f, -22f); break;
            case 6: pers.transform.position = new Vector3(-67f, 10f, -22f); break;
            case 7: pers.transform.position = new Vector3(-76f, 6f, -22f); break; //left 2 floor
            case 8: pers.transform.position = new Vector3(-45f, 6f, -22f); break;
            case 9: pers.transform.position = new Vector3(-30f, 6f, -22f); break;
            case 10: pers.transform.position = new Vector3(-4f, 6f, -9f); break;
            case 11: pers.transform.position = new Vector3(-27f, 6f, -9f); break;
            case 12: pers.transform.position = new Vector3(-49f, 6f, -9f); break;
            case 13: pers.transform.position = new Vector3(-74f, 6f, -9f); break;
            case 14: pers.transform.position = new Vector3(-100f, 6f, -15f); break;
            case 15: pers.transform.position = new Vector3(-75f, 2f, -9f); break; //left 1 floor
            case 16: pers.transform.position = new Vector3(-50f, 2f, -9f); break;
            case 17: pers.transform.position = new Vector3(-28f, 2f, -9f); break;
            case 18: pers.transform.position = new Vector3(-32f, 2f, -22f); break;
            case 19: pers.transform.position = new Vector3(-60f, 2f, -22f); break;
            case 20: pers.transform.position = new Vector3(-140f, 1f, -14f); break; //right 1 floor
            case 21: pers.transform.position = new Vector3(-135f, 1f, -26f); break;
            case 22: pers.transform.position = new Vector3(-140f, 1f, -83f); break;//2
            case 23: pers.transform.position = new Vector3(-140f, 6f, -83f); break; //right 2 floor
            case 24: pers.transform.position = new Vector3(-135f, 6f, -62f); break;
            case 25: pers.transform.position = new Vector3(-135f, 6f, -43f); break;
            case 26: pers.transform.position = new Vector3(-140f, 6f, -12f); break;
            case 27: pers.transform.position = new Vector3(-140f, 10f, -14f); break; //right 3 floor
            case 28: pers.transform.position = new Vector3(-144f, 10f, -34f); break;
            case 29: pers.transform.position = new Vector3(-134f, 10f, -25f); break;
            case 30: pers.transform.position = new Vector3(-134f, 10f, -53f); break;
            case 31: pers.transform.position = new Vector3(-134f, 10f, -68f); break;
            case 32: pers.transform.position = new Vector3(-140f, 10f, -82f); break;
            case 33: pers.transform.position = new Vector3(-108f, 1f, -100f); break; //master 1 floor
            case 34: pers.transform.position = new Vector3(-90f, 1f, -118f); break; //1
            case 35: pers.transform.position = new Vector3(-70f, 1f, -120f); break; //2
            case 36: pers.transform.position = new Vector3(-63f, 1f, -144f); break;
            case 37: pers.transform.position = new Vector3(-100f, 5f, -100f); break; ////master 2 floor
        }
        RandomSpawn2 = Random.Range(0, 5);
        switch (RandomSpawn2)
        {
            case 0: smoke.transform.position = new Vector3(-55.25f, 8f, -19f); break;
            case 1: smoke.transform.position = new Vector3(-53.75f, 4.25f, -19f); break;
            case 2: smoke.transform.position = new Vector3(-68f, 0f, -13f); break;
            case 3: smoke.transform.position = new Vector3(-149.25f, 0f, -20.25f); break;
            default: smoke.transform.position = new Vector3(-149.25f, 4.25f, -73f); break;
        }
        Debug.Log(RandomSpawn1);
    }
}
