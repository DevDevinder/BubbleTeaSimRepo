using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouthMover : MonoBehaviour
{
    Served served;
    //put into the enemy
    public GameObject topLip;
    public GameObject botLip;
    public GameObject box;
    GameObject cup;
    Vector3 firstPosition;
    Vector3 endPosition;
    Vector3 returnPosition;
    bool open = false;
    int speed = 1;
    private void Start()
    {
       served = box.GetComponentInChildren<Served>();

    }
    void Update()
    {

      
    }
    //if cup colider enters mouth will open if not already open
    #region coliders
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "cup" && !open)
        {
            //cup = other.gameObject;
            topLip.transform.Translate(0, 0.25f, 0);

            botLip.transform.Translate(0, -0.25f, 0);

            box.transform.Translate(0, 0, -1.5f);
            open = true;
          //  if (served.delivered == true)
         //   {
        //        topLip.transform.Translate(0, -0.25f, 0);
         //       botLip.transform.Translate(0, 0.25f, 0);

         //       box.transform.Translate(0, 0, 1.5f);
        //    }

       }
        
    }

    //closes mouth when object exits
    private void OnTriggerExit(Collider other)
    {
        if(open && other.tag == "cup")
        {
            topLip.transform.Translate(0, -0.25f, 0);

            botLip.transform.Translate(0, 0.25f, 0);

            box.transform.Translate(0, 0, 1.5f);
            open = false;
        }
        
    }
    #endregion

    //closes mouth when called
    #region close mouth method
    public void CloseMouth()
    {
      
        
            topLip.transform.Translate(0, -0.25f, 0);

            botLip.transform.Translate(0, 0.25f, 0);

            box.transform.Translate(0, 0, 1.5f);
            open = false;
        
    }
    #endregion
}