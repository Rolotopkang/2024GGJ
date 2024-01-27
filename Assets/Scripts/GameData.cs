using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : Singleton<GameData>
{

    public int initial_Supplies = 3;//³õÊ¼Îï×Ê

    public int Money = 0;
    public int Supplies = 0;
    public int Science_Point = 0;
    public int Happiness = 0;

    public float Supplies_Output_Fix = 1f;
    public float Science_Point_Output_Fix = 1f;
    public float Happiness_Output_Fix = 1f;


    // Start is called before the first frame update
    void Start()
    {
        
    }



}
