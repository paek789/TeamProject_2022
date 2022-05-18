using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(6f * Time.deltaTime, 0, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
    private void OnBecameInvisible() // 카메라에 보이지않으면 Destory
    {
        Destroy(gameObject);
    }
}
