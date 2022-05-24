using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //private static GameManager mgr;
    public Text aCoinText;
    public int aCoin;
    public int bCoin;
    public int cCoin;
    public int dCoin;
    private int Life;
    public GameObject p;
    // Start is called before the first frame update
    void Start()
    {
        aCoin = 0;
        bCoin = 0;
        cCoin = 0;
        dCoin = 0;
        Life = p.GetComponent<Player_2D>().pLife;
    }
    /*public static GameManager getGameManager() {
        if (mgr == null){
            mgr = new GameManager();
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        Life = p.GetComponent<Player_2D>().pLife;
        if(Life <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        
            SceneManager.LoadScene("GameOver");
        
    }

}
