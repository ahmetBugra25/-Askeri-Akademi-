using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartGame : MonoBehaviour
{
    public Animator animator;
    public Rigidbody playerRigidbody; // Oyuncunun Rigidbody bileşeni
    public GameObject pano,menu,skor,menuCanvas,DevamBut;

    private bool gameStarted = false; // Oyunun başladığı kontrolü için bir bayrak

    private void Start()
    {
        Time.timeScale = 1f;
        // Start fonksiyonunda Rigidbody'yi etkisiz hale getir
        if (playerRigidbody != null)
        {
            playerRigidbody.isKinematic = true; // Etkisiz hale getir
        }

        animator.enabled = false;
    }

    public void StartAnimation()
    {
        if (!gameStarted)
        {
            // Oyun başladığında Rigidbody'yi tekrar etkinleştir
            if (playerRigidbody != null)
            {
                playerRigidbody.isKinematic = false; // Etkin hale getir
            }

            pano.SetActive(false);
            menu.SetActive(true);
            skor.SetActive(true);
            gameStarted = true;
            animator.enabled = true;
            
        }
    }
    public void MenuCanvasClicked()
    {
        menuCanvas.SetActive(true);
        
        Time.timeScale = 0f;
    }
    public void DevamEtButton()
    {
        menuCanvas.SetActive(false);
        
        Time.timeScale = 1f;

    }
}
