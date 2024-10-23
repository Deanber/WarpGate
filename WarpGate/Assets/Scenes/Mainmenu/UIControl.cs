using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIControl : MonoBehaviour
{
    public GameObject[] uis;
    void Start()
    {
        instan(uis);
        uis[0].SetActive(true);
    }
    void instan(GameObject[] childs)
    {
        foreach (GameObject child in uis)
        {
            child.SetActive(false);
        }
    }
}
