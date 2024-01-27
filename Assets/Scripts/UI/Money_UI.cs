using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money_UI : MonoBehaviour
{
    public Image money_Image;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public void Init()
    {
        money_Image.fillAmount = 1f;
    }

    public void UpdateValue()
    {
        money_Image.fillAmount = (float)(GameData.GetInstance().All_Money_Current_Turn-GameData.GetInstance().Money_Spend_Current_Turn) / (float)GameData.GetInstance().All_Money_Current_Turn;
        Debug.Log("���غ����ĵ��ʽ� " + GameData.GetInstance().Money_Spend_Current_Turn);
        Debug.Log("����ȫ���ʽ� " + GameData.GetInstance().All_Money_Current_Turn);
    }

}
