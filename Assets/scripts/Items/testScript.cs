using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour
{
  //  public GameObject thisOne;
  //  public GameObject aM;
  //  public GameObject sM;
  //  sendmessage message;
  //  gameManager gM;
 //   GameObject gameManager;

 //ingredient bools
    public int increment = 0;
    public bool wohoo = false;
    public bool bubbly = false;
    public bool milky = false;
    public bool watery = false;
    public bool oolong = false;
    public bool matcha = false;
//tea type bools
    public bool oolongTea = false;
    public bool milkTea = false;
    public bool waterTea = false;
    public bool matchaTea = false;
    public bool matchaLongTea = false;




   public GameObject partical;
    public GameObject childObj;

   //script to change colour of cup
    CupColours cupColours;


    //  audioManager aud;

    private void Start()
    {
        //get script from child object
        childObj = GetComponentInChildren<CupColours>().gameObject;
        cupColours = childObj.GetComponent<CupColours>();

      
        
    //    aud = aM.GetComponent<audioManager>();
     //   message = sM.GetComponent<sendmessage>();

        //gM.gameObject.GetComponent<gameManager>();
        //    assignAu.GetComponent<audioManager>().cup = thisOne;
        // assignSe.GetComponent<sendmessage>().obj = thisOne;
        //  gM = gameManager.gameObject.GetComponent<gameManager>();

    }
    void Update()
    {
        
       
    }

    //Upon collision with another GameObject
    private void OnTriggerEnter(Collider other)
    {
      
        if (other.tag == "ingredient")
        {
          
            partical.SetActive(true);
            increment++;
            if (increment == 4)
            {
              
                bubbly = true;
       //         aud.PlayMessage();
         //       message.ColorChange();
                
            }
            Destroy(other.gameObject);
            Debug.Log("added");
            Debug.Log(increment);
            
        }

        if(other.tag == "Oolong")
        {
            partical.SetActive(true);
            oolong = true;
            Destroy(other.gameObject);
            Debug.Log("OOlong added");

        
            
            //run method in cupColours script
            cupColours.CheckCup();
            
          

        //      childObj = this.gameObject.GetComponentInChildren<CupColours>();
        //     //run method in cupColours script
        // childObj.GetComponent<CupColours>().CheckCup();
            

            
        }
        if(other.tag == "Matcha")
        {
            partical.SetActive(true);
            matcha = true;
            Destroy(other.gameObject);
            Debug.Log("Matcha added");

        
            
            //run method in cupColours script
            cupColours.CheckCup();
            

            
        }
      
     

    }

    //check order conditions
    public void CheckOrder()
    {
       MilkBubble();
         OolongBubble();
            WaterBubble();
            MatchaBubble();
            MatchaLongBubble();

    }
    //orders conditions

    //oolong tea condition
    public void OolongBubble()
    {
        if ( bubbly== true && oolong == true && watery == true && milky == true && matcha == false)
        {
            oolongTea = true;
            matchaTea = false;
            Debug.Log("Oolong Tea prepared");
            milkTea = false;
            waterTea = false;
            matchaLongTea = false;
        }
    }
    //matcha tea condition
       public void MatchaBubble()
    {
        if ( bubbly== true && oolong == false && watery == true && milky == true && matcha == true)
        {
            oolongTea = false;
            matchaTea = true;
            Debug.Log("Matcha Tea prepared");
            milkTea = false;
            waterTea = false;
            matchaLongTea = false;
        }
    }
      //matchaLong tea condition
       public void MatchaLongBubble()
    {
        if ( bubbly== true && oolong == true && watery == true && milky == true && matcha == true)
        {
            oolongTea = false;
            matchaTea = false;
            Debug.Log("MatchaLong Tea prepared");
            milkTea = false;
            waterTea = false;
            matchaLongTea = true;
        }
    }

    //milk tea condition
    public void MilkBubble()
    {
        if (bubbly == true && milky == true &&  watery ==true && oolong == false && matcha == false)
        {
            milkTea = true;
            matchaTea = false;
            Debug.Log("Milk Tea prepared");
            oolongTea = false;
            waterTea = false;
            matchaLongTea = false;
        }
    }

    //water tea condition
    public void WaterBubble()
    {
        if (bubbly == true && watery == true && milky == false && oolong == true  && matcha == false)
        {
            waterTea = true;
            matchaTea = false;
            Debug.Log("Water Tea prepared");
            milkTea = false;
            oolongTea = false;
            matchaLongTea = false;
        }
    }
   
    
}
