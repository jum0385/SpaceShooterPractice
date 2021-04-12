using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    public Transform firePos;
    public GameObject bulletPrefab;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void Fire()
    {
        // 동적으로 프리팹을 복제하는 함수
        // Instantiate( 생성할 객체, 위치 값, 회전 값 )
        Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        
    }
}
