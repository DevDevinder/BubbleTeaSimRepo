using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPromts : MonoBehaviour
{  
    //public gameObjects
    public GameObject textPrompt1;
    public GameObject textPrompt2;
    public GameObject textPrompt3;
    public GameObject textPrompt4;

    //bool tasks completed
    public bool taskCompleted1 = true;
    public bool taskCompleted2 = false;
    public bool taskCompleted3 = false;
    public bool taskCompleted4 = false;

    //bool text prompt displayed
    public bool textPromptDisplayed1 = false;
    public bool textPromptDisplayed2 = false;
    public bool textPromptDisplayed3 = false;
    public bool textPromptDisplayed4 = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if task is completed display text prompt
        if(taskCompleted1 && !textPromptDisplayed1){
            StartCoroutine(DisplayTextPrompt1());
        }
        if(taskCompleted2 && !textPromptDisplayed2){
            StartCoroutine(DisplayTextPrompt2());
        }

        if(taskCompleted3 && !textPromptDisplayed3){
            StartCoroutine(DisplayTextPrompt3());
        }

        if(taskCompleted4 && !textPromptDisplayed4){
            StartCoroutine(DisplayTextPrompt4());
        }
        
    }

    //couroutine display textprompt for 10 seconds
    IEnumerator DisplayTextPrompt1()
    {
        textPrompt1.SetActive(true);
        yield return new WaitForSeconds(3);
        textPrompt1.SetActive(false);
        textPromptDisplayed1 = true;
    }

    IEnumerator DisplayTextPrompt2()
    {
        textPrompt2.SetActive(true);
        yield return new WaitForSeconds(3);
        textPrompt2.SetActive(false);
        textPromptDisplayed2 = true;
    }

    IEnumerator DisplayTextPrompt3()
    {
        textPrompt3.SetActive(true);
        yield return new WaitForSeconds(3);
        textPrompt3.SetActive(false);
        textPromptDisplayed3 = true;
    }

    IEnumerator DisplayTextPrompt4()
    {
        textPrompt4.SetActive(true);
        yield return new WaitForSeconds(3);
        textPrompt4.SetActive(false);
        textPromptDisplayed4 = true;
    }



}
