using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject map;
    public static GameManager gameManager;
    public int coin;
    public int bullet;
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
        LoadMap(false);
        MenuControl_2D(1);
    }
    void GameOver()
    {
        LoadMap(false);
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
    public void LoadMap(bool setActive)
    {
        if(currentStage == 1)
        {
            GameObject.Find("Map").transform.Find("Map1").gameObject.SetActive(setActive);
            GameObject.Find("Player").GetComponent<Player_2D>().SendMessage("rigidGravity", true);
        }
        else if(currentStage == 2)
        {
            GameObject.Find("Map").transform.Find("Map2").gameObject.SetActive(setActive);
            GameObject.Find("Player").GetComponent<Player_2D>().SendMessage("rigidGravity", true);
        }
        else if(currentStage == 3)
        {
            GameObject.Find("Map").transform.Find("Map3").gameObject.SetActive(setActive);
            GameObject.Find("Player").GetComponent<Player_2D>().SendMessage("rigidGravity", false);
        }
    }
}
