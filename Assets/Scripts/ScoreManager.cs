using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Purpose: Keeps tracks of score through a simple int value Score attached to a text element
public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    public int score = 0;
    public static ScoreManager _instance;

    //Singleton Implementation, because there will only be no duplicate score managers.
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
    }
    
    //Given an increase or decrease of value (accounting for positive or negative), ScoreManager will update the UI and Score value

    public void UpdateScore(int value)
    {
        score += value;
        UpdateText();
    }

    //Separate method to update text for flexibility

    public void UpdateText()
    {
        scoreText.text = "Score: " + score;
    }
}
