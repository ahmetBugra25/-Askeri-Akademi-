using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectController : MonoBehaviour
{

    
    private void OnCollisionEnter(Collision collision)
    {
        
        // Çarpışan nesne uçağa mı ait?
        if (collision.gameObject.CompareTag("Player"))
        {

            
            // Nesneyi yok etz
            Destroy(gameObject);

            // Puanı 1 arttır
            GameManager.instance.IncreaseScore();
            
        }
    }
}