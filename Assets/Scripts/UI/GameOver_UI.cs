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
            Debug.Log("��Ϸʤ��");
            title.text = "��Ϸʤ��";
        }
        else
        {
            Debug.Log("��Ϸʧ��");
            title.text = "��Ϸ����";
        }
    }


    public void BackToMainMenu()
    {
        Global.GetInstance().BackToMainMenu();
    }

}
