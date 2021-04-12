using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))] // 해당 컴포넌트를 삭제하지 못하도록 처리
public class FireCtrl : MonoBehaviour
{
    public Transform firePos;
    public GameObject bulletPrefab;

    // [System.NonSerialized]
    [HideInInspector]   // 인스펙터에서 숨김처리
    public new AudioSource audio;   // new키워드 : Component.audio와는 상관없이 내가 만든 변수 이름을 뜻함
    public AudioClip fireSfx;

    void Start()
    {
        audio = GetComponent<AudioSource>();
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
        
        // 총소리 발생
        /*  소리 중첩 불가
            audio.clip = fireSfx;
            audio.Play();
        */
        audio.PlayOneShot(fireSfx, 0.8f);   // 시스템 볼륨의 80%로 재생 // 사운드 중첩 가능
    }
}
