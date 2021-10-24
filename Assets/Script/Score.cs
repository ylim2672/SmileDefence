using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private static Score Inst = null;

    public Text scoretext;

    [SerializeField]
    private static int m_score;

    public static int score { get { return m_score; } }
    private void Start()
    {
        Inst = this;
    }

    //가지고 있는 코인 갯수
    public static int GetScore()
    {
        return m_score;
    }

    //value만큼 더하기
    public static void SetScore(int value)
    {
        m_score += value;
        PlayerPrefs.SetInt("Score", m_score);
    }

    void Update()
    {
        if (PlayerPrefs.HasKey("Score"))
            m_score = PlayerPrefs.GetInt("Score");
        scoretext.text = "" + m_score;
    }
}
