using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

///options menu
public class OptionsScreen : MonoBehaviour
{
    public Toggle fullscreenToggle, vsyncToggle;

    public List<ResItem> resolutions = new List<ResItem>();

    private int selectedResolution;

    public TMP_Text resolutionLabel;
//audio variables
    public AudioMixer audioMixer;

    public TMP_Text masterLabel, musicLabel, sfxLabel;
    public Slider masterSlider, musicSlider, sfxSlider;



    // Start is called before the first frame update
    void Start()
    {
        fullscreenToggle.isOn = Screen.fullScreen;

        if(QualitySettings.vSyncCount == 0)
        {
            vsyncToggle.isOn = false;
        }
        else
        {
            vsyncToggle.isOn = true;
        }
        //matches ui resolution to current resolution
        bool foundRes = false;
        for(int i = 0; i < resolutions.Count; i++)
        {
            if(resolutions[i].horizontal == Screen.width && resolutions[i].vertical == Screen.height)
            {
                selectedResolution = i;
                foundRes = true;

                UpdateResolutionLabel();

            }
        }
        //if resolution is not found, add it to the list(good for resolutions that players have that we dont provide)
        if(!foundRes)
        {
            resolutions.Add(new ResItem { horizontal = Screen.width, vertical = Screen.height });
            selectedResolution = resolutions.Count - 1;
            UpdateResolutionLabel();
        }

        float vol = 0f;
        audioMixer.GetFloat("MasterVol", out vol);
        masterSlider.value = vol;
        masterLabel.text = Mathf.RoundToInt(masterSlider.value + 80).ToString();

        audioMixer.GetFloat("MusicVol", out vol);
        musicSlider.value = vol;
        musicLabel.text = Mathf.RoundToInt(musicSlider.value + 80).ToString();

        audioMixer.GetFloat("SFXVol", out vol);
        sfxSlider.value = vol;
        sfxLabel.text = Mathf.RoundToInt(sfxSlider.value + 80).ToString();

 
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
       UpdateResolutionLabel();
    }

    public void ResRight()
    {
        selectedResolution++;
        if(selectedResolution > resolutions.Count - 1)
        {
            selectedResolution = resolutions.Count - 1;
        }
        UpdateResolutionLabel();
    }

    public void UpdateResolutionLabel()
    {
        resolutionLabel.text = resolutions[selectedResolution].horizontal.ToString() + "X" + resolutions[selectedResolution].vertical.ToString();
    }

    public void ApplyGraphics()
    {
        //Screen.fullScreen = fullscreenToggle.isOn;

        if(vsyncToggle.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }

        Screen.SetResolution(resolutions[selectedResolution].horizontal, resolutions[selectedResolution].vertical, fullscreenToggle.isOn);
    }

    public void SetMasterVolume()
    {
        // audioMixer.SetFloat("MasterVolume", volume);
        masterLabel.text = Mathf.RoundToInt(masterSlider.value + 80).ToString();

        audioMixer.SetFloat("MasterVol", masterSlider.value);

        PlayerPrefs.SetFloat("MasterVol", masterSlider.value);
    }
      public void SetMusicVolume()
    {
        // audioMixer.SetFloat("MasterVolume", volume);
        musicLabel.text = Mathf.RoundToInt(musicSlider.value + 80).ToString();

        audioMixer.SetFloat("MusicVol", musicSlider.value);

        PlayerPrefs.SetFloat("MusicVol", musicSlider.value);
    }
      public void SetSfxVolume()
    {
        // audioMixer.SetFloat("MasterVolume", volume);
        sfxLabel.text = Mathf.RoundToInt(sfxSlider.value + 80).ToString();

        audioMixer.SetFloat("SFXVol", sfxSlider.value);

        PlayerPrefs.SetFloat("SFXVol", sfxSlider.value);
    }

    [System.Serializable]
    public class ResItem
    {
        public int horizontal, vertical;
       

    }
}
