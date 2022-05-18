using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_2D : MonoBehaviour
{
    Rigidbody rigid;
    [SerializeField]
    GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(1f * Time.deltaTime, 0, 0);
        KeyboardInput();
    }
    void KeyboardInput()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // 점프
        {
            rigid.AddForce(Vector3.up* 200, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.A)) // 총알 발사
        {
            Instantiate(bullet,new Vector3(transform.position.x+0.5f,transform.position.y,transform.position.z) , Quaternion.identity);
        }
    }
}
