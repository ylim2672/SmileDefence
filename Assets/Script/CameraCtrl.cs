using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public Transform targetTr;
    public float dist = 10.0f;
    public float height = 3.0f;
    public float dampTrace = 20.0f;

    private Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();   
    }

    // Update is called once per frame
    void Update()
    {
        tr.position = Vector3.Lerp(tr.position, targetTr.position - (targetTr.forward * dist) + (targetTr.up * height),
            Time.deltaTime * dampTrace);

        tr.LookAt(targetTr.position + new Vector3(0, 1, 0));
    }
}
