using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : Singleton<GameData>
{
    public int turn_Num = 1;//当前回合数

    public int initial_Supplies = 12;//初始物资
    public int initial_Money = 3;//初始物资

    [Header("资源")]
    public int Money = 0; //当前资金
    public int Money_Available = 0; //当前可配置资金
    public float Money_Available_Fix = 1f; //可配置资金乘数
    public int Supplies = 0;
    public int Science_Point = 0;
    public int Happiness = 0;
    public int Happiness_Goal = 100; //幸福度目标

    [Header("消耗")]
    public float supplies_Consume_Fix = 1f; //每回合物资消耗修正
    public int Money_Spend_Current_Turn = 0; //当前回合会消耗的资金
    public int All_Money_Current_Turn = 0; //当前回合全部可用资金

    [Header("产出修正")]
    public float Money_Output_Fix = 1f;
    public float Supplies_Output_Fix = 1f;
    public float Science_Point_Output_Fix = 1f;

    [Header("抽卡")]
    public int Draw_Card_Required_Money = 10; //抽卡所需资源
    public bool Draw_Card_Available = true;
    //public int Upgrade_Refresh_Num = 0; //可刷新次数

    [Header("升级")]
    public bool Upgrade_Available = true;

    [Header("事业等级")] 
    public int industry_Level = 0;
    public int science_Level = 0;
    public int finance_Level = 0;

    [Header("事业升级所需科技点列表")] 
    public List<int> upgrade_Required_Point_List = new List<int>();


    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public void Init()
    {
        Money = initial_Money;
        Supplies = initial_Supplies;
        Science_Point = 0;
        Happiness = 0;
        All_Money_Current_Turn = Money;
        Money_Spend_Current_Turn = 0;
        ResetOutputFix();
    }

    //重置产出修正值
    public void ResetOutputFix()
    {
        Supplies_Output_Fix = 1f;
        Science_Point_Output_Fix = 1f;
        Money_Output_Fix = 1f;
        supplies_Consume_Fix = 1f;
        Money_Available_Fix = 1f;
        Draw_Card_Available = true;
        Upgrade_Available = true;
    }


}
