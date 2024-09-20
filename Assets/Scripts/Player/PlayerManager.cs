using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static bool gameStart;
    public static bool gameOver;
    public static bool Over;


    public static bool stoprun;
    public GameObject stopPanel;
    public GameObject stopButton;
    public GameObject confrimMenu;
    public GameObject confrimQuit;



    public static bool gamePause;
    public GameObject gameOverPanel;
    public GameObject gamePausePanel;
    public static bool isGameStarted;
    public GameObject startingText;
    public static int numberOfCoins = 0;
    public static int Coin;
    public static int CoinBaru;
    public Text coinsText;
    public Animator animator;
    public Animator animator2;
    //info neh

    public static bool info;


    public static bool infopaleo;
    public GameObject InfoPaleoPanel;
    public GameObject InfoPaleoOkButton;
    public AudioSource paleoAudio;

    public static bool infoMeso;
    public GameObject InfoMesoPanel;
    public GameObject InfoMesoOkButton;
    public AudioSource mesoAudio;

    public static bool infoNeo;
    public GameObject InfoNeoPanel;
    public GameObject InfoNeoOkButton;
    public AudioSource neoAudio;

    public static bool infomega;
    public GameObject InfomegaPanel;
    public GameObject InfoMegaOkButton;
    public AudioSource megaAudio;

    public static bool infologam;
    public GameObject InfologamPanel;
    public GameObject InfoLogamOkButton;
    public AudioSource logamAudio;
    // Start is called before the first frame update
    void Start()
    {
        stoprun = false;
        Over = false;
        gameOver = false;
        info = false;
        infopaleo = false;
        infoMeso = false;
        infoNeo = false;
        infomega = false;
        infologam = false;
        gamePause = false;
        Time.timeScale = 1;
        isGameStarted = false;
        stopButton.SetActive(false);
        LoadCoinData();
        
    }

    // Update is called once per frame
    void Update()
    {
       if(infopaleo){
            PlaySoundAndShowButton("PaleoSound", InfoPaleoPanel, InfoPaleoOkButton);
            infopaleo = false;
        }
        if(infoMeso){
            PlaySoundAndShowButton("MezoSound", InfoMesoPanel, InfoMesoOkButton);
            infoMeso = false;
        }
        if(infoNeo){
            PlaySoundAndShowButton("NeoSound", InfoNeoPanel, InfoNeoOkButton);
            infoNeo = false;
        }
        if(infomega){
            PlaySoundAndShowButton("MegaSound", InfomegaPanel, InfoMegaOkButton);
            infomega = false;
        }
        if(infologam){
            PlaySoundAndShowButton("LogamSound", InfologamPanel, InfoLogamOkButton);
            infologam = false;
        }
        if(stoprun){
            stopPanel.SetActive(true);
            isGameStarted = false;
            Time.timeScale = 0;
        }
        if (gameOver)
        {
            stopButton.SetActive(false);
            TambahKoin();
            animator.SetBool("isOver", true);
            animator2.SetBool("isOver", true);
            gameOverPanel.SetActive(true);
            FindObjectOfType<AudioManager>().PlaySound("GameOver");
            FindObjectOfType<AudioManager>().StopSound("MainTheme");
            isGameStarted = false;
            Time.timeScale = 0;
            Over = true;
            gameOver = false;
            
        }
        coinsText.text = "Coin = " + numberOfCoins;
        if (gamePause)
        {
            stopButton.SetActive(false);
            gamePausePanel.SetActive(true);
            Time.timeScale = 0;
        }
        else if (!gamePause)
        {
            Time.timeScale = 1;
            gamePausePanel.SetActive(false);
        }
        if (SwipeManager.tap && !info && !Over && !gamePause)
        {
            stopButton.SetActive(true);
            isGameStarted = true;
            Destroy(startingText);
        }
    }
    IEnumerator ShowOkButtonAfterSound(string soundName, GameObject okButton)
    {
      
        FindObjectOfType<AudioManager>().StopSound("MainTheme");
        FindObjectOfType<AudioManager>().PlaySound(soundName);
        yield return new WaitWhile(() => FindObjectOfType<AudioManager>().IsPlaying(soundName));
        FindObjectOfType<AudioManager>().PlaySound("MainTheme");
    }

    void PlaySoundAndShowButton(string soundName, GameObject panel, GameObject okButton)
    {
        info = true;
        stopButton.SetActive(false);
        panel.SetActive(true);
        isGameStarted = false;
        Time.timeScale = 0;
        StartCoroutine(ShowOkButtonAfterSound(soundName, okButton));
    }


 
    void LoadCoinData()
    {
        Coin = PlayerPrefs.GetInt("Coin", 0);
    }
    public void TambahKoin()
    {
        CoinBaru = Coin + numberOfCoins;
        PlayerPrefs.SetInt("Coin", CoinBaru);
        PlayerPrefs.Save();
        
    }


    public void CloseInfoPaleo()
    {
        FindObjectOfType<AudioManager>().StopSound("PaleoSound");
        FindObjectOfType<AudioManager>().PlaySound("MainTheme");
        infopaleo = false;
        info = false;
        isGameStarted = true;
        InfoPaleoPanel.SetActive(false);
        stopButton.SetActive(true);
        Time.timeScale = 1;
        
    }
    public void CloseInfoMezo()
    {
        FindObjectOfType<AudioManager>().StopSound("MezoSound");
        FindObjectOfType<AudioManager>().PlaySound("MainTheme");
        info = false;
        isGameStarted = true;
        InfoMesoPanel.SetActive(false);
        stopButton.SetActive(true);
        Time.timeScale = 1;
    }
    public void CloseInfoNeo()
    {
        FindObjectOfType<AudioManager>().StopSound("NeoSound");
        FindObjectOfType<AudioManager>().PlaySound("MainTheme");
        info = false;
        isGameStarted = true;
        InfoNeoPanel.SetActive(false);
        stopButton.SetActive(true);
        Time.timeScale = 1;
    }
    public void CloseInfoMega()
    {
        FindObjectOfType<AudioManager>().StopSound("MegaSound");
        FindObjectOfType<AudioManager>().PlaySound("MainTheme");
        info = false;
        isGameStarted = true;
        InfomegaPanel.SetActive(false);
        stopButton.SetActive(true);
        Time.timeScale = 1;
    }
    public void CloseInfoLogam()
    {
        FindObjectOfType<AudioManager>().StopSound("LogamSound");
        FindObjectOfType<AudioManager>().PlaySound("MainTheme");
        info = false;
        isGameStarted = true;
        InfologamPanel.SetActive(false);
        stopButton.SetActive(true);
        Time.timeScale = 1;
    }



    //pauseButton
    public void stopOn()
    {
        stoprun = true;
        stopButton.SetActive(false);
    }

    public void stopOff()
    {
        stopButton.SetActive(true);
        stoprun = false;
        isGameStarted = true;
        stopPanel.SetActive(false);
        Time.timeScale = 1;
    }


    //menu
    public void Menuconfirm()
    {
        stopPanel.SetActive(false);
        confrimMenu.SetActive(true);
    }
    public void MenuconfirmNO()
    {
        stopPanel.SetActive(true);
        confrimMenu.SetActive(false);
    }
    public void MenuconfirmYES()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //quit
    public void Quitconfirm()
    {
        stopPanel.SetActive(false);
        confrimQuit.SetActive(true);
    }
    public void QuitconfirmNO()
    {
        stopPanel.SetActive(true);
        confrimQuit.SetActive(false);
    }
     public void QuitconfirmYES()
    {
        Application.Quit();
    }
}
