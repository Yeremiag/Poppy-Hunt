using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonControllerInGame : MonoBehaviour
{
    public AudioSource music;
    public CanvasGroup panel;
    public Transform orientation;
    public GameObject win;
    float loudness = 1;
    public dogSpawner dogSpawnerClass;
    bool flag = false;
    bool youWinOff = true;

    public void goHome()
    {
        flag = true;
    }

    void Update()
    {
        if (loudness > 0 && flag)
        {
            music.volume = loudness;
            panel.alpha = 1.0f - loudness;
            loudness = loudness - 0.4f * Time.deltaTime;
        }
        else if (flag)
        {
            SceneManager.LoadSceneAsync(0);
        }
        if(dogSpawnerClass.dogsAmount == 0 && youWinOff)
        {
            youWin();
            youWinOff = false;
        }
    }

    public void stopGame()
    {
        Application.Quit();
    }

    public void resetPosition()
    {
        orientation.transform.position = new Vector3(0f, 2.03f, 0f);
        Physics.SyncTransforms();
    }

    public void gameStop()
    {
        Application.Quit();
    }

    public void youWin()
    {
        win.SetActive(true);   
    }
}
