using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public int currentPlayerIndex;
    public GameObject[] playerModels;
    public PlayerBlueprint[] players;
    public Button buyButton;
    public Button pilihButton;

    void Start()
    {
        foreach (PlayerBlueprint player in players)
        {
            if (player.price == 0)
            {
                player.isUnlocked = true;
            }
            else
            {
                player.isUnlocked = PlayerPrefs.GetInt(player.name, 0) == 1 ? true : false;
            }
        }
        currentPlayerIndex = PlayerPrefs.GetInt("SelectedPlayer", 0);
        foreach (GameObject player in playerModels)
            player.gameObject.SetActive(false);
        playerModels[currentPlayerIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    public void MenuGame()
    {
        PlayerPrefs.SetInt("TutorMenu", 3);
        SceneManager.LoadScene("MainMenu");
    }

    public void ChangeNext()
    {
        playerModels[currentPlayerIndex].SetActive(false);
        // Increment the index and wrap around if necessary
        currentPlayerIndex++;
        if (currentPlayerIndex >= playerModels.Length)
            currentPlayerIndex = 0;
        // Activate the new current player model
        playerModels[currentPlayerIndex].SetActive(true);
        PlayerBlueprint p = players[currentPlayerIndex];
        if (!p.isUnlocked)
        {
            return;
        }
        PlayerPrefs.SetInt("SelectedPlayer", currentPlayerIndex);
    }

    public void ChangePrevious()
    {
        playerModels[currentPlayerIndex].SetActive(false);
        // Decrement the index and wrap around if necessary
        currentPlayerIndex--;
        if (currentPlayerIndex < 0)
            currentPlayerIndex = playerModels.Length - 1;
        // Activate the new current player model
        playerModels[currentPlayerIndex].SetActive(true);
        PlayerBlueprint p = players[currentPlayerIndex];
        if (!p.isUnlocked)
        {
            return;
        }
        PlayerPrefs.SetInt("SelectedPlayer", currentPlayerIndex);
    }

    private void UpdateUI()
    {
        PlayerBlueprint p = players[currentPlayerIndex];
        if (p.isUnlocked)
        {
            buyButton.gameObject.SetActive(false);
            pilihButton.gameObject.SetActive(true);
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            pilihButton.gameObject.SetActive(false);
            Text buttonText = buyButton.GetComponentInChildren<Text>();
            if (buttonText != null)
            {
                buttonText.text = "Beli - " + p.price.ToString();
            }
            int playerCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
            buyButton.interactable = p.price <= playerCoins;
        }
    }

    public void BuyPlayer()
    {
        PlayerBlueprint p = players[currentPlayerIndex];
        PlayerPrefs.SetInt(p.name, 1); // Mark the player as unlocked
        PlayerPrefs.SetInt("SelectedPlayer", currentPlayerIndex);
        p.isUnlocked = true;
        PlayerPrefs.SetInt("NumberOfCoins", PlayerPrefs.GetInt("NumberOfCoins", 0) - p.price);
    }
}
