using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour {

    public Tutorialsound tts;

    public Player player;
    public GameObject pausePanel;
    public GameObject normalPanel;
        

    public GameObject XBT;

    public GameObject Option;
    public GameObject SoundOn;
    public GameObject SoundOff;
    public GameObject Exit;

    public GameObject GameEnd;
    public GameObject Yes;
    public GameObject No;


     
    public void PauseClick()
    {
        Time.timeScale = 0;
        normalPanel.SetActive(false);
        pausePanel.SetActive(true);
    }
    public void XBTClick()
    {
        Time.timeScale = 1f;
        normalPanel.SetActive(true);
        pausePanel.SetActive(false);
    }
    public void SoundOnClick()
    {
        SoundOff.SetActive(true);
        SoundOn.SetActive(false);
        tts.stage1.setPaused(true);

    }
    public void SoundOffClick()
    {
        SoundOff.SetActive(false);
        SoundOn.SetActive(true);
        tts.stage1.setPaused(false);

    }
    public void ExitBTClick()
    {
        Option.SetActive(false);
        GameEnd.SetActive(true);
    }

    public void YesBT()
    {
        pausePanel.SetActive(false);
        normalPanel.SetActive(true);

        Application.Quit();        
    }
    public void NoBT()
    {
        GameEnd.SetActive(false);
        Option.SetActive(true);
    }
    // Use this for initialization

}
