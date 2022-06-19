using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    [SerializeField]
    Button buyBullet;
    [SerializeField]
    Button closeButton;
    [SerializeField]
    GameObject npcShop;
    // Start is called before the first frame update
    void Start()
    {
        buyBullet.onClick.AddListener(purchaseBullet);
        closeButton.onClick.AddListener(exitShop);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void shopUpdate()
    {
        GameObject.Find("myCoin").GetComponent<Text>().text = "" + GameManager.gameManager.coin;
        GameObject.Find("myBullet").GetComponent<Text>().text = "" + GameManager.gameManager.bullet;
    }
    void purchaseBullet()
    {
        if (GameManager.gameManager.coin < 1) return;
        GameManager.gameManager.coin--;
        GameManager.gameManager.bullet++;
        shopUpdate();
    }
    void exitShop()
    {
        npcShop.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked; // 마우스 커서 숨기기
        Cursor.visible = false;
    }

}
