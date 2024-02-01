using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class audioManager : MonoBehaviour
{
    public GameObject messageSpeakers;
    public GameObject musicSpeakers;
    private testScript testscript;
    public GameObject cup = null;

     AudioSource music;
    AudioSource message;
    public AudioClip musicClip;
    public AudioClip messageClip;

    public AudioMixer audioMixer;
    private bool soundplayed;
    
    // Start is called before the first frame update
    void Start()
    {
        soundplayed = false;
       // testscript = cup.GetComponent<testScript>();
       message = messageSpeakers.GetComponent<AudioSource>();

       //player audio preferences

        if(PlayerPrefs.HasKey("MasterVol"))
        {
            audioMixer.SetFloat("MasterVol", PlayerPrefs.GetFloat("MasterVol"));
        }
        if(PlayerPrefs.HasKey("MusicVol"))
        {
            audioMixer.SetFloat("MusicVol", PlayerPrefs.GetFloat("MusicVol"));
        }
        if(PlayerPrefs.HasKey("SFXVol"))
        {
            audioMixer.SetFloat("SFXVol", PlayerPrefs.GetFloat("SFXVol"));
        }

    }

    // Update is called once per frame
    void Update()
    {
        //if (testscript.wohoo == true && soundplayed == false)
       // {

         //   PlayMessage();
           
         
        //}
    }
    public void PlayMessage()
    {
        if (soundplayed == false)
        {
            message.PlayOneShot(messageClip);
            soundplayed = true;
        }
        soundplayed = false;
    }
}

