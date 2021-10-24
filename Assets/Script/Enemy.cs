using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    float BulletDamage = 10f;
    public Animator animator;
    public Transform ArrivedPoint;

    public Slider slider;
    //public GameObject Hpbar;

    public float Health = 50f;
    private float curHealth = 50f;

    // 충돌 했을 때 한번만 하트가 줄어들게 하기위해서
    public static bool check;
    // 죽었는지 살았는지 상태 체크
    bool state;

    private NavMeshAgent agent;

    //따라갈 플레이어
    GameObject target;

    //에너미와 플레이어의 거리
    float distance;

    //에너미와 플레이어의 범위 
    public float Range = 5f;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = (float)curHealth / (float)Health;
        animator = GetComponent<Animator>();
        check = true;
        state = true;

        target = GameObject.Find("BasicMale");

        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(agent.transform.position, target.transform.position);
        //z축이 -37보다 작을 떄가 에너미가 성(Castle)과 충돌했을 때임
        if (this.transform.position.z < -37f && check)
        {
            //에너미 삭제
            Destroy(gameObject);

            //성 체력 1씩 감소
            CastleHP.Hp--;
            check = false;
        }

        //범위보다 에너미가 더 가까워진다면
        if (distance < Range)
        {
            //에너미가 플레이어를 따라간다
            agent.SetDestination(target.transform.position);
        }

        slider.value = (float)curHealth / (float)Health;
    }

    public void TakeDamage(float damage)
    {
        curHealth -= damage;
        if (curHealth <= 0f)
        {
            animator.Play("Die", 0, 0);
            if (state)
            {
                //적이 죽을 때 마다 100코인 증가
                Coin.SetCoin(10);
                Score.SetScore(100);
                //코인이 포탑설치 가격과 같을 때
                if (Coin.GetCoin() == Coin.TurretCost)
                {
                    SoundScript.Inst.Explaning();
                }
                SoundScript.Inst.Die();
            }
            state = false;
            Destroy(gameObject, 1.3f);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            TakeDamage(BulletDamage);
        }
    }
}
