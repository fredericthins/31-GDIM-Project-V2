using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

//Purpose: Menu Management including button functions
public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject levelSelect;
    [SerializeField] GameObject scoreboard;
    [SerializeField] TextMeshProUGUI highscore;
    [SerializeField] TextMeshProUGUI unlockJump;
    [SerializeField] TextMeshProUGUI unlockRun;

    [SerializeField] GameObject mainMenu;

    //Enters Game
    public void PlayButton(){
        SceneManager.LoadScene("Level1");
    }

    public void Scores(){
        mainMenu.SetActive(false);
        scoreboard.SetActive(true);

        int hs = PlayerPrefs.GetInt("HighScore", 0);
        highscore.text = PlayerPrefs.GetString("HighScoreName", "Fred") + ": " + hs;

        //Check to see if player unlocks new powerups
        if(hs >= 15){
            unlockJump.text = "Jump Booost: Unlocked!";
        }
        if(hs >= 25){
            unlockRun.text = "Run Booost: Unlocked!";
        }

    }

    //Returns to main menu
    public void Return(){
        scoreboard.SetActive(false);
        levelSelect.SetActive(false);
        mainMenu.SetActive(true);
    }

    //Quits the game
    public void Quit(){
        Application.Quit();
    }
}
