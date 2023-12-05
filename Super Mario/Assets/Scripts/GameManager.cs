using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score = 0;
    public int lives = 3;
    public float time = 0;
    public Text scoreText;
    public Text livesText;
    public Text timeText;
    public GameObject gameOverView;
    public GameObject EndView;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }

        time += Time.deltaTime;
        int timeInt = Mathf.CeilToInt(time);
        if (timeInt < 10) {
            
                timeText.text = "Time 00"+ timeInt.ToString();
        }else if (timeInt < 100) {
                timeText.text = "Time 0" + timeInt.ToString();
        }
        else {
                timeText.text = "Time " + timeInt.ToString();
        }
        
    }
    private void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        livesText.text = "lives: " + lives;

    }

    public void AddScore(int points)
    {
        score += points;
        UpdateUI();
    }

    public void TakeLife()
    {
        lives--;
        if(lives < 0)
        {
            RestartGame();
        }
        else
        {
            UpdateUI() ;
        }
                           
    }
    public void TakeAllLife()
    {
        RestartGame();
    }

    public void RestartGame()
    {
        gameOverView.SetActive(true);
    }
    public void NewGame()
    {
        time = 0;
        score = 0;
        lives = 3;
        SceneManager.LoadScene("Start");
        UpdateUI();
        gameOverView.SetActive(false);
        EndView.SetActive(false);
    }
    public void EndGame()
    {
        
        EndView.SetActive(true);
    }
}
