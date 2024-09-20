using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public Text scoreText;
    private float currentScore = 0;
    public Text highScoreText;
    private float highScore;
    public Text currentScoreText;

    // Start is called before the first frame update
    void Start()
    {
        LoadScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.Over)
        {
            UpdateScoreGameOver();
            return;
        }
        if (!PlayerManager.isGameStarted)
            return;
        currentScore += Time.deltaTime;
        UpdateScoreText();
        SaveHighScore();
        
       
    }
    private void LoadScore()
    {
        currentScore = 0;
        highScore = PlayerPrefs.GetFloat("HighScore", 0);
        Debug.Log("Loaded High Score: " + highScore);
    }

    private void UpdateScoreText()
    {

        scoreText.text = "Skor: " + Mathf.Round(currentScore).ToString();

    }

    private void SaveHighScore()
    {
        highScore = PlayerPrefs.GetFloat("HighScore", 0);
        if (currentScore > highScore)
        {
            PlayerPrefs.SetFloat("HighScore", currentScore);
            PlayerPrefs.Save();
            // Debug.Log("New High Score Saved: " + currentScore);
        }
    }

    void UpdateScoreGameOver()
    {
        currentScoreText.text = Mathf.Round(currentScore).ToString();
        highScoreText.text = Mathf.Round(PlayerPrefs.GetFloat("HighScore", 0)).ToString();
        // Debug.Log("Game Over. Current Score: " + currentScoreText.text + " High Score: " + highScoreText.text);
    }
}
