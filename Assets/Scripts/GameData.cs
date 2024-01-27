using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : Singleton<GameData>
{
    public int turn_Num = 1;//当前回合数

    public int initial_Supplies = 3;//初始物资

    public int Money = 0; //当前可配置资金
    public int Supplies = 0;
    public int Science_Point = 0;
    public int Happiness = 0;
    public int Happiness_Goal = 100; //幸福度目标

    public int supplies_Consume = 1; //每回合物资消耗
    public float supplies_Consume_Fix = 1f; //每回合物资消耗修正

    //事业产出修正
    public float Money_Output_Fix = 1f;
    public float Supplies_Output_Fix = 1f;
    public float Science_Point_Output_Fix = 1f;

    //升级
    public bool Upgrade_Available = false;
    public int Upgrade_Refresh_Num = 0; //可刷新次数

    //事业等级
    public int industry_Level = 0;
    public int science_Level = 0;
    public int finance_Level = 0;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    //重置产出修正值
    public void ResetOutputFix()
    {
        Supplies_Output_Fix = 1f;
        Science_Point_Output_Fix = 1f;
        Money_Output_Fix = 1f;
    }


}
