using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUIManager : MonoBehaviour {

    public GameObject settingPanel;

    bool isSettingOn = false;

    void Start()
    {
        SoundManager.instance.PlayMusic();
        settingPanel.SetActive(false);
    }

	public void StartGameButton()
    {
        SceneManager.LoadScene("main");
    }

    public void SettingToggleButton()
    {
        isSettingOn = !isSettingOn;

        if(isSettingOn)
        {
            settingPanel.SetActive(true);
        }
        else
        {
            settingPanel.SetActive(false);
        }
    }

    public void MusicToggleButton()
    {
        SoundManager.instance.ChangeMusicState();
    }

    public void SoundToggleButton()
    {
        SoundManager.instance.ChangeSoundState();
    }
}
