using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sendmessage : MonoBehaviour
{
    #region GameObjects
    public GameObject comp;
    public GameObject aM;
    // public GameObject sM;
    // public GameObject obj = null;
    GameObject newText;
    public GameObject chatPanel;
    public GameObject nicChatPan;
    

    public GameObject textHolder;
    public GameObject nicChatHolder;
    #endregion

    #region ints
   public int girlOne;
    #endregion

    #region Bools
    //Expected Teas
    public bool OolongTeaReq = false;
    public bool MatchaTeaReq = false;
    public bool MatchaLongTeaReq = false;
    public bool MilkTeaReq = false;
    public bool WaterTeaReq = false;
    //correct order bool
    public bool correctOrder = false;
    #endregion

    #region panels
    //public GameObject panel;
    public TextMeshProUGUI chatMessage;
    public TextMeshProUGUI prefabChat;
    public TextMeshProUGUI newMessage;
    public TextMeshProUGUI RequestMessage;
    #endregion

    #region audioSources
    audioManager aud;
    #endregion

    #region scripts
    private testScript testscript;
    public Served servedScript;
    #endregion

    #region Start method
    // Start is called before the first frame update
    void Start()
    {
        aud = aM.GetComponent<audioManager>();
       // message = sM.GetComponent<sendmessage>();
        TextMesh mtext = GetComponent<TextMesh>();
        servedScript = GetComponent<Served>();
        SendRequestMessage();
        
      //  testscript = obj.GetComponent<testScript>();
    }
    #endregion

    #region update method
    // Update is called once per frame
    void Update()
    {   

       // if(testscript.wohoo == true)
        //{
           // panel.SetActive(true);
            
         //   mtext.text = "complete";
         //   comp.GetComponent<Renderer>().material.color = new Color(255, 255, 0);
         //   playsound = comp.GetComponent<AudioSource>();
     //   }
    }
    #endregion

    //changes computers colour
    #region ComputerColour 
     void ColorChange()
    {
        //  panel.SetActive(true);

       
        comp.GetComponent<Renderer>().material.color = new Color(255, 255, 0);
        //if chat panel is active comp colour changes hexvalue
        


      //  playsound = comp.GetComponent<AudioSource>();
    }
    public void ColorReturn()
    {
        //make computer colour return to brown
        comp.GetComponent<Renderer>().material.color = new Color(0.2924528f,0.1327646f,0.03145245f);
    }
    #endregion

    // audio play message 
    #region audio message
     void MessageAudio()
    {
        aud.PlayMessage();
       // playsound = comp.GetComponent<AudioSource>();
    }
    #endregion

    //sends request message to request page
    #region send Message Request
     void SendRequestMessage()
    {
        //  panel.SetActive(true);
        if(girlOne == 0)
        {
            RequestMessage.text = "One Classic";
            OolongTeaReq = false;
           MilkTeaReq = true;
            WaterTeaReq = false;
            MatchaTeaReq = false;
            MatchaLongTeaReq = false;

        }
        if (girlOne == 1)
        {
            RequestMessage.text = "One OoftLong";
            OolongTeaReq = true;
            MilkTeaReq = false;
            WaterTeaReq = false;
            MatchaTeaReq = false;
            MatchaLongTeaReq = false;
            MessageAudio();
            ColorChange();
        }
        if(girlOne == 2)
        {
            RequestMessage.text = "One MatchaLicious";
            OolongTeaReq = false;
            MilkTeaReq = false;
            WaterTeaReq = false;
            MatchaTeaReq = true;
            MatchaLongTeaReq = false;
            MessageAudio();
            ColorChange();
        }
    }
    #endregion

    // sends chat message to chat page
    #region chat page message
     void SendChatMessage()
    {
        //  panel.SetActive(true);
        if (girlOne == 1)
        {
          newMessage=  Instantiate(prefabChat);
            newMessage.transform.SetParent(textHolder.transform);
            newMessage.transform.SetAsLastSibling();
            if(correctOrder == true)
            {
                chatMessage.text = "DELICIOUS! Thank you for the tea <3";
            }
            else
            {
                chatMessage.text = "But I Asked for CLASSIC! im not paying full price for this!";
            }
            
            MessageAudio();
            ColorChange();
            correctOrder = false;
        }
        if (girlOne == 2)
        {
            newMessage = Instantiate(prefabChat);
            newMessage.transform.SetParent(textHolder.transform);
            newMessage.transform.SetAsFirstSibling();
            if(correctOrder == true)
            {
                newMessage.text = "wow great Service!";
            }
            else
            {
                newMessage.text = "this isnt what i asked for so i wont pay full price @(>_<)@";
            }
            
            MessageAudio();
            ColorChange();
            correctOrder = false;
        }
        if (girlOne == 3)
        {
            nicChatPan.SetActive(true);
            newMessage = Instantiate(prefabChat);
            newMessage.transform.SetParent(nicChatHolder.transform);
            newMessage.transform.SetAsFirstSibling();
            newMessage.text = "thank you for playing the prototype";
            MessageAudio();
            ColorChange();
            correctOrder = false;
        }
    }
    #endregion
    public void ItemRecieved()
    {
        SendChatMessage();
        SendRequestMessage();

    }

  
}
