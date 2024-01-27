using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Profession_UI : MonoBehaviour
{
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
        current_Output_Value = value * output_Value_Per_Unit;
        current_Happiness_Output_Value = value * happiness_output_Value_Per_Unit;

    }

    public void ResetData()
    {
        current_Output_Value = 0;
        current_Happiness_Output_Value = 0;
    }

}
