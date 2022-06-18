using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public int coin = 0;
    public int currentStage = 0; // 0 = 3D 스테이지, 1~ = 2D 스테이지 단계
    void Start()
    {
        if (gameManager == null) gameManager = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    void SetStageText()
    {
        if (currentStage != 0)
        {
            GameObject.Find("Text_Stage").GetComponent<Text>().text = "Stage " + currentStage;
        }
    }
    void StageClear()
    {
        MenuControl_2D(1);
    }
    void GameOver()
    {
        MenuControl_2D(2);
    }
    void MenuControl_2D(int control)
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameObject.Find("Canvas").transform.Find("MenuPanel").gameObject.SetActive(true);
        if(control==1) GameObject.Find("MenuPanel").transform.Find("StageClear").gameObject.SetActive(true);
        else if(control==2) GameObject.Find("MenuPanel").transform.Find("GameOver").gameObject.SetActive(true);
        GameObject.Find("Button_BackTo3d").GetComponent<Button>().onClick.AddListener(BackTo3D);
    }
    void BackTo3D()
    {        
        SceneManager.LoadScene("3DMain");
        Time.timeScale = 1;
    }
}
