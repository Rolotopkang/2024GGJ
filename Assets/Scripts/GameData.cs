using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : Singleton<GameData>
{

    public int initial_Supplies = 3;//��ʼ����

    public int Money = 0;
    public int Supplies = 0;
    public int Science_Point = 0;
    public int Happiness = 0;
    public int Happiness_Goal = 100; //�Ҹ���Ŀ��

    public int Money_Output_Fix = 0;
    public float Supplies_Output_Fix = 1f;
    public float Science_Point_Output_Fix = 1f;
    public float Happiness_Output_Fix = 1f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    //���ò�������ֵ
    public void ResetOutputFix()
    {
        Supplies_Output_Fix = 1f;
        Science_Point_Output_Fix = 1f;
        Happiness_Output_Fix = 1f;
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
