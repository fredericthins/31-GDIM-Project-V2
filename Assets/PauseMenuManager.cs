using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    bool isPaused = false;
    [SerializeField] GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }    
    }


//Pause Button Functions
    //Resume the game
    public void Resume()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    //Return the player to the menu scene
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    //Quit out of the game
    public void Quit()
    {
        Application.Quit();
    }
    //Restart the current & active level
    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    //Pause the game by reducing the timescale to 0
    void Pause()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
