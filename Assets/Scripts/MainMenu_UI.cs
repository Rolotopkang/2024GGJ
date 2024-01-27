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
    void StartGame()
    {
        Global.Instance.StartGame();
        gameObject.SetActive(false);
    }


    //退出
    private void Quit()
    {
        Application.Quit();
    }

}
