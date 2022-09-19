using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public GameObject LoadingLevel;
    public GameObject txt1;
    public GameObject txt2;

    public void NextLevel()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex + 1;
            if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            {
                nextSceneIndex = 0;
            }
            SceneManager.LoadScene(nextSceneIndex);
        }
    
    public void CloseGame()
    {
        Application.Quit();    // закрыть приложение
    }

    public void Load()
    {
        LoadingLevel.SetActive(true);
        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        AsyncOperation asyncload = SceneManager.LoadSceneAsync(1);

        asyncload.allowSceneActivation = false;

        while (!asyncload.isDone)
        {
            if(asyncload.progress >= 0.9f && !asyncload.allowSceneActivation)
            {
                txt1.gameObject.SetActive(false);
                txt2.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    asyncload.allowSceneActivation = true;
                }
            }

            yield return null;
        }
    }

    public void OpenTest()
    {
        SceneManager.LoadScene(2);
    }
}
