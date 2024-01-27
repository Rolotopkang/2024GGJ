using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewUpgrade", menuName = "Upgrade/new Upgrade")]
public class Upgrade_SO : ScriptableObject
{
    [Header("��λ����")]
    public List<int> industry_OutPut = new List<int>();
    public List<int> science_OutPut = new List<int>();
    public List<int> finance_OutPut = new List<int>();

    [Header("��������")]
    public List<int> industry_Base_OutPut = new List<int>();
    public List<int> science_Base_OutPut = new List<int>();
    public List<int> finance_Base_OutPut = new List<int>();

    [Header("����")]
    public List<int> industry_Consume = new List<int>();
    public List<int> science_Consume = new List<int>();
    public List<int> finance_Consume = new List<int>();

    [Header("�ر���")]
    public List<int> return_Rate_Base = new List<int>();

    [Header("�ʽ�����")]
    public List<int> money_Limit = new List<int>();


}
