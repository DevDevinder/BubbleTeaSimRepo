using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// changes colour of cup based on what is in it
public class CupColours : MonoBehaviour
{
    //game object with testScript
    public testScript testScript;

    //bools to check if the cup has certain ingredients
    bool wohoo = false;
    bool milky = false;
    bool watery = false;
    bool oolong = false;
    bool matcha = false;

    //bool to check if colours have changed
    bool botChanged =false;
    bool topChanged = false;
    bool midChanged = false;

    bool functionCalled = false;

    //material to change from mesh renderer
    public Material[] material;
    //renderer
    MeshRenderer meshRenderer;

    //materials to use
    public Material oolongMat;
     public Material MatchaMat;
    public Material milkMat;
    public Material waterMat;
    public Material matchLongMat;
   


// bottom = 1
// middle = 2
// top = 0



    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();


        

    }

    // Update is called once per frame
    void Update()
    {
        // CheckCup(); 
    }

    //method to check what is in the cup
    public void CheckCup()
    { Debug.Log("checkcup");

// bottom = 1
// middle = 2
// top = 0
    if(functionCalled == false){
    functionCalled = true;
       


        //if the cup has the correct ingredients
        if (testScript.milky == true)
        {
             //change second material element to the correct colour
            // oldMat = material;
            if(botChanged == false)
            {
                Debug.Log("checkmilk");
                meshRenderer.materials[1].color = milkMat.color;
                botChanged = true;
                //  if(testScript.oolong == true)
                // {
                //     meshRenderer.materials[1].color = oolongMat.color;
                // }
            }
            else 
                if (testScript.watery == true && botChanged == true)
                
                {Debug.Log("midcall");
                    meshRenderer.materials[1].color = milkMat.color;
                    meshRenderer.materials[2].color = milkMat.color;
                    midChanged = true;

                //      if(testScript.oolong == true)
                // {
                //      meshRenderer.materials[1].color = oolongMat.color;
                //     meshRenderer.materials[2].color = oolongMat.color;
                // }
                }
             
            
        }
        //if the cup has the correct ingredients
        if (testScript.watery == true)
        {
            
            if (testScript.milky == true && botChanged == true)
                
                {Debug.Log("midcall");
                    meshRenderer.materials[2].color = milkMat.color;
                    midChanged = true;
                //  if(testScript.oolong == true)
                // {
                //     meshRenderer.materials[2].color = oolongMat.color;
                // }
                    
                }

            else if(botChanged == false)
            {   Debug.Log("checkwater");
            //mesh renderer material 1 is same colour as water
                meshRenderer.materials[1].color = waterMat.color;
                botChanged = true;

                // if(testScript.oolong == true)
                // {
                //     meshRenderer.materials[1].color = oolongMat.color;
                // }
               
            } 
               

        } 

        // if the cup has the correct ingredients
        if (testScript.oolong == true)
        {
            if (midChanged == true )
                
                {Debug.Log("midcall");
                    meshRenderer.materials[2].color = oolongMat.color;
                    meshRenderer.materials[1].color = oolongMat.color;
                    
                }
             
                else if(botChanged == true)
            {   Debug.Log("checkoolong");
            //mesh renderer material 1 is same colour as oolong
                meshRenderer.materials[1].color = oolongMat.color;
                
               
            } 
        }
         if (testScript.matcha == true)
        {
            if (midChanged == true )
                
                {Debug.Log("midcall");
                    meshRenderer.materials[2].color = MatchaMat.color;
                    meshRenderer.materials[1].color = MatchaMat.color;
                    
                }
             
                else if(botChanged == true)
            {   Debug.Log("checkoolong");
            //mesh renderer material 1 is same colour as oolong
                meshRenderer.materials[1].color = MatchaMat.color;
                
               
            } 
        }
         if (testScript.oolong == true && testScript.matcha == true)
        {
            if (midChanged == true )
                
                {Debug.Log("midcall");
                    meshRenderer.materials[2].color = matchLongMat.color;
                    meshRenderer.materials[1].color = matchLongMat.color;
                    
                }
             
                else if(botChanged == true)
            {   Debug.Log("checkoolong");
            //mesh renderer material 1 is same colour as oolong
                meshRenderer.materials[1].color = matchLongMat.color;
                
               
            } 
        }
        
    }functionCalled = false;

         
        
    }
}
