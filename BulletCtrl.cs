using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // 글로벌 좌표계 기준으로 힘을 가하는 함수
        // rb.AddForce(Vector3.forward * 1000.0f);

        // 로컬 좌표계 기준으로 힘을 가하는 함수
        rb.AddRelativeForce(Vector3.forward * 1500.0f);
    }

    // 사용하지 않는 Update 함수 삭제하기
}
