using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManagers : MonoBehaviour
{
    public static GameManagers instance;
    public Text scoreText;
    private int score = 0;

    public GameObject Gun;
    public GameObject MenuCanvas;
    public AudioSource SilahSesi;

    public Text timerText; // Zamanlay?c?y? g?sterecek metin nesnesi
    private float totalTime = 50f; // Toplam s?re
    private float currentTime = 0f; // Ge?en s?re
    private bool timerActive = true; // Zamanlay?c? aktif mi?


    public GameObject gameOverPano;
    public GameObject finishPano;

    public Text sonucText;

    void Zamanlayici()
    {
        if (timerActive) // Zamanlay?c? aktifse
        {
            currentTime += Time.deltaTime; // Ge?en s?reyi artt?r
            float remainingTime = totalTime - currentTime; // Kalan s?reyi hesapla

            if (remainingTime > 0) // Zaman bitti mi?
            {
                // Kalan s?reyi dakika ve saniye cinsine ?evir
                int seconds = Mathf.FloorToInt(remainingTime);

                // Metin nesnesine s?reyi g?ncelle
                timerText.text = seconds.ToString();


            }
            else // Zaman bitti
            {
                timerText.text = "0"; // Saya?? s?f?ra ayarla
                timerActive = false; // Zamanlay?c?y? durdur
                
            }
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Update()
    {
        Zamanlayici();
        DurumKontrol();

    }

    public void AddPoints(int points)
    {
        score += points;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    

    public void MenuCanvasVisibile()
    {
        SilahSesi.volume = 0;
        MenuCanvas.SetActive(true);
        Gun.SetActive(false);
        timerActive = false; 
        
    }

    public void DevamEtButton()
    {
        SilahSesi.volume = 50;
        MenuCanvas.SetActive(false);
        Gun.SetActive(true);
        timerActive = true;
    }

    public void AnaMenuyeDon()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void DurumKontrol()
    {

        if (score == 100)
        {
            SilahSesi.volume = 0;
            finishPano.SetActive(true);
            Gun.SetActive(false);

        }
        if (timerText.text == "0" && score > 70)
        {
            SilahSesi.volume = 0;
            finishPano.SetActive(true);
            Gun.SetActive(false);
            


        }
        
        if (timerText.text == "0" && score < 70)
        {
            SilahSesi.volume = 0;
            gameOverPano.SetActive(true);
            Gun.SetActive(false);
            


        }
    }

}
