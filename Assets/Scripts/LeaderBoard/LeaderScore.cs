using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class LeaderScore : MonoBehaviour
{
    public Text highScoreText;
    public UnityEvent<string, int> submitScoreEvent;
 
    // Start is called before the first frame update
    void Start()
    {
        SubmitScore();
    }

    // private void LoadScore()
    // {
    //     float highscore = Mathf.Round(PlayerPrefs.GetFloat("HighScore", 0));
    //     highScoreText.text = highscore.ToString();
    // }

    public void SubmitScore()
    {
        float highscore = Mathf.Round(PlayerPrefs.GetFloat("HighScore", 0));
        highScoreText.text = highscore.ToString();
        string name = PlayerPrefs.GetString("Name", "Player");
        int highScoreInt = Mathf.RoundToInt(highscore); 

        if (submitScoreEvent != null)
        {
            submitScoreEvent.Invoke(name, highScoreInt);
        }
        else
        {
              Debug.Log("gagal push data");
        }
        // LoadScore();
    }

    // // Update is called once per frame
    // void Update()
    // {
    //      LoadScore();
    // }
}
