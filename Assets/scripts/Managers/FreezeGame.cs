using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeGame : MonoBehaviour
{
    bool isPaused = false;
    bool isOnPC = false;

    //gameObjects with scripts
    public GameObject pauseMenu;
    public GameObject computer;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //if gameobject pause menu bool is true
       if(pauseMenu.activeSelf == true || computer.activeSelf == true)
    {
        //freeze game
        Time.timeScale = 0f;
        
        Cursor.lockState = CursorLockMode.Confined;
    }
    else
    {
        //resume game
        Time.timeScale = 1f;
      
        Cursor.lockState = CursorLockMode.Locked;


    }
}
}
