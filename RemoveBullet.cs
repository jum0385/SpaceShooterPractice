using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    // 충돌 콜백함수 (Collision Call Back Function)
    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("BULLET"))
        {
            Destroy(coll.gameObject);
        }
    }
}

/*
void OnCollisionStay(Collision coll)    // 부딪혀있을 때 계속 발생
void OnCollisionExit(Collision coll)    // 떨어졌을 때 한번 발생
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