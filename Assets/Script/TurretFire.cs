using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretFire : MonoBehaviour
{
    private bool targetLocked;
    
    private GameObject Target;
    public GameObject FirePos;
    public GameObject turretRotation;
    public GameObject Turretbullet;
    
    public ParticleSystem particle;

    float FireTimer;
    bool ShotReady;
    //생성된 뒤 포탑이 파괴 될 시간
    public float DestroyTurretTime = 15;
    // Start is called before the first frame update
    void Start()
    {
        FireTimer = 1f;
        ShotReady = true;
    }

    void Update()
    {
        //타겟이 안에들어오면
        if(Target != null)
        {
            if(targetLocked)
            {
                //포탑이 타겟을 봄
                turretRotation.transform.LookAt(Target.transform);
           
                //총 쏠 준비가 됐을 떄
                if(ShotReady)
                {
                    //총알 만듬
                    CreateBullet();
                }
            }
            //일정시간 이후에 포탑 삭제
            StartCoroutine(DestroyTurret());

        }
    }

    void CreateBullet()
    {
        //총알 생성
        Instantiate(Turretbullet, FirePos.transform.position, FirePos.transform.rotation);
        //파티클 생성
        particle.Play();
        ShotReady = false;
        //총쏘기
        StartCoroutine(Fire());
    }
    //10초 후에 포탑 삭제
    IEnumerator DestroyTurret()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
    //총알 쏘는 시간이 지난 이후에 총 쏠 준비됨
    IEnumerator Fire()
    {
        yield return new WaitForSeconds(FireTimer);
        ShotReady = true;
    }

    //범위 안에 적이 있으면 타겟을 적으로 지정하고 targetlocked를 참으로 바꿈
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Target = other.gameObject;
            targetLocked = true;
        }
    }
}
