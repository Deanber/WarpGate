using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class camera : MonoBehaviour
{
    //手臂相机同步
    public GameObject cam;
    public GameObject arm;
    public float movespeed;

    //相机移动
    [Header("鼠标设置")]
    public float MouseXspeed;
    public float MouseYspeed;
    float mousex;
    float mousey;
    Vector2 MouseLook;
    float minmousey = -45;
    float maxmousey = 45;

    void Update()
    {
        Mouse();
        arm.transform.localRotation = Quaternion.Lerp(arm.transform.localRotation, cam.transform.localRotation, movespeed * Time.deltaTime * 20);
    }

    void Mouse()
    {
        mousex = Input.GetAxisRaw("Mouse X");
        mousey = -1 * Input.GetAxisRaw("Mouse Y");
        MouseLook.y += mousey * Time.deltaTime * MouseYspeed * 50f;
        MouseLook.y = math.clamp(MouseLook.y, minmousey, maxmousey);
        MouseLook.x += mousex * Time.deltaTime * MouseXspeed * 50f;
        cam.transform.localRotation = Quaternion.Euler(MouseLook.y, MouseLook.x, 0);
    }
}
