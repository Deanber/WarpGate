using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public List<GameObject> power1;
    public void Multiplayer()
    {
        power1[1].SetActive(true);
    }
    public void Zomble()
    {
        power1[2].SetActive(true);
    }
    public void Equiments()
    {

    }
    public void Search()
    {

    }
    public void Statistics()
    { }
    public void Settings()
    { }
    public void ExitGame()
    {
        Application.Quit();
    }
}
