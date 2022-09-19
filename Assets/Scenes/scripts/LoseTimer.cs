using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseTimer : MonoBehaviour
{
    [SerializeField] float TimeToWait = 120f;

    public GameObject LevelMenu;
    public GameObject WLMenu;
    public GameObject Lose;

    void Start()
    {
        
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad > TimeToWait)
        {
            LevelMenu.gameObject.SetActive(false);
            WLMenu.gameObject.SetActive(true);
            Lose.gameObject.SetActive(true);
            GetComponent<SC_FPSController>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
