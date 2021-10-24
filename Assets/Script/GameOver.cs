using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public Image GameOverImg;
    public Text scoretext;

    private int m_score;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey("Score"))
            m_score = PlayerPrefs.GetInt("Score");
        if(scoretext != null)
            scoretext.text = "Score : " + m_score;
    }
}
