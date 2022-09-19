using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tushit : MonoBehaviour
{
    bool istushit = false;
    bool down = false;
    
    public ParticleSystem PS;
    public ParticleSystem PS1;
    public GameObject ExitMenu;
    public GameObject WinMenu;
    public GameObject Pers;
    public Text TimeText;
    public Text Mark;
    float me = 0f;
    int minuties;
    int mark = 4;
    float seconds;
    public ParticleSystem PS3;
    public AudioSource audioSource;
    public AudioSource audioSource1;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "fire")
        {
            istushit = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "fire")
        {
            istushit = false;
        }
    }

    void win()
    {
        Pers.GetComponent<OpenMenu>().enabled = false;
        audioSource.Stop();
        audioSource1.Stop();
        ExitMenu.gameObject.SetActive(true);
        WinMenu.gameObject.SetActive(true);
        PS3.Stop();
        Pers.GetComponent<SC_FPSController>().enabled = false;
        Pers.GetComponent<antifire>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        me = Time.timeSinceLevelLoad;
        minuties = (int)me / 60;
        seconds = me % 60f;
        TimeText.text = minuties.ToString() + ":" + seconds.ToString("0") + " c";

        if (seconds <= 30)
        {
            mark += 6;
        }
        else
        {
            if (minuties <= 1)
            {
                mark += 4;
            }
            else
            {
                mark += 2;
            }
        }
        Mark.text = mark.ToString();
        GetComponent<tushit>().enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            down = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            down = false;
        }

        if (istushit && down)
        {
            PS.transform.localScale = PS.transform.localScale - new Vector3(0.1f, 0.1f, 0.1f) * Time.deltaTime ;
            PS.startSize -= 0.1f * Time.deltaTime;
            if (PS.startSize <= 0)
            {
                PS.tag = "no_fire";
                PS.Stop();
                PS1.Stop();
                win();
                Debug.Log("Потушил!");
            }
        }
    }
}
