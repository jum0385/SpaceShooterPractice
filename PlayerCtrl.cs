using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private float h;
    private float v;
    private float r;

    [Header("이동 및 회전 속도")]
    public float moveSpeed = 8.0f;
    public float turnSpeed = 200.0f;

    private Transform tr;
    private Animation anim;

    IEnumerator Start()
    {
        tr = GetComponent<Transform>();
        anim = GetComponent<Animation>();
        anim.Play("Idle");

        yield return new WaitForSeconds(0.3f);
    }

    // 델타타임 : Time.deltaTime
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        r = Input.GetAxis("Mouse X");

        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        tr.Translate(moveDir.normalized * Time.deltaTime * moveSpeed , Space.Self);
        tr.Rotate(Vector3.up * Time.deltaTime * turnSpeed * r);

        PlayerAnimation();
    }

    void PlayerAnimation()
    {
        if (v >= 0.1f)           // 전진
        {
            anim.CrossFade("RunF", 0.25f);
        }
        else if (v <= -0.1f)     // 후진
        {
            anim.CrossFade("RunB", 0.25f);
        }
        else if (h >= 0.1f)    // 오른쪽
        {
            anim.CrossFade("RunR", 0.25f);
        }
        else if (h <= -0.1f)    // 왼쪽
        {
            anim.CrossFade("RunL", 0.25f);
        }
        else                    // 움직임 X
        {
            anim.CrossFade("Idle", 0.1f);
        }
    }
}
