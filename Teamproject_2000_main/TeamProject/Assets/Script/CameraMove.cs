using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    void Start()
    {

    }
    void Update()
    {
        transform.position = new Vector3(GameObject.Find("Player").GetComponent<Transform>().position.x + 7.5f, transform.position.y, transform.position.z);
    }
    void CameraShake()
    {

    }
}
