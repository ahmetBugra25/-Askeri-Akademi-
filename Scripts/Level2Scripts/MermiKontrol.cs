using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MermiKontrol : MonoBehaviour
{
    public TextMeshProUGUI puan;


    public GameObject finish;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            GameObject enemyObject = gameObject; // Çarpışan mermi objesini al
            string enemyTag = enemyObject.tag; // Düşmanın etiketini al

            if (enemyTag=="Enemy" || enemyTag == "Enemy1" || enemyTag == "Enemy2" ||
                enemyTag == "Enemy3"|| enemyTag == "Enemy4" || enemyTag == "Enemy5" ||
                enemyTag == "Enemy6"  || enemyTag == "Enemy7" || enemyTag == "Enemy8"  )
            {
                // Etikete göre sayacı artır
                // Örneğin, Enemy1, Enemy2 ve Enemy3 etiketlerine sahip düşmanlar için sayacı artırabilirsiniz
                SayacArtir();
            }

            // Çarpışan mermiyi yok et
            Destroy(enemyObject);
            // Kendi objeyi (düşman objesini) yok et
            Destroy(gameObject);
        }
    }

    void SayacArtir()
    {
        int eskiSayacDegeri;
        if (int.TryParse(puan.text, out eskiSayacDegeri))
        {
            int yeniSayacDegeri = eskiSayacDegeri + 1;
            puan.text = yeniSayacDegeri.ToString();

            // Sayaç 9 ise oyunu durdur ve finish canvas'i etkinleştir
            if (yeniSayacDegeri >= 9)
            {

                Time.timeScale = 0f; // Oyunu durdur
                Finish();
            }
        }
        else
        {
            Debug.LogError("Puan metni bir sayıya dönüştürülemedi: " + puan.text);
        }

    }

    public void Finish()
    {
        
        finish.SetActive(true); // Finish canvas'i etkinleştir
    }
}

