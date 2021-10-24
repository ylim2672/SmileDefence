using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class FireCtrl : MonoBehaviour
{
    public Transform FirePos;
    public GameObject bullet;
    public ParticleSystem particle;

    void Update()
    {
        //왼쪽 마우스를 누르면 총을 쏘고 파티클이 나옴
        if(Input.GetMouseButtonDown(0))
        {
            //버튼누를때는 실행 안함
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Fire();
                particle.Play();
            }
        }
    }

    void Fire()
    {
        CreateBullet();
    }

    void CreateBullet()
    {
        Instantiate(bullet, FirePos.position, FirePos.rotation);
        
    }
}
