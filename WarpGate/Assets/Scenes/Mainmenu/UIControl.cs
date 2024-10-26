using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIControl : MonoBehaviour
{
    public GameObject[] uis;
    void Start()
    {
        instan();
        uis[0].SetActive(true);
    }
    void Update()
    {
        esc();
    }
    void instan()
    {
        foreach (GameObject child in uis)
        {
            child.SetActive(false);
        }
    }
    void esc()
    {
        if (uis[0].activeInHierarchy == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                foreach (GameObject child in uis)
                {
                    child.SetActive(false);
                }
                uis[0].SetActive(true);
            }
        }
    }
}
