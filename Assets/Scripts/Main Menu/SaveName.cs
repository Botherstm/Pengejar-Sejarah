using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Tambahkan referensi ke TextMeshPro
using UnityEngine.SceneManagement;

public class SaveName : MonoBehaviour
{
    public TMP_InputField nameInputField; // Referensi ke TMP InputField
    // public GameObject namePanel;
    // Start is called before the first frame update
    void Start()
    {
        // Jika ada nama yang tersimpan sebelumnya, isi input field dengan nilai tersebut
        if (PlayerPrefs.HasKey("Name"))
        {
            nameInputField.text = PlayerPrefs.GetString("Name");
        }
    }

    // Fungsi untuk menyimpan nama
    public void SavePlayerName()
    {
        string playerName = nameInputField.text;
        PlayerPrefs.SetString("Name", playerName);
        PlayerPrefs.SetInt("TutorMenu",1);
        PlayerPrefs.Save(); // Simpan perubahan
        //  namePanel.SetActive(false);
        SceneManager.LoadScene("MainMenu");
       
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
