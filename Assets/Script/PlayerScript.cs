using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PlayerScript : MonoBehaviour
{
    public Animator animator;

    private float h;
    private float v;

    private Transform tr;
    public float moveSpeed = 10.0f;
    public float rotSpeed = 100.0f;
    public GameObject Turret;

    public float Health = 100f;
    private float curHealth = 100f;
    static float EnemyDamage = 20f;

    void Start()
    {
        tr = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        PlayerPrefs.SetInt("Coin", 0);
    }

    // Update is called once per frame
    void Update()
    {
        //스페이스바 누르면 점프
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.Play("Jump_AR", 0, 0);
        }

        //왼쪽 마우스 누르면 총쏘기
        if (Input.GetMouseButtonDown(0))
        {
            //버튼누를때는 실행 안함
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                animator.Play("ShootSingleshot_AR", 0, 0);
                SoundScript.Inst.Shooting();
            }
        }

        //오른쪽 마우스 누르면 포탑 설치
        if (Input.GetMouseButtonDown(1))
        {
            if(PlayerPrefs.GetInt("Coin") >= Coin.TurretCost)
            {
                //포탑 설치 소리
                SoundScript.Inst.SetTurret();
                Instantiate(Turret, this.transform.position, this.transform.rotation);
                Coin.UseCoin(Coin.TurretCost);
            }
        }

        Move();
        Rotate();
    }
    //움직임
    private void Move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        animator.SetFloat("h", h);
        animator.SetFloat("v", v);

        Vector3 moveDir = ((Vector3.forward * v) + (Vector3.right * h)).normalized;

        tr.Translate(moveSpeed * moveDir * Time.deltaTime, Space.Self);
    }

    //회전
    private void Rotate()
    {

        tr.Rotate(Vector3.up * Input.GetAxis("Mouse X") * rotSpeed * Time.deltaTime, Space.Self);
    }

    //충돌 체크
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Water")
        {
            SceneManager.LoadScene("GameOver");
        }

        if (collision.collider.tag == "Enemy")
        {
            TakeDamage(EnemyDamage);
        }
    }

    //파라미터인 데미지 만큼 체력이 깎임
    private void TakeDamage(float damage)
    {
        curHealth -= damage;
        if (curHealth <= 0f)
        {
            animator.Play("Die_AR", 0, 0);
            StartCoroutine(Die());
        }
    }

    //1.3초 후에 죽어 게임오버씬으로 넘어감
    IEnumerator Die()
    {
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene("GameOver");
    }
}
