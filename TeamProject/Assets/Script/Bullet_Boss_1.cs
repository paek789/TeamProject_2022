using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Boss_1 : MonoBehaviour // ÀÏ¹ÝÃÑ¾Ë
{
    void Update()
    {
        transform.position += new Vector3(-12f * Time.deltaTime, 0, 0);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
