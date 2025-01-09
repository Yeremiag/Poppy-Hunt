using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonController : MonoBehaviour
{

    public AudioSource music;
    public CanvasGroup panel;
    float loudness = 1;
    bool flag = false;

    public void playGame()
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
            SceneManager.LoadSceneAsync(1);
        }
    }

    public void stopGame()
    {
        Application.Quit();

    }

}
