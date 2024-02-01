using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowderDespawner : MonoBehaviour
{

    //script to reference bool
    public grabItems grabItems;
    
    
    // Start is called before the first frame update
    void Start()
    {
        grabItems = GameObject.Find("player").GetComponent<grabItems>();
    }

    // Update is called once per frame
    void Update()
    {
        if(grabItems.flipped == true)
        {
            //remove parent
            transform.parent = null;
            //turn on gravity
            GetComponent<Rigidbody>().useGravity = true;
            //turn off kinematic
            GetComponent<Rigidbody>().isKinematic = false;
        }
        //if gameobject doesnt have parent
        if (transform.parent == null)
        {
            // destroy gameobject after 3 seconds
            Destroy(gameObject, 3);
          
        }
    }
}
