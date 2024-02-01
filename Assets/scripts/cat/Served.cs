using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Served : MonoBehaviour
{
    
    // public GameObject 
  //  public GameObject aM;
    public GameObject sM;
    GameObject gameManager;
    GameObject cup = null;

    public bool delivered = false;

    public bankBallence account;
    testScript script;
   public mouthMover mouth;
    sendmessage message;

  //Expected Teas
    public bool OolongTeaReq = false;
    public bool MatchaTeaReq = false;
    public bool MilkTeaReq = false;
    public bool WaterTeaReq = false;
    public bool MatchaLongTeaReq = false;

   // audioManager aud;





    // Start is called before the first frame update
    void Start()
    {
      //  aud = aM.GetComponent<audioManager>();
        message = sM.GetComponent<sendmessage>();
    
        
 
    }

    // Update is called once per frame
    void Update()
    {
        
            OolongTeaReq = message.OolongTeaReq;
            MilkTeaReq = message.MilkTeaReq;
            WaterTeaReq = message.WaterTeaReq;
    }

    //Upon collision with another GameObject
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "cup")
        { //cup = cup.transform.GetChild(5).gameObject.GetComponent<testScript>();
            cup = other.gameObject;
            script = cup.GetComponentInChildren<testScript>();
            script.CheckOrder();
            if (script.oolongTea || script.milkTea || script.waterTea || script.matchaTea || script.matchaLongTea)
            {
                
               
                if(script.matchaLongTea == MatchaLongTeaReq && script.matchaTea == MatchaTeaReq && script.oolongTea == OolongTeaReq && script.milkTea == MilkTeaReq && script.waterTea == WaterTeaReq)
                {   message.girlOne ++;
               message.correctOrder = true;
                 account.AddMoney(account.ballance, 90f);
                   message.ItemRecieved();
                }
                else
                {
                    message.girlOne ++;
                    account.AddMoney(account.ballance, 50f);
                    message.ItemRecieved();
                }
                cup.transform.position = new Vector3(-10000, -10000, -10000);
                
                DeleteOldCUp();
                //mouth.CloseMouth();
              //  mouth.CloseMouth();
                // mouth.CloseMouth();

                //account.AddMoney(account.ballance, 90f);
                // aud.PlayMessage();
              //  message.ItemRecieved();
                //aud.PlayMessage();
              //    if (message.mtext.text == "DELICIOUS XI XI one more pleae!!")
             //   {
              //      message.mtext.text = "AMAZING XI XI !";
             //   }
             //   else
              //  {
              //      message.ColorChange();
              //  }
            }
               

            }
        }
   public void DeleteOldCUp()
    {
        Destroy(cup);
        mouth.CloseMouth();
     
    }
}

