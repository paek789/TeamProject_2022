using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Split_Bullet : MonoBehaviour
{
    void Update()
    {
        transform.LookAt(GameObject.Find("Player").GetComponent<Transform>().position);
        Vector3 targetVec = GameObject.Find("Player").GetComponent<Transform>().position - transform.position;
        transform.position += targetVec.normalized * Time.deltaTime;
    }
}
