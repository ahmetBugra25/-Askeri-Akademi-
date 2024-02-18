using UnityEngine;
using TMPro;
public class TimerButtonController : MonoBehaviour
{
    // Timer scriptine referans
    public Timer timerScript;
    public PlayerController playerScript;

    public GameObject healthBar, timer, puan, pano,finish,gameOver,menu;
    

    private void Start()
    {
        playerScript.GetComponent<PlayerController>().enabled=false;
       
    }


    // Butona bağlanacak fonksiyon
    public void StartTimerOnClick()
    {

        pano.SetActive(false);
        healthBar.SetActive(true);
        timer.SetActive(true);
        puan.SetActive(true);
        menu.SetActive(true);

        playerScript.GetComponent<PlayerController>().enabled = true;
        
        // Timer scriptindeki StartTimer fonksiyonunu çağır
        timerScript.StartTimer();
      
       
    }

   
}

