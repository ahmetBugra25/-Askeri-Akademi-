using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mermi : MonoBehaviour
{
    //toplam kol 1x altgövde 1x üstgövde 2x bai 5x toplam hedef için 10x  5 hedef için toplam 50x
    // 50x=100 den x=2 bu durumda kol ve altgövde 2þer puan üstgövde 4 puan kafa 10 puan

    public int headShotPoints = 10;
    public int chestShotPoints = 4;
    public int chestShotPoints2 = 2;
    public int armShotPoints = 2;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Kafa"))
        {
            // Head shot, 20 points
            GameManagers.instance.AddPoints(headShotPoints);
            // Destroy the object the bullet collided with
            Destroy(collision.gameObject);
            // Destroy the bullet itself
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("UstGogus"))
        {
            // Head shot, 20 points
            GameManagers.instance.AddPoints(chestShotPoints);
            // Destroy the object the bullet collided with
            Destroy(collision.gameObject);
            // Destroy the bullet itself
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("AltGogus"))
        {
            // Head shot, 20 points
            GameManagers.instance.AddPoints(chestShotPoints2);
            // Destroy the object the bullet collided with
            Destroy(collision.gameObject);
            // Destroy the bullet itself
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Kol"))
        {
            // Head shot, 20 points
            GameManagers.instance.AddPoints(armShotPoints);
            // Destroy the object the bullet collided with
            Destroy(collision.gameObject);
            // Destroy the bullet itself
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Untagged"))
        {
            GameManagers.instance.AddPoints(0);
        }
    }

}


