using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))] // 해당 컴포넌트를 삭제하지 못하도록 처리
public class FireCtrl : MonoBehaviour
{
    public Transform firePos;
    public GameObject bulletPrefab;
    public MeshRenderer muzzleFlash;

    // [System.NonSerialized]
    [HideInInspector]   // 인스펙터에서 숨김처리
    public new AudioSource audio;   // new키워드 : Component.audio와는 상관없이 내가 만든 변수 이름을 뜻함
    public AudioClip fireSfx;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        muzzleFlash = firePos.GetComponentInChildren<MeshRenderer>();
        muzzleFlash.enabled = false;
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

        StartCoroutine(ShowMuzzleFlash());
    }

    IEnumerator ShowMuzzleFlash()
    {
        Vector2 offset = new Vector2(Random.Range(0,2), Random.Range(0,2)) * 0.5f;
        muzzleFlash.material.mainTextureOffset = offset;

        Quaternion rot = Quaternion.Euler(Vector3.forward * Random.Range(0, 360));
        muzzleFlash.transform.localRotation = rot;

        muzzleFlash.transform.localScale = Vector3.one * Random.Range(1.0f, 3.0f);

        muzzleFlash.enabled = true;
        yield return new WaitForSeconds(0.2f);
        muzzleFlash.enabled = false;
    }
}
