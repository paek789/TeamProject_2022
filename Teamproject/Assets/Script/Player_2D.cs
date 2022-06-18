using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_2D : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    Rigidbody rigid;
    int hp =5;
    bool isInvincible = false;
    bool onFootHold;
    public float unBeatTime = 10; //무적시간
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        //GameManager.gameManager.SetStageText(); public 으로 선언된 함수에만 사용가능
        GameManager.gameManager.SendMessage("SetStageText");
        GameManager.gameManager.LoadMap(true);
        GameObject.Find("Text_Coin").GetComponent<Text>().text = "" + GameManager.gameManager.coin;
        GameObject.Find("Text_Bullet").GetComponent<Text>().text = "" + GameManager.gameManager.bullet;        
    }
    // Update is called once per frame
    void Update()
    {

        if (GameManager.gameManager.currentStage != 3) transform.position += new Vector3(2.5f * Time.deltaTime, 0, 0);
        KeyboardInput();        
    }    
    void KeyboardInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onFootHold && GameManager.gameManager.currentStage!=3)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up* 11, ForceMode.Impulse);            
        }      
        if (Input.GetKeyDown(KeyCode.A)&&GameManager.gameManager.bullet>0)
        {
            Instantiate(bullet, GameObject.Find("BulletStart").GetComponent<Transform>().position, Quaternion.identity);
            GameManager.gameManager.bullet--;
            GameObject.Find("Text_Bullet").GetComponent<Text>().text = "" + GameManager.gameManager.bullet;
        }
        if (GameManager.gameManager.currentStage == 3)
        {
            if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x >3.5f)
            {
                transform.Translate(new Vector3(-0.01f, 0, 0));
            }
            if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 13f)
            {
                transform.Translate(new Vector3(0.01f, 0, 0));
            }
            if (Input.GetKey(KeyCode.UpArrow) && transform.position.y<7.5f)
            {
                transform.Translate(new Vector3(0, 0.01f, 0));
            }
            if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > 0)
            {
                transform.Translate(new Vector3(0, -0.01f, 0));
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {    
        if(other.tag == "Bullet_Enemy")
        {
            Destroy(other.gameObject);
            hp--;
            if (hp == 0) GameManager.gameManager.SendMessage("GameOver");
            StartCoroutine("OnDamage", other.transform.position);
        }
        if(other.tag == "Monster" && !isInvincible)
        {                   
            hp--;
            if (hp == 0) GameManager.gameManager.SendMessage("GameOver");            
            StartCoroutine("OnDamage", other.transform.position);            
        }
        if (other.tag == "Coin"||other.tag == "BigCoin")
        {
            if(other.tag == "Coin") GameManager.gameManager.coin++;
            else if (other.tag == "BigCoin") GameManager.gameManager.coin+=5;
            GameObject.Find("Text_Coin").GetComponent<Text>().text = "" + GameManager.gameManager.coin;
            Destroy(other.gameObject);
        }
        if (other.tag == "Clear")
        {
            GameManager.gameManager.SendMessage("StageClear");
        }
        if( other.tag == "beam")
        {
            hp--;
            if (hp == 0) GameManager.gameManager.SendMessage("GameOver");
            StartCoroutine("OnDamage", other.transform.position);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "FootHold") onFootHold = true;
        else
        {
            onFootHold = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "FootHold") onFootHold = false;
    }
    IEnumerator OnDamage(Vector3 monsterPosition)
    {
        GameObject.Find("Hearts").transform.GetChild(hp).gameObject.SetActive(false);
        isInvincible = true;
        GetComponent<SpriteRenderer>().material.color = Color.red;
        GameObject.Find("Canvas").transform.Find("DamagedPanel").gameObject.SetActive(true);
        if (GameManager.gameManager.currentStage != 3)
        {
            if (transform.position.x >= monsterPosition.x) GetComponent<Rigidbody>().AddForce(new Vector3(1f, 0.1f, 0) * 7, ForceMode.Impulse);
            else GetComponent<Rigidbody>().AddForce(new Vector3(-0.3f, 0.1f, 0) * 7, ForceMode.Impulse);
        }
        yield return new WaitForSeconds(0.1f);

        
        GetComponent<SpriteRenderer>().material.color = Color.white;
        GameObject.Find("Canvas").transform.Find("DamagedPanel").gameObject.SetActive(false);

        yield return new WaitForSeconds(0.5f);
        isInvincible = false;
    }
    void rigidGravity(bool isGravity)
    {
        rigid.useGravity = isGravity;
    }


    /*
    void OnDamaged(Vector3 tartgetPos)
    {
        int dirc = transform.position.x-tartgetPos.x > 0 ? 1 : -1; 
        rigid.AddForce(new Vector3(dirc,1)*7, ForceMode.Impulse);
        Invoke("OffDamaged",2);
        hp -= 1;
    }

    void OffDamaged()
    { 
        //gameObject.layer = 10;

        //spriteRenderer.color = new Color(1,1,1,1);
    }
    */
}
