using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Thirdtofirst : MonoBehaviour
{
    public GameObject arm;
    public GameObject first;
    public GameObject third;
    public float rotatespeed;
    void Update()
    {
        Quaternion target = Quaternion.Euler(0, arm.transform.localEulerAngles.y, 0);
        third.transform.position = new Vector3(first.transform.position.x, 0, first.transform.position.z);
        third.transform.rotation = target;
    }
}
