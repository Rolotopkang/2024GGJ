using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class Profession_UI : MonoBehaviour
{
    public Enums.Professions type;
    public int level = 1;
    public bool upgrade_Available = false;

    [Header("产出")]
    public int output_Value_Per_Unit = 2; //单位产出
    public int current_Output_Value = 0; //下回合产出
    public int happiness_output_Value_Per_Unit = 1; //单位幸福度产出
    public int current_Happiness_Output_Value = 0; //下回合幸福度产出

    [Header("消耗")]
    public int supplies_Consume = 1; //物资消耗
    public float supplies_Consume_Fix = 1f; //每回合物资消耗修正

    [Header("引用")]
    public Text resources_Value_Text;
    public Text output_Value_Text;
    public Text supplies_Consume_Text;
    public Text uprade_Consume_Text;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    //更新信息显示
    public void UpdateInfo()
    {
        UpdateUpgradeStatu();

        switch (type)
        {
            case Enums.Professions.Industry:
                {
                    resources_Value_Text.text = "物资："+ GameData.GetInstance().Supplies.ToString();
                    output_Value_Text.text = current_Output_Value.ToString() + " 物资" + current_Happiness_Output_Value.ToString() + " 幸福";
                }
                break;
            case Enums.Professions.Science:
                {
                    resources_Value_Text.text = "科研：" + GameData.GetInstance().Science_Point.ToString();
                    output_Value_Text.text = current_Output_Value.ToString() + " 科研" + current_Happiness_Output_Value.ToString() + " 幸福";
                }
                break;
            case Enums.Professions.Finance:
                {
                    resources_Value_Text.text = "资金：" + GameData.GetInstance().Money.ToString();
                    output_Value_Text.text = current_Output_Value.ToString() + " 资金" + current_Happiness_Output_Value.ToString() + " 幸福";
                }
                break;
        }

        supplies_Consume_Text.text = ((int)(supplies_Consume* supplies_Consume_Fix)).ToString();

        uprade_Consume_Text.text = GameData.GetInstance().upgrade_Required_Point_List[level - 1].ToString();
    }


    public void Invest_1()
    {
        UpdateInvest(1);
    }

    public void Invest_10()
    {
        UpdateInvest(10);
    }

    public void Invest_N1()
    {
        UpdateInvest(-1);
    }

    public void Invest_N10()
    {
        UpdateInvest(-10);
    }


    //投资更新
    public void UpdateInvest(int value)
    {
        Debug.Log("投资 " + value);
        //增加投资
        if (value > 0)
        {
            //如果资金不足
            if (GameData.GetInstance().Money < value)
            {
                Debug.Log("资金不足 ");
                return;
            }
        }
        //减少投资
        else if ( value < 0)
        {
            //如果产出已经为0
            if (current_Output_Value <=0 || current_Happiness_Output_Value <= 0)
            {
                Debug.Log("无法再撤回投资");
                return;
            }
        }
        else
        {
            return;
        }

        current_Output_Value += value * output_Value_Per_Unit;
        current_Happiness_Output_Value += value * happiness_output_Value_Per_Unit;
        GameData.GetInstance().Money -= value;
        GameData.GetInstance().Money_Spend_Current_Turn += value;
        Global.GetInstance().UpdateAllProfession();

    }


    public void SuppliesConsume()
    {
        GameData.GetInstance().Supplies -= (int)(supplies_Consume * supplies_Consume_Fix);
    }



    public void ResetData()
    {
        current_Output_Value = 0;
        current_Happiness_Output_Value = 0;

        UpdateInfo();
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

    //升级
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
