using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{

    public Toggle fullScreenTog;
    public List<ResItem> resolutions = new List<ResItem>();
    public int selectedResolution;
    public TMP_Text resolutionLabel;

    public AudioMixer mixer;

    public TMP_Text master, music, sfx;
    public Slider masterSlid, musicSlid, sfxSlid;

    // Start is called before the first frame update
    void Start()
    {
        fullScreenTog.isOn = Screen.fullScreen;
        bool foundRes = false;
        for(int i = 0; i < resolutions.Count; i ++)
        {
            if(Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical)
            {
                foundRes = true;
                selectedResolution = i;
                UpdateResLab();
            }
        }
        if(!foundRes)
        {
            ResItem newRes = new ResItem();
            newRes.horizontal = Screen.width;
            newRes.vertical = Screen.height;
            resolutions.Add(newRes);
            selectedResolution = resolutions.Count - 1;
            UpdateResLab();
        }

    float vol = 0f;
    mixer.GetFloat("MasterVol", out vol);
    masterSlid.value = vol;
    mixer.GetFloat("MusicVol", out vol);
    musicSlid.value = vol;
    mixer.GetFloat("SFXVol", out vol);
    sfxSlid.value = vol;

    master.text = Mathf.RoundToInt(masterSlid.value + 80).ToString();

    music.text = Mathf.RoundToInt(musicSlid.value + 80).ToString();

    sfx.text = Mathf.RoundToInt(sfxSlid.value + 80).ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResLeft()
    {
        selectedResolution--;
        if(selectedResolution < 0)
        {
            selectedResolution = 0;
        }
        UpdateResLab();
    }

    public void ResRight()
    {
        selectedResolution++;
        if(selectedResolution > resolutions.Count - 1)
        {
            selectedResolution = resolutions.Count - 1;
        }
        UpdateResLab();
    }

    public void UpdateResLab()
    {
        resolutionLabel.text = resolutions[selectedResolution].horizontal.ToString() + " x " + resolutions[selectedResolution].vertical.ToString();
    }

    public void Apply()
    {
        Screen.SetResolution(resolutions[selectedResolution].horizontal, resolutions[selectedResolution].vertical, fullScreenTog.isOn);
    }

    public void SetMasterVol()
    {
        master.text = Mathf.RoundToInt(masterSlid.value + 80).ToString();
        mixer.SetFloat("Mixer", masterSlid.value);
        PlayerPrefs.SetFloat("Mixer", masterSlid.value);
    }

    public void SetMusicVol()
    {
        music.text = Mathf.RoundToInt(musicSlid.value + 80).ToString();
        mixer.SetFloat("MusicVol", musicSlid.value);
        PlayerPrefs.SetFloat("MusicVol", musicSlid.value);
    }

    public void SetSFXVol()
    {
        sfx.text = Mathf.RoundToInt(sfxSlid.value + 80).ToString();
        mixer.SetFloat("SFXVol", sfxSlid.value);
        PlayerPrefs.SetFloat("SFXVol", sfxSlid.value);
    }

}

[System.Serializable]
public class ResItem
{
    public int horizontal, vertical;
}