using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CastleHP : MonoBehaviour
{
    public static int Hp = 3;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    // Start is called before the first frame update
    void Start()
    {
        heart1.GetComponent<Image>().enabled = true;
        heart2.GetComponent<Image>().enabled = true;
        heart3.GetComponent<Image>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Hp == 2)
        {
            heart3.GetComponent<Image>().enabled = false;
        }

        if (Hp == 1)
        {
            heart2.GetComponent<Image>().enabled = false;
        }

        if (Hp == 0)
        {
            heart1.GetComponent<Image>().enabled = false;
            SceneManager.LoadScene("GameOver");
        }
    }
}
