using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_UI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //��ʼ��Ϸ
    void StartGame()
    {
        Global.Instance.StartGame();
        gameObject.SetActive(false);
    }


    //�˳�
    private void Quit()
    {
        Application.Quit();
    }

}
