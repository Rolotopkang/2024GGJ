using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class Profession_UI : MonoBehaviour
{
    public Enums.Professions type;
    public int level = 1;
    public bool upgrade_Available = false;

    public bool isLevel_One = false;

    [Header("产出")]
    public int output_Value_Per_Unit_initial = 2;
    public int base_Output = 1;
    public int output_Value_Per_Unit = 2; //单位产出
    public float current_Output_Value = 0; //下回合产出
    public int happiness_output_Value_Per_Unit = 1; //单位幸福度产出
    public int current_Happiness_Output_Value = 0; //下回合幸福度产出

    [Header("消耗")]
    public int supplies_Consume = 1; //物资消耗
    public float supplies_Consume_Fix = 1f; //每回合物资消耗修正

    [Header("回报率")]
    public int return_Rate = 0;

    [Header("引用")]
    public Text resources_Value_Text;
    public Text output_Value_Text;
    public Text supplies_Consume_Text;
    public Text uprade_Consume_Text;
    public TMP_Text return_Rate_Text;


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
                    resources_Value_Text.text = "物资：" + ((int)GameData.GetInstance().Supplies).ToString();
                    output_Value_Text.text = GetOutputValue().ToString() + " 物资" + current_Happiness_Output_Value.ToString() + " 幸福";
                }
                break;
            case Enums.Professions.Science:
                {
                    resources_Value_Text.text = "科研：" + ((int)GameData.GetInstance().Science_Point).ToString();
                    output_Value_Text.text = GetOutputValue().ToString() + " 科研" + current_Happiness_Output_Value.ToString() + " 幸福";
                }
                break;
            case Enums.Professions.Finance:
                {
                    resources_Value_Text.text = "资金：" + ((int)GameData.GetInstance().Money).ToString();
                    output_Value_Text.text = GetOutputValue().ToString() + " 资金" + current_Happiness_Output_Value.ToString() + " 幸福";
                }
                break;
        }

        supplies_Consume_Text.text = ((int)(supplies_Consume * supplies_Consume_Fix)).ToString();

        uprade_Consume_Text.text = GameData.GetInstance().upgrade_Required_Point_List[level - 1].ToString();
    }


    public int GetOutputValue()
    {
        int output_Value = (int)current_Output_Value + base_Output;
        return output_Value;
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
        else if (value < 0)
        {
            //如果产出已经为0
            if (current_Output_Value <= 0 || current_Happiness_Output_Value <= 0)
            {
                Debug.Log("无法再撤回投资");
                return;
            }
            if (GameData.GetInstance().Money - Mathf.Abs(value) < -1.1f)
            {
                Debug.Log("无法再撤回投资");
                return;
            }
        }
        else
        {
            return;
        }

        float fix = 1f;
        switch (type)
        {
            case Enums.Professions.Industry:
                {
                    fix = GameData.GetInstance().Supplies_Output_Fix;
                }
                break;
            case Enums.Professions.Science:
                {
                    fix = GameData.GetInstance().Science_Point_Output_Fix;
                }
                break;
            case Enums.Professions.Finance:
                {
                    fix = GameData.GetInstance().Money_Output_Fix;
                }
                break;
        }


        int output_Per_Unit = output_Value_Per_Unit;
        if (isLevel_One)
        {
            output_Per_Unit = output_Value_Per_Unit_initial;
        }

        current_Output_Value += value * output_Per_Unit * fix;

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
        isLevel_One = false;
        GenerateReturn_Rate();
        UpdateInfo();
    }

    //生产回报率
    private void GenerateReturn_Rate()
    {
        int base_num = 1;
        switch (type)
        {
            case Enums.Professions.Industry:
                {
                    base_num = GameData.GetInstance().industry_Return_Rate_Base_Num;
                }
                break;
            case Enums.Professions.Science:
                {
                    base_num = GameData.GetInstance().science_Return_Rate_Base_Num;
                }
                break;
            case Enums.Professions.Finance:
                {
                    base_num = GameData.GetInstance().finance_Return_Rate_Base_Num;
                }
                break;
        }
        return_Rate = Random.Range(-base_num, base_num);

        return_Rate_Text.text = "产出波动：" + return_Rate;
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
        if (GameData.GetInstance().Science_Point >= GameData.GetInstance().upgrade_Required_Point_List[level - 1])
        {
            GameData.GetInstance().Science_Point -= GameData.GetInstance().upgrade_Required_Point_List[level - 1];
            level += 1;

            switch (type)
            {
                case Enums.Professions.Industry:
                    {
                        GameData.GetInstance().industry_Level = level;
                        output_Value_Per_Unit = GameData.GetInstance().industry_OutPut[level - 1];
                        base_Output = GameData.GetInstance().industry_Base_OutPut[level - 1];
                        supplies_Consume = GameData.GetInstance().industry_Consume[level - 1];
                        GameData.GetInstance().industry_Return_Rate_Base_Num = GameData.GetInstance().return_Rate_Base[level - 1];
                    }
                    break;
                case Enums.Professions.Science:
                    {
                        GameData.GetInstance().science_Level = level;
                        output_Value_Per_Unit = GameData.GetInstance().science_OutPut[level - 1];
                        base_Output = GameData.GetInstance().science_Base_OutPut[level - 1];
                        supplies_Consume = GameData.GetInstance().science_Consume[level - 1];
                        GameData.GetInstance().science_Return_Rate_Base_Num = GameData.GetInstance().return_Rate_Base[level - 1];
                    }
                    break;
                case Enums.Professions.Finance:
                    {
                        GameData.GetInstance().finance_Level = level;
                        output_Value_Per_Unit = GameData.GetInstance().finance_OutPut[level - 1];
                        base_Output = GameData.GetInstance().finance_Base_OutPut[level - 1];
                        supplies_Consume = GameData.GetInstance().finance_Consume[level - 1];
                        GameData.GetInstance().finance_Return_Rate_Base_Num = GameData.GetInstance().return_Rate_Base[level - 1];
                    }
                    break;
            }
            Debug.Log("升级");
        }
        else
        {
            Debug.Log("科技点不足");
        }


    }
}