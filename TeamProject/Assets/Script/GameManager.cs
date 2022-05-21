using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //private static GameManager mgr;
    public Text aCoinText;
    public int aCoin;
    public int bCoin;
    public int cCoin;
    public int dCoin;
    public int life;
    // Start is called before the first frame update
    void Start()
    {
        aCoin = 0;
        bCoin = 0;
        cCoin = 0;
        dCoin = 0;
        life = 3;
    }
    /*public static GameManager getGameManager() {
        if (mgr == null){
            mgr = new GameManager();
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }


}
