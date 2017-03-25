using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{

    bool isMusicOn = true;
    bool isSoundOn = true;

    public AudioSource titleMusicSource;
    public AudioSource gameMusicSource;
    public AudioSource soundSource;

    public static SoundManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void PlayMusic()
    {
        StopMusic();
        if (isMusicOn == false)
        {
            return;
        }

        int sceneNum = SceneManager.GetActiveScene().buildIndex;

        if (sceneNum == 0)
        {
            if (titleMusicSource.isPlaying == false)
            {
                titleMusicSource.Play();
            }
        }
        else
        {
            if (gameMusicSource.isPlaying == false)
            {
                gameMusicSource.Play();
            }
        }
    }

    public void StopMusic()
    {
        titleMusicSource.Stop();
        gameMusicSource.Stop();
    }

    public void ChangeMusicState()
    {
        isMusicOn = !isMusicOn;

        PlayMusic();
    }

    public void ChangeSoundState()
    {
        isSoundOn = !isSoundOn;


    }
}
