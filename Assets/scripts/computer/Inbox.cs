using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inbox : MonoBehaviour
{
    [SerializeField] GameObject pc;
    [SerializeField] GameObject chatPage;
 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void chat()
    {
     //   chatPage.SetActive(true);
     //   pc.SetActive(false);
     //   chatPage.SetActive(true);
     //   Time.timeScale = 0f;
    }
    public void orders()
    {

    }
    public void reviews()
    {

    }
    public void exitPC()
    {
        pc.gameObject.SetActive(false);
        computer.isOnPC = false;
        
    }

   public void chatMessages()
    {
      
        
    }
   public void chatExit()
    {
       //pc.gameObject.SetActive(true);
      // chatPage.gameObject.SetActive(false);
    }
}
