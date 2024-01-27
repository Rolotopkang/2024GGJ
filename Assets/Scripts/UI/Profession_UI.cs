using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Profession_UI : MonoBehaviour
{
    public Enums.Professions type;
    public int level = 0;
    public bool upgrade_Available = false;

    public int output_Value_Per_Unit = 2; //��λ����
    public int happiness_output_Value_Per_Unit = 1; //��λ�Ҹ��Ȳ���

    public int current_Output_Value = 0; //�»غϲ���
    public int current_Happiness_Output_Value = 0; //�»غ��Ҹ��Ȳ���


    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Ͷ�ʸ���
    public void UpdateInvest(int value)
    {
        //����Ͷ��
        if (value > 0)
        {
            //����ʽ���
            if (GameData.GetInstance().Money < value)
            {
                return;
            }
        }
        //����Ͷ��
        else if ( value < 0)
        {
            //��������Ѿ�Ϊ0
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
