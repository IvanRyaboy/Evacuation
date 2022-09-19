using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class TestScript : MonoBehaviour
{

    public QuestionList[] questions;
    public Text[] answersText;
    public Text qText;
    public GameObject headPanel;
    public Button[] answerBttns = new Button[3];
    public Text LooseText;
    public GameObject LooseImage;


    private int AnswerCount = 0;

    List<object> qList;
    QuestionList crntQ;
    int randQ;
    bool defaultColor = false, trueColor = false, falseColor = false;

    void Awake()
    {
    }

    public void OnClickPlay()
    {
        qList = new List<object>(questions);
        GameObject.Find("Text").SetActive(false);
        GameObject.Find("Start").SetActive(false);
        GameObject.Find("Exit").SetActive(false);
        for (int i = 0; i < answerBttns.Length; i++) answerBttns[i].enabled = true;;
        questionGenerate();
    }
    void questionGenerate()
    {
        if (qList.Count > 0)
        {
            randQ = Random.Range(0, qList.Count);
            crntQ = qList[randQ] as QuestionList;
            qText.text = crntQ.question;
            List<string> answers = new List<string>(crntQ.answers);
            for (int i = 0; i < crntQ.answers.Length; i++)
            {
                int rand = Random.Range(0, answers.Count);
                answersText[i].text = answers[rand];
                answers.RemoveAt(rand);
                AnswerCount += 1;
            }
            StartCoroutine(animBttns());
        }
        else
        {
            GameObject.Find("WinImage").SetActive(true);
            GameObject.Find("Exit").SetActive(true);
        }
    }

    public void ExitButton()
    {
        SceneManager.LoadScene(0);
    } 

    IEnumerator animBttns()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < answerBttns.Length; i++) answerBttns[i].interactable = false;
        int a = 0;
        while (a < answerBttns.Length)
        {
            if (!answerBttns[a].gameObject.activeSelf) answerBttns[a].gameObject.SetActive(true);
            a++;
            yield return new WaitForSeconds(1);
        }
        for (int i = 0; i < answerBttns.Length; i++) answerBttns[i].interactable = true;
        yield break;
    }
    IEnumerator trueOrFalse(bool check)
    {
        defaultColor = false;
        for (int i = 0; i < answerBttns.Length; i++) answerBttns[i].interactable = false;
        yield return new WaitForSeconds(1);
        yield return new WaitForSeconds(0.5f);
        if (check)
        {
            trueColor = true;
            yield return new WaitForSeconds(1);
            qList.RemoveAt(randQ);
            questionGenerate();
            trueColor = false;
            defaultColor = true;
            yield break;
        }
        else
        {
            falseColor = true;
            yield return new WaitForSeconds(1);
            falseColor = false;
            defaultColor = true;
            LooseImage.gameObject.SetActive(true);
            LooseText.text = "Неудача. Вы не прошли тест. Ваш счёт " + AnswerCount + " очков";
            yield break;
        }
    }
    public void AnswerBttns(int index)
    {
        if (answersText[index].text.ToString() == crntQ.answers[0]) StartCoroutine(trueOrFalse(true));
        else StartCoroutine(trueOrFalse(false));
    }
}
[System.Serializable]
public class QuestionList
{
    public string question;
    public string[] answers = new string[3];
}