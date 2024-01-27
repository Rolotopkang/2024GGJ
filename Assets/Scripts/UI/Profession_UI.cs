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

    [Header("����")]
    public int output_Value_Per_Unit = 2; //��λ����
    public int current_Output_Value = 0; //�»غϲ���
    public int happiness_output_Value_Per_Unit = 1; //��λ�Ҹ��Ȳ���
    public int current_Happiness_Output_Value = 0; //�»غ��Ҹ��Ȳ���

    [Header("����")]
    public int supplies_Consume = 1; //��������
    public float supplies_Consume_Fix = 1f; //ÿ�غ�������������

    [Header("����")]
    public Text resources_Value_Text;
    public Text output_Value_Text;
    public Text supplies_Consume_Text;
    public Text uprade_Consume_Text;


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
                    resources_Value_Text.text = "���ʣ�"+ GameData.GetInstance().Supplies.ToString();
                    output_Value_Text.text = current_Output_Value.ToString() + " ����" + current_Happiness_Output_Value.ToString() + " �Ҹ�";
                }
                break;
            case Enums.Professions.Science:
                {
                    resources_Value_Text.text = "���У�" + GameData.GetInstance().Science_Point.ToString();
                    output_Value_Text.text = current_Output_Value.ToString() + " ����" + current_Happiness_Output_Value.ToString() + " �Ҹ�";
                }
                break;
            case Enums.Professions.Finance:
                {
                    resources_Value_Text.text = "�ʽ�" + GameData.GetInstance().Money.ToString();
                    output_Value_Text.text = current_Output_Value.ToString() + " �ʽ�" + current_Happiness_Output_Value.ToString() + " �Ҹ�";
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
