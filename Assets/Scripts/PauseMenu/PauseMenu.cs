using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public AudioMixer mixer_;
    public TMP_Text master_;
    public Slider masterSlid_;
    public string scene;

    // Start is called before the first frame update
    void Start()
    {
        float vol = 0f;
        mixer_.GetFloat("MasterVol_", out vol);
        masterSlid_.value = vol;

        master_.text = Mathf.RoundToInt(masterSlid_.value + 80).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void SetMasterVol()
    {
        master_.text = Mathf.RoundToInt(masterSlid_.value + 80).ToString();
        mixer_.SetFloat("Mixer_", masterSlid_.value);
        PlayerPrefs.SetFloat("Mixer_", masterSlid_.value);
    }

    public void AmonosAlMenu()
    {
        SceneManager.LoadScene(scene);
    }

}
