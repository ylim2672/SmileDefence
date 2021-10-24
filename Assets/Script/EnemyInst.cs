using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInst : MonoBehaviour
{
    public Transform startingPoint;
    public float EnemyInsTime = 5f;
    public GameObject enemyprefab;
    float time = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= EnemyInsTime)
        {

            Instantiate(enemyprefab, startingPoint.position, Quaternion.identity);
            time = 0f;
        }

    }
}
