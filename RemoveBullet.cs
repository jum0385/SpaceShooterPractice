using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    public GameObject sparkEffect;

    // 충돌 콜백함수 (Collision Call Back Function)
    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("BULLET"))
        {
            // 충돌 지점에 대한 정보를 추출
            ContactPoint cont = coll.GetContact(0);

            // 법선 벡터
            Vector3 normal = cont.normal;
            // 법선 벡터를 쿼터니언 타입으로 변환
            Quaternion rot = Quaternion.LookRotation(-normal);

            // 스파크 이펙트 발생(생성)
            GameObject spark = Instantiate(sparkEffect, cont.point, rot);
            Destroy(spark, 0.3f);

            Destroy(coll.gameObject);
        }
    }
}

/*
void OnCollisionEnter(Collision coll)   // 부딪혔을 때 1번 발생
void OnCollisionStay(Collision coll)    // 부딪혀있을 때 계속 발생
void OnCollisionExit(Collision coll)    // 떨어졌을 때 1번 발생
*/

/* Is Trigger 옵션이 체크됐을 경우 호출되는 콜백함수
void OnTriggerEnter(Collider coll)
void OnTriggerStay(Collider coll)
void OnTriggerExit(Collider coll)
*/

/*
AudioListener : 1
AudioSource : n
*/

/*  Quaternion 쿼터니언 (x, y, z, w)
유니티 안에서 사용하는 모든 각도는  Quaternion을 사용

오일러 회전 :   X축회전 -> Y축회전 -> Z축회전
                Gimbal Lock(짐벌 락) 발생 : 회전 각도 불확실

Quaternion.LookRotation() : 벡터를 쿼터니언 타입의 회전각으로 변환 (회전각을 모르는 경우)
Quaternion.Euler() : 회전각을 쿼터니언타입의 회전각으로 변환 (회전각을 알고 있는 경우)
*/