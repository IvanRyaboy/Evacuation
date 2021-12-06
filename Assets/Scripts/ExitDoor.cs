using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitDoor : MonoBehaviour
{
    public int numDoor;
    public Text ScoreText;
    public Text Result;
    bool IsTrigger = false;
    public GameObject ExitMenu;
    public GameObject Pers;
    float TimeAfterStart = 0f;
    string CursorsText = "Вы выжили";
    string ResultTxt = "Не верная дверь";
    void OnTriggerEnter()
    {
        IsTrigger = true;
    }

    void OnTriggerExit()
    {
        IsTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((IsTrigger == true) && (Input.GetKeyDown(KeyCode.E)))
        {
            Pers.GetComponent<AudioSource>().Stop();
            Pers.GetComponent<OpenMenu>().enabled = false;
            Debug.Log("Триггер работает");
            ExitMenu.gameObject.SetActive(true);
            Pers.GetComponent<SC_FPSController>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if (Time.timeSinceLevelLoad < 20f)
            {
                CursorsText = "Вы выбрались без последствий";
            }
            else
            {
                if ((Time.timeSinceLevelLoad >= 20f) && (Time.timeSinceLevelLoad <= 40f))
                {
                    CursorsText = "Вы получили небольшое отравление угарным газом";
                }
                else
                {
                    CursorsText = "Вы получили серьёзное отравление угарным газом и ожоги";
                }
            }
            ScoreText.text = CursorsText;

            int numSpawn = Pers.GetComponent<Spawn>().RandomSpawn;
            Debug.Log(numSpawn);
            switch (numSpawn)
        {
            case 0 : if ((numDoor == 0) || (numDoor == 1))
                    {
                        ResultTxt = "Вы выбрали правильную дверь";
                    }
                    else
                    {
                        ResultTxt = "Вы выбрали неправильную дверь.\n Обратите внимание на план эвакуации";
                    } break;
            case 2 : if ((numDoor == 0) || (numDoor == 1))
                    {
                        ResultTxt = "Вы выбрали правильную дверь";
                    }
                    else
                    {
                        ResultTxt = "Вы выбрали неправильную дверь.\n Обратите внимание на план эвакуации";
                    } break;
            case 1 : if ((numDoor == 2))
                    {
                        ResultTxt = "Вы выбрали правильную дверь";
                    }
                    else
                    {
                        ResultTxt = "Вы выбрали неправильную дверь.\n Обратите внимание на план эвакуации";
                    } break;
        }
        Result.text = ResultTxt;
        }
    }
}
