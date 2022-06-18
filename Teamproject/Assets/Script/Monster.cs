using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{    
    [SerializeField]
    int damage;
    [SerializeField]
    int hp;
    int currentHp;
    GameObject hpBarPrefab;
    GameObject hpBar;
    void Start()
    {
        currentHp = hp;
        MakeHpBar();
    }
    void Update()
    {
        HpBarSetPosition();

        if (currentHp <= 0)
        {
            Destroy(hpBar);
            Destroy(gameObject);
        }        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            currentHp -= 1;
            hpBar.GetComponent<HpBar>().HealthEffect(((float)currentHp / (float)hp));
            StopCoroutine("OnDamage");
            StartCoroutine("OnDamage");
        }
    }    
    IEnumerator OnDamage()
    {  
        Material material = GetComponent<SpriteRenderer>().material;
        material.color = Color.red;
        transform.position = new Vector3(transform.position.x + 0.05f, transform.position.y, transform.position.z);
        /* 몬스터 피격시 진동
        var oldPosition = transform.position; 
        int x = 10;
        while (x > 0)
        {
            transform.position = new Vector3(oldPosition.x + 0.2f, oldPosition.y, oldPosition.z);
            yield return new WaitForSeconds(0.01f);
            transform.position = new Vector3(oldPosition.x - 0.2f, oldPosition.y, oldPosition.z);
            yield return new WaitForSeconds(0.01f);
            x--;
        }
        transform.position = oldPosition;
        */
        yield return new WaitForSeconds(0.1f);
        material.color = Color.white;
    }
    void MakeHpBar()
    {    
        hpBarPrefab = Resources.Load("HpBar") as GameObject;
        hpBar = Instantiate(hpBarPrefab, GameObject.Find("HpBar_Parent").transform);
        hpBar.transform.localScale = new Vector3(GetComponent<Collider>().bounds.size.x*1.2f, 1f, 1f);
        hpBar.GetComponent<HpBar>().HealthEffect(((float)currentHp / (float)hp));
    }
    void HpBarSetPosition()
    {
        var hpBarPosition = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y - GetComponent<Collider>().bounds.size.y / 2, transform.position.z));
        hpBar.transform.position = hpBarPosition;
    }
}
