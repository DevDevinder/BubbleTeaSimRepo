using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabItems : MonoBehaviour
{
    GameObject mainCamera;
    bool carrying;
    public GameObject carriedObject;
    public GameObject hands;
    public float distance;
    public float smooth;
    public bool flipped = false;



    // Use this for initialization
    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");


    }

    // Update is called once per frame
    void Update()
    {
        try
        {
             if (carrying)
            { 
                if(!flipped)
                {
                    carry(carriedObject);
                    checkDrop();
                }
              //rotateObject();
              //if has tag Scoop
                if(carriedObject.tag == "Scoop")
                {
                 if (Input.GetMouseButtonDown(0) && flipped == false)
                    {   
                         flipped = true;
              //rotate object 180 degrees slowly for 2 seconds upside down 
                         carriedObject.transform.Rotate(180, 0, 0);
        //if scoop has child object with ingredient tag
                         checkScoop();
        //start coroutine to wait 2 seconds before flipping object
        StartCoroutine(FlipObject());
        //Destroy Child
       // Destroy(child);
                     }
                } 
            
            } else
                  {
                    pickup();
                  }   
        //catch missing reference exception and null reference exception


         } catch (MissingReferenceException e)
        
        {
            objectremoved();
            Debug.Log("missing reference");
        }
        catch (System.NullReferenceException e)
        {
            objectremoved();
            Debug.Log("null reference");

        }
    }
       
    //check if child object of scoop has ingredient tag
    void checkScoop()
    {
        if (carriedObject.transform.childCount > 0)
        {
            //get child object
            GameObject obj = carriedObject.transform.GetChild(0).gameObject;
            if (obj.tag == "ingredient")
            {
                Debug.Log("child has ingredient tag");
                //if child has ingredient tag
              
            }
        }
    }
    

    //coroutine to waite for 2 seconds before flipping object
    IEnumerator FlipObject()
    {
        yield return new WaitForSeconds(1);
      
        //flip bool
        flipped = false;
    }

    void rotateObject()
    { 
        //reset objects rotation
        //carriedObject.transform.rotation = Quaternion.identity;
        //rotate object to face away from player
        //carriedObject.transform.Rotate(0, 180, 0);
        //rotate object to cameras rotation
        carriedObject.transform.rotation = hands.transform.rotation;
        //if player presses left mouse button turn object upside down
    
    }

    void carry(GameObject o)
    {
        // o.transform.position = Vector3.Lerp(o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
        //place object into hands position
        o.transform.position = hands.transform.position;
        rotateObject();
        

    }

    void pickup()
    {
        if (Input.GetMouseButtonDown(1))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1.5f))
            {
                pickupable p = hit.collider.GetComponent<pickupable>();
                if (p != null)
                {
                    carrying = true;
                    carriedObject = p.gameObject;
                    p.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    rotateObject();
                }
            }
        }
    }

    void checkDrop()
    {
        if (Input.GetMouseButtonDown(1))
        {
            dropObject();
        }
    }

    void dropObject()
    {
        carriedObject.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        carrying = false;
        
        carriedObject = null;
        flipped = false;
    }

    //if is object is missing set carrying to false
    void objectremoved()
    {
        carrying = false;
        Debug.Log("object removed");
        
    }


   
    
}
