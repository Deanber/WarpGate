using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    CharacterController cc;
    Camera m_camera;
    conditions cc_condition;
    float vertical;
    float horizental;
    public float movespeed; //移速
    Vector3 movedir;
    //防止频繁创建vector3
    Vector3 camera_forward;
    Vector3 camera_right;
    public Vector3 gravity; //重力
    void Start()
    {
        m_camera = Camera.main;
        cc_condition = new conditions();
        cc_condition.serilized();
    }


    void Update()
    {
        GroundCheck();
        moving();

    }
    void GroundCheck()
    {
        //Physics.BoxCast();
    }
    void moving()
    {
        if (cc_condition.is_ground == true)
        {
            vertical = Input.GetAxis("Vertical");
            horizental = Input.GetAxis("Horizental");
            camera_forward = m_camera.transform.forward;
            camera_forward.y = 0;
            camera_right = m_camera.transform.right;
            camera_right.y = 0;
            movedir = (camera_forward * vertical + camera_right * horizental).normalized;
            cc.Move((movedir * movespeed + gravity) * Time.deltaTime);
        }
    }
    void Jump()
    {
        if (cc_condition.is_ground == true)
        {

        }
    }

}
class conditions
{
    public bool is_ground;//在地面上
    public bool is_jumping;//跳跃
    public bool is_crouch;//下蹲
    public bool is_slid;//滑铲
    public bool is_prone;//卧倒
    public void serilized()
    {
        is_ground = false;
        is_jumping = false;
        is_crouch = false;
        is_slid = false;
        is_prone = false;
    }
}
