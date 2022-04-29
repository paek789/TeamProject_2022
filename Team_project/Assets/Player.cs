using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float hAxis,vAxis;
    bool eDown;
    [SerializeField]
    float speed;
    [SerializeField]
    Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        Move();
        eDown = Input.GetKeyDown(KeyCode.E);
    }
    void Move()
    {
        transform.position += new Vector3(hAxis, 0, vAxis).normalized * speed * Time.deltaTime;
        //transform.rotation = Quaternion.Euler(mainCamera.transform.rotation.x, 0, mainCamera.transform.rotation.z);
        transform.LookAt(mainCamera.transform);
    }
}
