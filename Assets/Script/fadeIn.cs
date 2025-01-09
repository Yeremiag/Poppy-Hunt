using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeIn : MonoBehaviour
{

    public AudioSource music;
    public CanvasGroup panel;
    float loudness = 0;

    void Start()
    {
        music.volume = 0f;
    }

    void Update()
    {
        if (loudness < 1)
        {
            music.volume = loudness;
            panel.alpha = 1.0f - loudness;
            loudness = loudness + 0.4f * Time.deltaTime;
        }
    }
}
