using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Button soundButton;    
    public Button muteButton;
    public Text highScoreText;
    public GameObject KeluarPanel;

    void Start()
    {
        LoadScore();
    }
    private void LoadScore()
    {
        highScoreText.text = Mathf.Round(PlayerPrefs.GetFloat("HighScore", 0)).ToString();
    }
    public void PlayGame()
    {
        PlayerPrefs.SetInt("TutorDone",1);
        SceneManager.LoadScene("Level");
    }
     public void LeaderBoardGame()
    {
        SceneManager.LoadScene("LeaderBoard");
    }
    public void KarakterGame()
    {
        SceneManager.LoadScene("Karakter");
    }
    public void TutorialGame()
    {
        SceneManager.LoadScene("Tutorial");
    }



    public void QuitGame()
    {
        Application.Quit();
    }
    public void KeluarPanelShow()
    {
        KeluarPanel.gameObject.SetActive(true);
    }
    public void KeluarPanelDontShow()
    {
        KeluarPanel.gameObject.SetActive(false);
    }

    public void Mute(){
        soundButton.gameObject.SetActive(false);
        muteButton.gameObject.SetActive(true);
        AudioListener.volume = 0;
    }
    public void Sound(){
         muteButton.gameObject.SetActive(false);
         soundButton.gameObject.SetActive(true);
        AudioListener.volume = 1;
    }

}
