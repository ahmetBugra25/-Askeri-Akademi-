using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bitis : MonoBehaviour
{

    public GameObject bayrak;

    public GameManager gm;
    public GameObject finish, gameOver;

    private void Start()
    {
        gm.GetComponent<GameManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {

        

        if (collision.gameObject == bayrak)
        {
            Debug.Log("sdflsdj");
            // Oyunu durdur
            Time.timeScale = 0f;
            if (gm.score >= 60)
            {
                finish.SetActive(true);
            }
            else
            {
                gameOver.SetActive(true);
            }
        }
    }
}
