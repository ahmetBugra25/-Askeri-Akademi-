using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameManager : MonoBehaviour
{
    public void AnaMenuDon()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void HikayeGecis()
    {
        SceneManager.LoadScene("Hikaye");
    }
    public void OyunaBasla()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Ayarlar()
    {
        SceneManager.LoadScene("Ayarlar");
    }
    public void CikisYap()
    {
        Application.Quit();
    }

    public void SeviyeIkiGecis()
    {
        SceneManager.LoadScene("Level2");
    }
    public void SeviyeUcGecis()
    {
        SceneManager.LoadScene("Level3");
    }
}
