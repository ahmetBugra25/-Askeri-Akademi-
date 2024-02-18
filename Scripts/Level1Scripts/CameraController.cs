using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float hassasiyet = 2.0f; // Fare hassasiyeti
    public float minimumY = -90.0f; // Kameranýn minimum yönü
    public float maksimumY = 90.0f; // Kameranýn maksimum yönü

    float rotasyonY = 0.0f; // Y eksenindeki rotasyon miktarý

    void Update()
    {
        float hareketX = Input.GetAxis("Mouse X") * hassasiyet; // X eksenindeki fare hareketi
        float hareketY = Input.GetAxis("Mouse Y") * hassasiyet; // Y eksenindeki fare hareketi

        transform.Rotate(0, hareketX, 0); // Yatay (Y ekseninde) dönüþ

        rotasyonY -= hareketY; // Dikey (X ekseninde) dönüþ
        rotasyonY = Mathf.Clamp(rotasyonY, minimumY, maksimumY); // Dönüþ miktarýný sýnýrla

        transform.localEulerAngles = new Vector3(rotasyonY, transform.localEulerAngles.y, 0);
    }
}