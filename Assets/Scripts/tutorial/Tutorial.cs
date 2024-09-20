using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public int currentGambarIndex;
    public GameObject[] GambarModels;

    // Start is called before the first frame update
    void Start()
    {
        // Deactivate all Gambar models at the start
        foreach (GameObject gambar in GambarModels)
            gambar.gameObject.SetActive(false);
        // Set the initial Gambar model active
        currentGambarIndex = PlayerPrefs.GetInt("SelectedGambar", 0);
        GambarModels[currentGambarIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // You can add any update functionality if needed
    }
    public void MenuGame()
    {
        PlayerPrefs.SetInt("TutorMenu", 2);
        SceneManager.LoadScene("MainMenu");
    }

   public void NextGambar()
{
    GambarModels[currentGambarIndex].SetActive(false);

    // Increment the index and ensure it does not exceed the last image
    if (currentGambarIndex < GambarModels.Length - 1)
    {
        currentGambarIndex++;
        GambarModels[currentGambarIndex].SetActive(true);
        PlayerPrefs.SetInt("SelectedGambar", currentGambarIndex);
    }
    else
    {
        // Optionally, handle the case when the user tries to go beyond the last image
        Debug.Log("This is the last image. Cannot move forward.");
    }
}

public void PreviousGambar()
{
    GambarModels[currentGambarIndex].SetActive(false);

    // Decrement the index and ensure it does not go below zero
    if (currentGambarIndex > 0)
    {
        currentGambarIndex--;
        GambarModels[currentGambarIndex].SetActive(true);
        PlayerPrefs.SetInt("SelectedGambar", currentGambarIndex);
    }
    else
    {
        // Optionally, handle the case when the user tries to go before the first image
        Debug.Log("This is the first image. Cannot move backward.");
    }
}

}
