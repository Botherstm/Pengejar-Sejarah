using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTutor : MonoBehaviour
{
    public GameObject namePanel;
    public GameObject TutorMenuPanel;
    public GameObject BermainMenuPanel;
    public GameObject KarakterMenuPanel;
    public GameObject LeaderboardMenuPanel;
    // Start is called before the first frame update
    void Start()
    {
        // PlayerPrefs.SetInt("TutorMenu",0);
        // PlayerPrefs.SetInt("TutorDone",0);
        cekTutor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void cekTutor(){

        int TutorMenu = PlayerPrefs.GetInt("TutorMenu", 0);
        int TutorDone = PlayerPrefs.GetInt("TutorDone", 0);

        if(TutorDone == 0){
            if(TutorMenu == 0){
            namePanel.SetActive(true);
            }
            else if (TutorMenu == 1) {
                TutorMenuPanel.SetActive(true);
            }
            else if(TutorMenu == 2){
                KarakterMenuPanel.SetActive(true);
            }
            else if(TutorMenu == 3){
                LeaderboardMenuPanel.SetActive(true);
            }
            else if(TutorMenu == 4){
                BermainMenuPanel.SetActive(true);
            }
        }
    }
}
