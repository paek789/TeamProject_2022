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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigid.AddForce(Vector3.up* 10, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.A))

        {
            Instantiate(bullet,new Vector3(transform.position.x+0.5f,transform.position.y,transform.position.z) , Quaternion.identity);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        
        if(collision.gameObject.tag == "Monster"){
            OnDamaged(collision.transform.position);  
        }

    }


    void OnDamaged(Vector3 tartgetPos){
        //gameObject.layer = 11;

        //spriteRenderer.color = new Color(1,1,1,0.4f); 

        int dirc = transform.position.x-tartgetPos.x > 0 ? 1 : -1; 
        rigid.AddForce(new Vector3(dirc,1)*7, ForceMode.Impulse);
        Invoke("OffDamaged",2);
    }

    void OffDamaged(){ 
        //gameObject.layer = 10;

        //spriteRenderer.color = new Color(1,1,1,1);
    }

}
