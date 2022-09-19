using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class TextUsingFile : MonoBehaviour
{
    public TextReader quotes;
    Text text;
    public string textFromFile;

    void Awake()
    {
        text = GetComponent<Text>();
    }

    void Start()
    {
        Debug.Log(ReadFromFile());
    }

    public string ReadFromFile()
    {
        StreamReader reader = new StreamReader("D:/extinguisher.txt");
        string s = reader.ReadToEnd();
        Debug.Log("Hello");

        while (s != null)
        {
            System.Random rnd1 = new System.Random();

            s = reader.ReadToEnd();
            textFromFile = s;
        }
        return textFromFile;
    }
}

//if (triggerobj == extinguisher)
//{
//    LoadTextFromFile(������������)
//}
//else if (triggerobj == fire_hydrant)
//{
//LoadTextFromFile(�������)
//}
//else if (triggerobj == evacuation_way)
//{
//LoadTextFromFile(����)
//}
//else if (triggerobj == evacuation_pointer)
//{
//LoadTextFromFile(���������)
//}

//Function to load text data from external file
