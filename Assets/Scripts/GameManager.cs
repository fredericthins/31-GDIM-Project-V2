using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public string playerName;
    public GameObject inputField;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] TextMeshProUGUI scoreText;
    public static GameManager _instance;

    //Set of items/unlockable boosts available
    public List<GameObject> items;

    //List of Powerups
    [SerializeField] GameObject p1;
    [SerializeField] GameObject p2;
    [SerializeField] GameObject p3;
    [SerializeField] GameObject p4;
    [SerializeField] GameObject p5;


    //Singleton Implementation, because there will only be no duplicate game managers.
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        //This prevent pausing on repeated play
        Time.timeScale = 1f;

        PlayerPrefs.SetInt("HighScore", 100);
        ItemSetup(PlayerPrefs.GetInt("HighScore", 0));
    }
    public void GameOver(){
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
        scoreText.text = "Game Over \n Score: " + ScoreManager._instance.score;
    }

    public void OnQuitButton(){
        playerName = inputField.GetComponent<TMP_InputField>().text;

        if(ScoreManager._instance.score > PlayerPrefs.GetInt("HighScore", 0)){
            Debug.Log("setting highscore");
            PlayerPrefs.SetInt("HighScore", ScoreManager._instance.score);
            PlayerPrefs.SetString("HighScoreName", playerName);
        }
        SceneManager.LoadScene("Menu");
    }

    //ItemSetup Makes Certain Powerups Available Depending on highscore
    void ItemSetup(int score){
        //clear items list
        items.Clear();
        //Add default powerups
        items.Add(p1);
        items.Add(p2);
        items.Add(p3);
        //Unlock another power up at score = 15
        if(score >= 15){
            items.Add(p4);
        }
        //Unlock another power up at score = 25
        if(score >= 25){
            items.Add(p5);
        }
    }
}
