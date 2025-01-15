using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public AudioSource music;
    private float wait;

    void Start()
    {
        wait = 400;
        music.volume = 0;
    }
    void FixedUpdate()
    {
        if (Time.time > 0)
        {
            if (!music.isPlaying)
            {
                if (wait == -1)
                    wait = Time.time;
                music.volume = 0;
                if (wait > Time.time + 8)
                    music.Play();
            }
            else
            {
                wait = -1;
                if (music.time > 73)
                {
                    music.volume -= 0.001f;
                } else
                {
                    music.volume += 0.001f;
                }
            }
        }
    }
}
