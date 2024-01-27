using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : Singleton<GameData>
{

    public int initial_Supplies = 3;//��ʼ����

    public int Money = 0; //��ǰ�������ʽ�
    public int Supplies = 0;
    public int Science_Point = 0;
    public int Happiness = 0;
    public int Happiness_Goal = 100; //�Ҹ���Ŀ��

    public int supplies_Consume = 1; //ÿ�غ���������
    public float supplies_Consume_Fix = 1f; //ÿ�غ�������������

    //��ҵ��������
    public float Money_Output_Fix = 1f;
    public float Supplies_Output_Fix = 1f;
    public float Science_Point_Output_Fix = 1f;

    //����
    public bool Upgrade_Available = false;
    public int Upgrade_Refresh_Num = 0; //��ˢ�´���

    //��ҵ�ȼ�
    public int industry_Level = 0;
    public int science_Level = 0;
    public int finance_Level = 0;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    //���ò�������ֵ
    public void ResetOutputFix()
    {
        Supplies_Output_Fix = 1f;
        Science_Point_Output_Fix = 1f;
        Money_Output_Fix = 1f;
    }

    //�������
    public void ResourceOutput()
    {
        Money = (int)(Money_Output_Fix * Money);
        Supplies = (int)(Supplies_Output_Fix * Supplies);
        Science_Point = (int)(Science_Point_Output_Fix * Science_Point);

        Happiness = (int)(Happiness_Output_Fix * Happiness);
    }

}
