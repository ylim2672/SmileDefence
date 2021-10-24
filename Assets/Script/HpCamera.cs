using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpCamera : MonoBehaviour
{
    Transform hpCamera;
    // Start is called before the first frame update
    void Start()
    {
        hpCamera = Camera.main.transform;
    }

    // Update is called once per frame
    // hp화면을 바라보게 만듬
    void LateUpdate()
    {
        transform.LookAt(transform.position + hpCamera.forward);
    }
}
