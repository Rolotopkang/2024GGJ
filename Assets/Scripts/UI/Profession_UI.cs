using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Profession_UI : MonoBehaviour
{
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
        current_Output_Value = value * output_Value_Per_Unit;
        current_Happiness_Output_Value = value * happiness_output_Value_Per_Unit;

    }

    public void ResetData()
    {
        current_Output_Value = 0;
        current_Happiness_Output_Value = 0;
    }

}
