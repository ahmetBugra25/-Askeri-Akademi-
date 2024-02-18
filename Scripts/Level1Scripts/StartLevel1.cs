using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel1 : MonoBehaviour
{
    public CameraController camCont;
    public Mermi mermi;
    public SimpleShoot simple;
    public GameManagers gm;

    public GameObject pano,timer,puan,menu;

    // Start is called before the first frame update
    void Start()
    {
        camCont.GetComponent<CameraController>().enabled = false;
        mermi.GetComponent<Mermi>().enabled = false;
        simple.GetComponent<SimpleShoot>().enabled=false;
        gm.GetComponent<GameManagers>().enabled = false;
    }

    public void StartClicked()
    {
        pano.SetActive(false);
        timer.SetActive(true);
        puan.SetActive(true);
        menu.SetActive(true);
        camCont.GetComponent<CameraController>().enabled = true;
        mermi.GetComponent<Mermi>().enabled = true;
        simple.GetComponent<SimpleShoot>().enabled = true;
        gm.GetComponent<GameManagers>().enabled = true;
    }
}
