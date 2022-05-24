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
        if(other.gameObject.tag == "Monster"){
            other.gameObject.SetActive (false);
        }
        if (other.gameObject.tag == "Player") {
        }
        else  Destroy(gameObject);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}