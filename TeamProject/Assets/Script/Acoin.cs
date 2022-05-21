using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acoin : MonoBehaviour
{   
    GameManager mgr;
    Collider cols;
    // Start is called before the first frame update
    void Start()
    {
        cols = GetComponent<Collider>();
        mgr = GameObject.Find("gamemanager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other){
        mgr.aCoin++;
        mgr.aCoinText.text = "aCoin : " + mgr.aCoin;
        Destroy(gameObject);
    } 
}
