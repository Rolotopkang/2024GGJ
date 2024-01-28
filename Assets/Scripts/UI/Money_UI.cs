using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Money_UI : MonoBehaviour
{
    public Image money_Image;
    public TMP_Text money_Limit_Text;

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
        //Debug.Log("���غ����ĵ��ʽ� " + GameData.GetInstance().Money_Spend_Current_Turn);
        //Debug.Log("����ȫ���ʽ� " + GameData.GetInstance().All_Money_Current_Turn);

        money_Limit_Text.text = "�ʽ����ޣ�" + GameData.GetInstance().money_Limit[GameData.GetInstance().finance_Level];
    }

}
