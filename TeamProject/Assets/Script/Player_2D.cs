using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_2D : MonoBehaviour
{
    public GameObject gaggg;
    [SerializeField]
    GameObject bullet;
    int hp =5;
    bool isInvincible = false;
    bool onFootHold;
    // Start is called before the first frame update
    void Start()
    {
        //GameManager.gameManager.SetStageText(); public 으로 선언된 함수에만 사용가능
        GameManager.gameManager.SendMessage("SetStageText");
        GameObject.Find("Text_Coin").GetComponent<Text>().text = "" + GameManager.gameManager.coin;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(2.5f * Time.deltaTime, 0, 0);
        KeyboardInput();
    }
    void KeyboardInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onFootHold)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up* 10, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Instantiate(bullet, GameObject.Find("BulletStart").GetComponent<Transform>().position, Quaternion.identity);
        }
    }
    private void OnTriggerEnter(Collider other)
    {    
        if(other.tag == "Monster" && !isInvincible)
        {
            hp--;
            if (hp == 0) GameManager.gameManager.SendMessage("GameOver");
            StartCoroutine("OnDamage", other.transform.position);
        }
        if (other.tag == "Coin")
        {
            GameManager.gameManager.coin++;
            GameObject.Find("Text_Coin").GetComponent<Text>().text = "" + GameManager.gameManager.coin;
            Destroy(other.gameObject);
        }
        if (other.tag == "FootHold")
        {
            onFootHold = true;
        }
        if (other.tag == "Clear")
        {
            GameManager.gameManager.SendMessage("StageClear");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "FootHold")
        {
            onFootHold = false;
        }
    }
    IEnumerator OnDamage(Vector3 monsterPosition)
    {
        GameObject.Find("Hearts").transform.GetChild(hp).gameObject.SetActive(false);
        isInvincible = true;
        GetComponent<SpriteRenderer>().material.color = Color.red;
        GameObject.Find("Canvas").transform.Find("DamagedPanel").gameObject.SetActive(true);

        if (transform.position.x >= monsterPosition.x) GetComponent<Rigidbody>().AddForce(new Vector3(1f, 0.1f, 0) * 7, ForceMode.Impulse);
        else GetComponent<Rigidbody>().AddForce(new Vector3(-1f, 0.1f, 0) * 7, ForceMode.Impulse);

        yield return new WaitForSeconds(0.1f);

        isInvincible = false;
        GetComponent<SpriteRenderer>().material.color = Color.white;
        GameObject.Find("Canvas").transform.Find("DamagedPanel").gameObject.SetActive(false);
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
