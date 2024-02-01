using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoopCollider : MonoBehaviour
{
     public GameObject newScoop;
    public GameObject scoopHolder;
    GameObject oldScoop;
    GameObject mainCamera;
   
    Vector3 holderPos;
    Vector3 newPos;
    audioManager assign;
   public GameObject audObj;
    public GameObject sendObj;
    sendmessage assignmessage;
    GameObject child;
    int bubblecount;
    bool bubbly = false;
    bool milky = false;
    bool there = false;

    


    // Start is called before the first frame update
    void Start()
    {
        //position for cup to sit at when dropped
        holderPos = new Vector3(0, 10, 0);
        //position for new cup to spawn
        newPos = new Vector3(0, 0, 0);
        //main camera reference
        mainCamera = GameObject.FindWithTag("MainCamera");
        


    }

    // Update is called once per frame
    void Update()
    {  //if cup is placed down  call pour milk method
        if(there == true)
        {
            PourMilk();
        }
    }
    //Upon collision with another GameObject
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Scoop" )
        {
            Debug.Log("placed");
            //place the cup 
            other.transform.position = Vector3.MoveTowards(transform.position, transform.position, Time.deltaTime);
            //position of cups
            oldScoop = other.gameObject;
            newPos = oldScoop.transform.position;

            //grab script from old cup
            // oldScript = oldCup.GetComponentInChildren<testScript>();
            
            //    PourMilk(other);
            //set true that cup is placed down
            there = true;
            //if the old cup is not milky
          
        }

    }

    void OnCollisionExit(Collision other)
    {
        //when cup leaves area its no longer classed as there so can be replaced
        there = false;


    }

    //method to simulate pour milk into cup based on conditions met
     void PourMilk()
    {
        //when right clicking 
        if (Input.GetMouseButtonDown(1) )
        {// raycast from location(center screen)
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            //if the raycast hits within 1.5f distance
            if (Physics.Raycast(ray, out hit, 1.5f))
            {//check if it hit a colider containing the hotwatercheck script(kettle machine)
                OolongMachineCheck phit = hit.collider.GetComponent<OolongMachineCheck>();
                //if hit
                if (phit != null)
                {
                    //cup is no longer there
                   

                    Debug.Log("clicked");
                    //*NOTE could possibly just change parent and child objects colours. instead of replacing object

                   
                        //call this method
                        NewScoopCreate();
                       
                      
                    
                   

                    // newCup.GetComponentInChildren<testScript>().increment = oldScript.increment;
                    //  newCup.GetComponentInChildren<testScript>().wohoo = oldScript.wohoo;
                    //  Instantiate(newCup, newPos, Quaternion.identity, oldCup.transform);
                    //assign.GetComponent<audioManager>().cup = newCup.transform.Find("GameObject").gameObject;
                    //   assign.GetComponent<sendmessage>().obj = newCup.transform.Find("GameObject").gameObject;

                    //   assign.GetComponent<audioManager>().cup = newCup.transform.Find("GameObject").gameObject; 
                    //     assign.GetComponent<sendmessage>().obj = newCup.transform.Find("GameObject").gameObject;
                   



                    // milkAdded = true;



                }
            }
           
        }
    }
    //creats new cup with data inserted 
    void NewScoopCreate()
    {   
       
       
       
        Instantiate(newScoop, newPos, transform.rotation);

        
        //call delete cup method
        DeleteOldCUp();
        


    }
    //deletes old cup
    void DeleteOldCUp()
    {   //yeet cup offscreen
        oldScoop.transform.position = new Vector3(-10000, -10000, -10000);
        //destroy the cup
        Destroy(oldScoop);
        //declare cup as no longer there
        there = false;
    }

 

      
    
}