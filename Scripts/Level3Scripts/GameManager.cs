using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton GameManager instance

    public int score = 0; // Oyuncunun puanı
    public TextMeshProUGUI scoreText; // TextMeshPro ile skoru gösterecek UI elementi

    public GameObject finishPano, gameOverPano;

    private void Awake()
    {
        // Singleton instance oluştur
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncreaseScore()
    {
        score++; // Puanı 1 arttır
        Debug.Log("Score: " + score);

        // Skoru TextMeshPro UI elementine aktar
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void DurumKontrol()
    {
        if (score >= 60)
        {
            
            finishPano.SetActive(true);
        }
        else
        {
            
            gameOverPano.SetActive(true);
        }
    }
}
