using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    // Timer scriptine referans
    public Timer timerScript;
    public PlayerController playerScript;


    public float totalTime = 300f; // Toplam süre
    private float currentTime; // Geçen süre
    public TextMeshProUGUI timerText; // Zamanı göstermek için TextMeshPro

    public GameObject healthBar, timer, puan, pano, finish, gameOver,menuCanvas;

    private bool timerStarted = false; // Zamanlayıcının başlatılıp başlatılmadığını belirten bayrak

    void Start()
    {
        currentTime = totalTime;
        

    }

    void Update()
    {
        if (timerStarted && currentTime > 0f)
        {
            // Zamanı azalt
            currentTime -= Time.deltaTime;

            // Zamanı güncelle
            int seconds = Mathf.FloorToInt(currentTime);
            timerText.text = seconds.ToString();

            // Zaman bittiğinde oyunu kaybet
            if (currentTime <= 0f)
            {
                GameOver();
            }
        }

    }

    public void StartTimer()
    {
        timerStarted = true;
    }

    public void GameOver()
    {

        Time.timeScale = 0f;

        healthBar.SetActive(false);
        timer.SetActive(false);
        puan.SetActive(false);
        gameOver.SetActive(true);
        
    }
    public void MenuCanvasVisibile()
    {
        
        menuCanvas.SetActive(true);
        timerStarted = false;
        Time.timeScale = 0f;

    }

    public void DevamEtButton()
    {
        menuCanvas.SetActive(false);
        timerStarted = true;
        Time.timeScale = 1f;

    }
}
