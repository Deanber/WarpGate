using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class body_head_mixed : MonoBehaviour
{
    public GameObject go_body_joint;
    public GameObject go_head_joint;
    public GameObject go_head;
    Transform body_joint;
    Transform head_joint;
    Transform head;
    Vector3 body_head_joint_relativeposition;

    void Start()
    {
        body_joint = go_body_joint.GetComponent<Transform>();
        head_joint = go_head_joint.GetComponent<Transform>();
        head = go_head.GetComponent<Transform>();
    }
    void Update()
    {
        body_head_joint_relativeposition = head_joint.position - body_joint.position;
        if (body_head_joint_relativeposition.magnitude > 0.01)
        {
            head.position -= body_head_joint_relativeposition;
        }
    }
}
