using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalCoin : MonoBehaviour
{
    public Text TotalcoinsText;
    private int Coin;

    // Start is called before the first frame update
    void Start()
    {
        LoadCoinData();
    }

    // Update is called once per frame
    void LoadCoinData()
    {
        Coin = PlayerPrefs.GetInt("Coin", 0);
        // PlayerPrefs.SetInt("Coin", 0);
        TotalcoinsText.text = "Coins :" + Coin.ToString();
    }
    void Update()
    {

    }
}
