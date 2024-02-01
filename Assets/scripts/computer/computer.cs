using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class computer : MonoBehaviour
{
    public static bool isOnPC = false;
    [SerializeField] GameObject pc;
    // Start is called before the first frame update
    void Start()//
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isOnPC == true)
        {//
            openPC();//
        }
        else
        {
            resumeGame();
        }
        
    }

    void resumeGame()
    {
        pc.SetActive(false);
        // Time.timeScale = 1f;
        isOnPC = false;
        // Cursor.lockState = CursorLockMode.Locked;
    }
    void openPC()
    {
        pc.SetActive(true);
        // Time.timeScale = 0f;
        isOnPC = true;
        // Cursor.lockState = CursorLockMode.Confined;
    }
    


}
