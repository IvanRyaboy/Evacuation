using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitDoor : MonoBehaviour
{
    public int numDoor;
    public Text TimeText;
    public Text Result;
    public Text Mark;
    public GameObject E;
    bool IsTrigger = false;
    public GameObject ExitMenu;
    public GameObject WinMenu;
    public GameObject Pers;
    float me = 0f;
    int minuties;
    int mark = 4;
    float seconds;
    string CursorsText = "Вы выжили";
    string ResultTxt = "Не верная дверь";
    void OnTriggerEnter()
    {
        if (Pers.GetComponent<OpenMenu>().CanExit)
        {
            E.gameObject.SetActive(true);
            
        }
        IsTrigger = true;
    }

    void OnTriggerExit()
    {
        IsTrigger = false;
        E.gameObject.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        if ((IsTrigger == true) && (Input.GetKeyDown(KeyCode.E)) && Pers.GetComponent<OpenMenu>().CanExit)
        {
            Debug.Log("Выбрался!");
            Pers.GetComponent<AudioSource>().Stop();
            Pers.GetComponent<OpenMenu>().enabled = false;
            ExitMenu.gameObject.SetActive(true);
            WinMenu.gameObject.SetActive(true);
            E.gameObject.SetActive(false);
            Pers.GetComponent<SC_FPSController>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            me = Time.timeSinceLevelLoad;
            minuties = (int)me / 60;
            seconds = me % 60f;

            if (seconds <= 30)
            {
                mark += 3;
            }
            else
            {
                if (minuties <= 1)
                {
                    mark += 2;
                }
                else
                {
                    mark += 1;
                }
            }

            TimeText.text = minuties.ToString() + ":" + seconds.ToString("0") + " c";

            int numSpawn = Pers.GetComponent<Spawn>().RandomSpawn1;
            Debug.Log(numSpawn);
            switch (numDoor)
        {
            case 0 : if ((numSpawn>=0)&&(numSpawn<=21) || (numSpawn == 20) || (numSpawn == 21) || ((numSpawn >= 25) && (numSpawn <= 29)))
                    {
                        ResultTxt = "Оптимальный";
                        mark += 3;
                    }
                    else
                    {
                        ResultTxt = "Не оптимальный";
                    } break;
            case 1 : if ((numSpawn == 20) || (numSpawn == 21) || ((numSpawn >= 25) && (numSpawn <= 29)))
                    {
                        ResultTxt = "Оптимальный";
                        mark += 3;
                    }
                    else
                    {
                        ResultTxt = "Не оптимальный";
                    } break;
            case 2 : if (((numSpawn >= 22) && (numSpawn <= 24)) || ((numSpawn >= 30) && (numSpawn <= 34)) || (numSpawn == 37))
                    {
                        ResultTxt = "Оптимальный";
                        mark += 3;
                    }
                    else
                    {
                        ResultTxt = "Не оптимальный";
                    } break;
            case 3: if ((numSpawn == 33) || (numSpawn == 34) || (numSpawn == 37))
                    {
                        ResultTxt = "Оптимальный";
                        mark += 3;
                    }
                    else
                    {
                        ResultTxt = "Не оптимальный";
                    } break;
            case 4: if ((numSpawn >= 35) && (numSpawn <= 37))
                    {
                        ResultTxt = "Оптимальный";
                        mark += 3;
                    }
                    else
                    {
                        ResultTxt = "Не оптимальный";
                    } break;
            case 5: if ((numSpawn >= 0) && (numSpawn <= 19))
                    {
                        ResultTxt = "Оптимальный";
                        mark += 3;
                    }
                    else
                    {
                        ResultTxt = "Не оптимальный";
                    }
                    break;
            }
        Result.text = ResultTxt;
        Mark.text = mark.ToString();
        GetComponent<ExitDoor>().enabled = false;
        }
    }
}
