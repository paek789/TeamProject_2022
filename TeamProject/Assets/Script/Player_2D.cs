using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_2D : MonoBehaviour
{
    Rigidbody rigid; // 2D로 바꿈
    [SerializeField]
    GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>(); // 2D로 바꿈
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(1f * Time.deltaTime, 0, 0);
        KeyboardInput();
    }
    void KeyboardInput()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // ����
        {
            rigid.AddForce(Vector3.up* 10, ForceMode.Impulse); // Vector3에서 Vector2로 변경, ForceMode.Impulse 삭제함
        }
        if (Input.GetKeyDown(KeyCode.A)) // �Ѿ� �߻�
        {
            Instantiate(bullet,new Vector3(transform.position.x+0.5f,transform.position.y,transform.position.z) , Quaternion.identity);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        
        if(collision.gameObject.tag == "Monster"){
            OnDamaged(collision.transform.position); //현재 충돌한 오브젝트의 위치값을 넘겨줌  
        }

    }


    void OnDamaged(Vector3 tartgetPos){
        //gameObject.layer = 11; //playerDamaged Layer number가 11로 지정되어있음 

        //spriteRenderer.color = new Color(1,1,1,0.4f); //투명도를 0.4로 부여하여 지금이 무적시간으로 변경되었음을 보여줌

        //맞으면 튕겨나가는 모션
        int dirc = transform.position.x-tartgetPos.x > 0 ? 1 : -1; 
        //튕겨나가는 방향지정 -> 플레이어 위치(x) - 충돌한 오브젝트위치(x) > 0: 플레이어가 오브젝트를 기준으로 어디에 있었는지 판별
        //> 0이면 1(오른쪽으로 튕김) , <=0 이면 -1 (왼쪽으로 튕김)
        rigid.AddForce(new Vector3(dirc,1)*7, ForceMode.Impulse); // *7은 튕겨나가는 강도를 의미 
        Invoke("OffDamaged",2); //2초의 딜레이 (무적시간 2초)
    }

    void OffDamaged(){ //무적해제함수 
        //gameObject.layer = 10; //플레이어 레이어로 복귀함

        //spriteRenderer.color = new Color(1,1,1,1); //투명도를 1로 다시 되돌림 

    }


}
