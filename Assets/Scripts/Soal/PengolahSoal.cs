using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PengolahSoal : MonoBehaviour
{
    public TextAsset assetSoal;
    public TextAsset assetSoalPaleo;
    public TextAsset assetSoalMezo;
    public TextAsset assetSoalNeo;
    public TextAsset assetSoalMega;
    public TextAsset assetSoalLogam;
    public static bool soalPaleo;
    public static bool soalMezo;
    public static bool soalNeo;
    public static bool soalMega;
    public static bool soalLogam;
    private string[] soal;
    private string[,] soalBag;
    int indexSoal;
    int maxSoal;
    bool ambilSoal = true;
    char kunciJ;
    // Komponen UI
    public Text txtSoal;
    public Text txtOpsiA;
    public Text txtOpsiB;
    public Text txtOpsiC;
    public Text txtOpsiD;
    private float durasi;
    public float durasiPenilaian;
    public Animator animator;
    public Animator animator2;
    public GameObject panel;
    public Text textPenilaian;

    void Start()
    {
        durasi = durasiPenilaian;
        UpdateSoal();
    }

    private void UpdateSoal()
    {
        if (soalPaleo)
        {
            // Debug.Log("Memilih soalPaleo");
            soal = assetSoalPaleo.text.Split('#');
            soalPaleo = false;
        }
        else if (soalMezo)
        {
            // Debug.Log("Memilih soalMezo");
            soal = assetSoalMezo.text.Split('#');
            soalMezo = false; 
        }
        else if (soalNeo)
        {
            // Debug.Log("Memilih soalNeo");
            soal = assetSoalNeo.text.Split('#');
            soalNeo = false;
        }
        else if (soalMega)
        {
            // Debug.Log("Memilih soalMega");
            soal = assetSoalMega.text.Split('#');
            soalMega = false; 
        }
        else if (soalLogam)
        {
            // Debug.Log("Memilih soalLogam");
            soal = assetSoalLogam.text.Split('#');
            soalLogam = false;
        }
        else
        {
            // Debug.Log("Memilih soal default");
            soal = assetSoal.text.Split('#');
        }
        soalBag = new string[soal.Length, 6];
        maxSoal = soal.Length;
        OlahSoal();
        AcakSoal();
        ambilSoal = true;
        TampilkanSoal();
    }

    void OlahSoal()
    {
        for (int i = 0; i < soal.Length; i++)
        {
            string[] tempSoal = soal[i].Split('+');
            for (int j = 0; j < tempSoal.Length; j++)
            {
                soalBag[i, j] = tempSoal[j];
            }
        }
    }

    void AcakSoal()
    {
        System.Random rng = new System.Random();
        int n = soal.Length;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            for (int j = 0; j < soalBag.GetLength(1); j++)
            {
                string temp = soalBag[n, j];
                soalBag[n, j] = soalBag[k, j];
                soalBag[k, j] = temp;
            }
        }
    }

    private void TampilkanSoal()
    {  
        if (indexSoal < maxSoal)
        {
            if (ambilSoal)
            {
                txtSoal.text = soalBag[indexSoal, 0];
                txtOpsiA.text = soalBag[indexSoal, 1];
                txtOpsiB.text = soalBag[indexSoal, 2];
                txtOpsiC.text = soalBag[indexSoal, 3];
                txtOpsiD.text = soalBag[indexSoal, 4];
                kunciJ = soalBag[indexSoal, 5][0];
                ambilSoal = false;
            }
        }
        else
        {
            print("Soal Selesai!");
            // TODO: Tampilkan hasil penilaian
        }
    }

    public void Opsi(string opsiHuruf)
    {
        CheckJawaban(opsiHuruf[0]);
        if (indexSoal == maxSoal - 1)
        {
            // TODO: Tampilkan hasil penilaian
        }
        else
        {
            panel.SetActive(true);
        }

        indexSoal++;
        ambilSoal = true;
    }

    private void CheckJawaban(char huruf)
    {
        PlayerManager.gamePause = false;
        PlayerManager.gameOver = false;
        Time.timeScale = 1;
        string penilaian;
        if (kunciJ.Equals(huruf))
        {
            penilaian = "Benar!";
        }
        else
        {
            penilaian = "Salah!";
            PlayerManager.isGameStarted = false;
            PlayerManager.gameOver = true;
            PlayerManager.Over = true;
            PlayerManager.gamePause = false;
        }
        textPenilaian.text = penilaian;
    }

    void Update()
    {
        if (soalPaleo || soalMezo || soalNeo || soalMega || soalLogam)
        {
            UpdateSoal();
        }

        if (panel.activeSelf)
        {
            PlayerManager.gameStart = true;
            durasiPenilaian -= Time.deltaTime;
            if (durasiPenilaian <= 0)
            {
                panel.SetActive(false);
                durasiPenilaian = durasi;
                TampilkanSoal();
            }
        }
    }
}
