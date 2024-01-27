using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewUpgrade", menuName = "Upgrade/new Upgrade")]
public class Upgrade_SO : ScriptableObject
{
    [Header("单位产出")]
    public List<int> industry_OutPut = new List<int>();
    public List<int> science_OutPut = new List<int>();
    public List<int> finance_OutPut = new List<int>();

    [Header("基本产出")]
    public List<int> industry_Base_OutPut = new List<int>();
    public List<int> science_Base_OutPut = new List<int>();
    public List<int> finance_Base_OutPut = new List<int>();

    [Header("消耗")]
    public List<int> industry_Consume = new List<int>();
    public List<int> science_Consume = new List<int>();
    public List<int> finance_Consume = new List<int>();

    [Header("回报率")]
    public List<int> return_Rate_Base = new List<int>();

    [Header("资金上限")]
    public List<int> money_Limit = new List<int>();


}
