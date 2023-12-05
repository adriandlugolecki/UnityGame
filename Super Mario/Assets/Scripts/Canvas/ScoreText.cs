using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private GameManager gameManager;
    public Text scoreText;
    public Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        scoreText.text = "Score: " + gameManager.score;
        int timeInt = Mathf.CeilToInt(gameManager.time);
        if (timeInt < 10)
        {

            timeText.text = "Time 00" + timeInt.ToString();
        }
        else if (timeInt < 100)
        {
            timeText.text = "Time 0" + timeInt.ToString();
        }
        else
        {
            timeText.text = "Time " + timeInt.ToString();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
