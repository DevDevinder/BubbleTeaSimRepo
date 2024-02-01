using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
///Pause Game
public class PauseMenu : MonoBehaviour
{
      public string MainMenu;
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public static bool isPaused = false;

    public GameObject objWith_DontDestroyOnLoad_Script;
    public GameObject toBeParent;


  
    
    // Start is called before the first frame update
    void Start()
    {
    
        // Time.timeScale = 1f;
        
    }

    // Update is called once per frame
    void Update()
    {   //if player press O key open options menu
        if(Input.GetKeyDown(KeyCode.O ))
        {
            if(isPaused)
            {
                ResumeGame();
                CloseOptions();
            }
            else
            {
               
               
                PauseGame();
                
           

        }
    }
    }
//go to main menu scene
    public void MainMenuScene()
    {      
       Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene(MainMenu);
       
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        Debug.Log("Main Menu");
         
    }

//open menu function if player press escape key
    public void PauseGame()
    {
       
       
      
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
          Cursor.lockState = CursorLockMode.Confined;
         
           


    }
    
    public void ResumeGame()
    {   
        
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    public void OpenOptions()
    {
       optionsMenu.SetActive(true);
    }

    public void CloseOptions()
    {
       optionsMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}

