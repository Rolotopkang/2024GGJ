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

    [Header("����")]
    public int output_Value_Per_Unit_initial = 2;
    public int base_Output = 1;
    public int output_Value_Per_Unit = 2; //��λ����
    public float current_Output_Value = 0; //�»غϲ���
    public int happiness_output_Value_Per_Unit = 1; //��λ�Ҹ��Ȳ���
    public int current_Happiness_Output_Value = 0; //�»غ��Ҹ��Ȳ���

    [Header("����")]
    public int supplies_Consume = 1; //��������
    public float supplies_Consume_Fix = 1f; //ÿ�غ�������������

    [Header("�ر���")]
    public int return_Rate = 0;

    [Header("����")]
    public Text resources_Value_Text;
    public Text output_Value_Text;
    public Text supplies_Consume_Text;
    public Text uprade_Consume_Text;
    public TMP_Text return_Rate_Text;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    //������Ϣ��ʾ
    public void UpdateInfo()
    {
        UpdateUpgradeStatu();

        switch (type)
        {
            case Enums.Professions.Industry:
                {
                    resources_Value_Text.text = "���ʣ�"+ ((int)GameData.GetInstance().Supplies).ToString();
                    output_Value_Text.text = GetOutputValue().ToString() + " ����" + current_Happiness_Output_Value.ToString() + " �Ҹ�";
                }
                break;
            case Enums.Professions.Science:
                {
                    resources_Value_Text.text = "���У�" + ((int)GameData.GetInstance().Science_Point).ToString();
                    output_Value_Text.text = GetOutputValue().ToString() + " ����" + current_Happiness_Output_Value.ToString() + " �Ҹ�";
                }
                break;
            case Enums.Professions.Finance:
                {
                    resources_Value_Text.text = "�ʽ�" + ((int)GameData.GetInstance().Money).ToString();
                    output_Value_Text.text = GetOutputValue().ToString() + " �ʽ�" + current_Happiness_Output_Value.ToString() + " �Ҹ�";
                }
                break;
        }

        supplies_Consume_Text.text = ((int)(supplies_Consume* supplies_Consume_Fix)).ToString();

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


    //Ͷ�ʸ���
    public void UpdateInvest(int value)
    {
        Debug.Log("Ͷ�� " + value);
        //����Ͷ��
        if (value > 0)
        {
            //����ʽ���
            if (GameData.GetInstance().Money < value)
            {
                Debug.Log("�ʽ��� ");
                return;
            }
        }
        //����Ͷ��
        else if ( value < 0)
        {
            //��������Ѿ�Ϊ0
            if (current_Output_Value <=0 || current_Happiness_Output_Value <= 0)
            {
                Debug.Log("�޷��ٳ���Ͷ��");
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

    //�����ر���
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

        return_Rate_Text.text = "����������" + return_Rate;
    }



    //��������״̬
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

    //����
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
