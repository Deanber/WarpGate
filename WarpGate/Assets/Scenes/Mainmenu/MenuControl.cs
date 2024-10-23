using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public GameObject UI;
    UIControl uic;
    GameObject[] uis;
    public GameObject server;
    void Start()
    {
        uic = UI.GetComponent<UIControl>();
        uis = uic.uis;
    }
    void Update()
    {

    }

    //按钮功能
    public void Campaign()
    {
        SceneManager.LoadScene("战役");
    }
    public void Multiplayer()
    {
        uis[1].SetActive(true);
        uis[0].SetActive(false);
    }
    public void Zomble()
    {
        uis[2].SetActive(true);
        uis[0].SetActive(false);
    }
    public void ArcadeMode()
    {
        uis[3].SetActive(true);
        uis[0].SetActive(false);
    }
    public void Operators()
    {
        uis[4].SetActive(true);
        uis[0].SetActive(false);
    }
    public void Weapons()
    {
        uis[5].SetActive(true);
        uis[0].SetActive(false);
    }
    public void Search()
    {
        uis[6].SetActive(true);
        uis[0].SetActive(false);
    }
    public void Personal()
    {
        uis[8].SetActive(true);
        uis[0].SetActive(false);
    }
    public void Settings()
    {
        uis[7].SetActive(true);
        uis[0].SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
