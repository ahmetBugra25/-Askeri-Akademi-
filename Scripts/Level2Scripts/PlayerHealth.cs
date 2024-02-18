using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    // Player'ın sağlık değeri
    public int health = 3;
    
    public Image health1, health2, health3, health4, health5;
    public GameObject healthBar, timer, puan, pano, finish, gameOver;
    public GameObject playerMesh;



    void Start()
    {
        health1.color = new Color32(98, 123, 98, 255);
        health2.color = new Color32(98, 123, 98, 255);
        health3.color = new Color32(98, 123, 98, 255);
        health4.color = new Color32(98, 123, 98, 255);
        health5.color = new Color32(98, 123, 98, 255);

    }


    // Diğer nesnelerle çarpıştığında çalışacak metod
    private void OnCollisionEnter(Collision collision)
    {

        // Çarpışan nesnenin "EnemyBullet" tag'ine sahip olup olmadığını kontrol et
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Debug.Log("carptı sana");

            // Can hakkı azalt
            health--;

            // Eğer can hakkı sıfır veya daha az ise, Player'ı yok et
            if (health <= 0)
            {
               
                Invoke("GameOver", 1f);
                
            }

            // Çarpışan mermiyi yok et
            Destroy(collision.gameObject);

            if (health == 4)
            {
                health5.color = new Color32(142, 34, 37, 255);
            }
            else if(health == 3)
            {
                health4.color = new Color32(142, 34, 37, 255);
            }
            else if (health == 2)
            {
                health3.color = new Color32(142, 34, 37, 255);
            }
            else if (health == 1)
            {
                health2.color = new Color32(142, 34, 37, 255);
            }
            else if (health == 0)
            {
                health1.color = new Color32(142, 34, 37, 255);
            }
        }
    }
    public void GameOver()
    {
        // Player meshini kaldır
        playerMesh.SetActive(false);
        healthBar.SetActive(false);
        timer.SetActive(false);
        puan.SetActive(false);
        gameOver.SetActive(true);
        Time.timeScale = 0f;

    }


}
