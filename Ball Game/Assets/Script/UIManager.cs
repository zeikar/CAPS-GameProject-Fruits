using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject[] hearts;

    public Text scoreText;

    bool isPaused = false;


    public static UIManager instance = null;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        SoundManager.instance.PlayMusic();
        pausePanel.SetActive(false);
        ScoreUpdate();
        HeartUpdate();
    }

    public void ScoreUpdate()
    {
        scoreText.text = "Score : " + Fruits.instance.score;
    }

    public void HeartUpdate()
    {
        for(int i = 0; i < Fruits.instance.freshness; ++i)
        {
            hearts[i].SetActive(true);
        }
        for(int i = Fruits.instance.freshness; i < hearts.Length; ++i)
        {
            hearts[i].SetActive(false);
        }
    }


    public void PauseToggle()
    {
        if(isPaused)
        {
            Time.timeScale = 1.0f;
            pausePanel.SetActive(false);
        }
        else
        {
            Time.timeScale = 0.0f;
            pausePanel.SetActive(true);
        }

        isPaused = !isPaused;
    }

    public void RestartGameButton()
    {
        PauseToggle();

        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void ReturnToTitle()
    {
        PauseToggle();
        SoundManager.instance.StopMusic();

        SceneManager.LoadScene("title");
    }
}
