
using Unity.Mathematics;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    //动画控制器
    public Animator anim;

    //移动控制器
    CharacterController cc;
    Camera m_camera;
    conditions cc_condition;
    float vertical;
    float horizental;

    //移速
    [Header("移动")]
    public float walkspeed = 4f;
    public float runningspeed = 8f;
    float movespeed;
    Vector3 movedir;

    //防止频繁创建vector3
    Vector3 camera_forward;
    Vector3 camera_right;

    //重力
    public Vector3 gravity;


    //地面检测
    [Header("地面检测")]
    public float raylength;
    public float landposition;
    public Color debugcolor;

    [Header("瞄准")]
    public Vector3 aimposition;
    public Vector3 aimrotation;




    void Start()
    {
        //锁定鼠标
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        m_camera = Camera.main;
        cc_condition = new conditions();
        cc_condition.serilized();
        cc = GetComponent<CharacterController>();
    }
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizental = Input.GetAxis("Horizontal");
        if (vertical != 0 || horizental != 0)
        {
            cc_condition.is_moving = true;
        }
        else
        {
            cc_condition.is_moving = false;
        }
        cc.Move(gravity * Time.deltaTime);//重力
        GroundCheck();
        moving();
        running();
        aimming();
    }


    void GroundCheck()
    {
        Ray ray = new Ray(transform.position, new Vector3(0, -1, 0));
        Physics.Raycast(ray, out RaycastHit hit, raylength);
        Debug.DrawRay(ray.origin, ray.direction, debugcolor);
        if (hit.collider.gameObject != null)
        {
            cc_condition.is_ground = true;
        }
    }
    void moving()
    {
        if (cc_condition.is_ground == true)
        {
            camera_forward = m_camera.transform.forward;
            camera_forward.y = 0;
            camera_right = m_camera.transform.right;
            camera_right.y = 0;
            movedir = (camera_forward * vertical + camera_right * horizental).normalized;
            cc.Move(movedir * movespeed * Time.deltaTime);
        }
    }
    void running()
    {
        if (cc_condition.is_ground == true)
        {
            if (Input.GetButton("Shift") == true && vertical > 0.1)
            {
                movespeed = runningspeed;
                cc_condition.is_running = true;
            }
            else
            {
                movespeed = walkspeed;
                cc_condition.is_running = false;
            }
        }
    }
    void Jump()
    {
        if (cc_condition.is_ground == true)
        {

        }
    }
    void aimming()
    {
        if (Input.GetButton("Fire2"))
        {

        }
    }


}
class conditions
{
    public bool is_moving;
    public bool is_ground;//在地面上

    public bool is_running;//跑
    public bool is_sprint;//冲刺
    public bool is_crouch;//下蹲
    public bool is_slid;//滑铲
    public bool is_prone;//卧倒
    public void serilized()
    {
        is_moving = false;
        is_ground = false;
        is_running = false;
        is_sprint = false;
        is_crouch = false;
        is_slid = false;
        is_prone = false;
    }
}
