using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver_UI : MonoBehaviour
{

    public TMP_Text title;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void ShowGameOverUI(bool flag)
    {
        gameObject.SetActive(true);
        if (flag)
        {
            Debug.Log("游戏胜利");
            title.text = "游戏胜利";
        }
        else
        {
            Debug.Log("游戏失败");
            title.text = "游戏结束";
        }
    }


    public void BackToMainMenu()
    {
        Global.GetInstance().BackToMainMenu();
    }

}
