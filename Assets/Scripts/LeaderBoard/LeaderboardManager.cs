using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField]
    private List<TextMeshProUGUI> names;
    [SerializeField]
    private List<TextMeshProUGUI> scores;
    public GameObject LoadingPanel;
    public GameObject TunjukanPanel;

    private string publicLeadeboardKey = "b7fbe9d7374d4281c1650038e2edbf3189a3fe89e33abddbeba8fa20f4834e16"; 

    public void GetLeaderboard()
    {
        // Get leaderboard data from server
        LoadingPanel.SetActive(true);
        TunjukanPanel.SetActive(false);

        LeaderboardCreator.GetLeaderboard(publicLeadeboardKey, (msg) =>
        {
            for (int i = 0; i < names.Count; i++)
            {
                if (i < msg.Length)
                {
                    names[i].text = msg[i].Username;
                    scores[i].text = msg[i].Score.ToString();
                }
                else
                {
                    names[i].text = "";
                    scores[i].text = "";
                }
            }
            LoadingPanel.SetActive(false);
            TunjukanPanel.SetActive(true);
        },
        (error) =>
        {
            Debug.LogError("Failed to get leaderboard data: " + error);
        });
    }

    public void SetLeaderboardEntry(string username, int scores)
    {
        LeaderboardCreator.UploadNewEntry(publicLeadeboardKey, username, scores, (msg) =>
        {
            GetLeaderboard();
        },
        (error) =>
        {
            Debug.LogError("Failed to upload new leaderboard entry: " + error);
        });
    }

    // Start is called before the first frame update
    void Start()
    {
        // Optionally, you can call GetLeaderboard() here if you want to load leaderboard data on start
       GetLeaderboard();
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    public void MainMenuGame()
    {
        PlayerPrefs.SetInt("TutorMenu",4);
        SceneManager.LoadScene("MainMenu");
    }
}
