using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_UI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    public void UpgradeIndustry()
    {
        Global.GetInstance().Profession_List[0].Upgrade();
    }

    public void UpgradeScience()
    {
        Global.GetInstance().Profession_List[1].Upgrade();
    }

    public void UpgradeFinance()
    {
        Global.GetInstance().Profession_List[2].Upgrade();
    }


    public void DrawCard()
    {
        if (GameData.GetInstance().Money_Available > GameData.GetInstance().Draw_Card_Required_Money)
        {
            GameData.GetInstance().Money_Available -= GameData.GetInstance().Draw_Card_Required_Money;
            Debug.Log("抽卡");
        }
        else
        {
            Debug.Log("抽卡所需资金不足");
        }
    }

}
