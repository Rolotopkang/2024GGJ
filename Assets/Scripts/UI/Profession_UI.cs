using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Profession_UI : MonoBehaviour
{
    public Enums.Professions type;
    public int level = 0;
    public bool upgrade_Available = false;

    public int output_Value_Per_Unit = 2; //单位产出
    public int happiness_output_Value_Per_Unit = 1; //单位幸福度产出

    public int current_Output_Value = 0; //下回合产出
    public int current_Happiness_Output_Value = 0; //下回合幸福度产出


    // Start is called before the first frame update
    void Start()
    {
        
    }

    //投资更新
    public void UpdateInvest(int value)
    {
        //增加投资
        if (value > 0)
        {
            //如果资金不足
            if (GameData.GetInstance().Money < value)
            {
                return;
            }
        }
        //减少投资
        else if ( value < 0)
        {
            //如果产出已经为0
            if (current_Output_Value <=0 || current_Happiness_Output_Value <= 0)
            {
                return;
            }
        }
        else
        {
            return;
        }

        current_Output_Value += value * output_Value_Per_Unit;
        current_Happiness_Output_Value += value * happiness_output_Value_Per_Unit;
        
    }

    public void ResetData()
    {
        current_Output_Value = 0;
        current_Happiness_Output_Value = 0;

        UpdateUpgradeStatu();
    }

    //更新升级状态
    private void UpdateUpgradeStatu()
    {
        if (GameData.GetInstance().Science_Point >= GameData.GetInstance().upgrade_Required_Point_List[level - 1])
        {
            upgrade_Available = true;
        }
        else
        {
            upgrade_Available = false;
        }
    }

    public void Upgrade()
    {
        GameData.GetInstance().Science_Point -= level * GameData.GetInstance().upgrade_Required_Point_List[level - 1];
        level += 1;
        
        switch (type)
        {
            case Enums.Professions.Industry:
                {
                    GameData.GetInstance().industry_Level = level;
                }
                break;
            case Enums.Professions.Science:
                {
                    GameData.GetInstance().science_Level = level;
                }
                break;
            case Enums.Professions.Finance:
                {
                    GameData.GetInstance().finance_Level = level;
                }
                break;
        }
    }

}
