using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_UI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //开始游戏
    public void StartGame()
    {
        Global.GetInstance().StartGame();
        gameObject.SetActive(false);
    }


    //退出
    public  void Quit()
    {
        Application.Quit();
    }

}
