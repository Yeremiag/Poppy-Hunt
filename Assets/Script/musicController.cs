using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicControler : MonoBehaviour
{

    public AudioSource music;

    void Start()
    {
        music.Play();
        music.volume = 100;

    }

    void Update()
    {
    }
}
