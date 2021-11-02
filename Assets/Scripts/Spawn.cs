using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject pers;

    // Start is called before the first frame update
    void Start()
    {
        int RandomSpawn = Random.Range(0,2);
        Debug.Log(RandomSpawn);
        switch (RandomSpawn)
        {
            case 0 : pers.transform.position = new Vector3(-38.83057f, -6.92f, 5.641527f); break;
            case 1 : pers.transform.position = new Vector3(-94.07967f, -6.92f, -23.69388f); break;
            default : pers.transform.position = new Vector3(14.50208f, -0.1134033f, -14.46278f); break;
        }   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
