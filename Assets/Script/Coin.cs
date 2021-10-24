using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    private static Coin Inst = null;

    public Text cointext;

    [SerializeField]
    private static int m_coin;

    public static int coin { get { return m_coin; } }

    public GameObject TurretIcon;

    public static int TurretCost = 30;
    private void Start()
    {
        Inst = this;
    }

    //가지고 있는 코인 갯수
    public static int GetCoin()
    {
        return m_coin;
    }

    //value만큼 더하기
    public static void SetCoin(int value)
    {
        m_coin += value;
        PlayerPrefs.SetInt("Coin", m_coin);
    }

    //value만큼 빼기
    public static void UseCoin(int value)
    {
        m_coin -= value;
        PlayerPrefs.SetInt("Coin", m_coin);
    }

    void Update()
    {
        if (PlayerPrefs.HasKey("Coin"))
            m_coin = PlayerPrefs.GetInt("Coin");
        cointext.text = "" + m_coin;

        //가지고 있는 코인의 갯수가 포탑 설치가격보다 클 때 포탑설치 안내문 띄우기
        if (PlayerPrefs.GetInt("Coin") >= TurretCost)
            TurretIcon.SetActive(true);


        if (PlayerPrefs.GetInt("Coin") < TurretCost)
        {
            TurretIcon.SetActive(false);
        }
    }
}
