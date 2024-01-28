using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Global : Singleton<Global>
{
    //public static Global Instance;

    public MainMenu_UI mainMenu_UI;
    public GameOver_UI gameOver_UI;
    public Happiness_UI happiness_UI;
    public Money_UI money_UI;
    public GameObject drawCard_UI;
    public List<Profession_UI> Profession_List = new List<Profession_UI>();



    // Start is called before the first frame update
    void Start()
    {
        mainMenu_UI.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void StartGame()
    {
        Debug.Log("开始游戏");
        GameInit();
    }


    void GameInit()
    {
        GameData.GetInstance().Init();

        for (int i = 0; i < Profession_List.Count; i++)
        {
            Profession_List[i].UpdateInfo();
        }
        
        happiness_UI.Init();
    }


    //下一回合
    public void NextTurn()
    {
        GameData.GetInstance().turn_Num += 1;
        ResourceOutput();
        SuppliesConsume();
        SuppliesTest();
        HappinessTest();

        //幸福度更新
        happiness_UI.UpdateValue();
        //重置产出修正值为1
        GameData.GetInstance().ResetOutputFix();
        //重置事业
        for (int i = 0; i < Profession_List.Count; i++)
        {
            Profession_List[i].ResetData();
        }

        GameData.GetInstance().Money_Spend_Current_Turn = 0;

        IncidentUpdate();

        SetAvailableMoney();
        money_UI.UpdateValue();

        Debug.Log("下一回合:"+ GameData.GetInstance().turn_Num);
    }


    //事件更新
    private void IncidentUpdate()
    {
        GameEventSystem.GetInstance().OnEndRound();

        if (GameData.GetInstance().turn_Num % 5 == 0)
        {
            GameEventSystem.GetInstance().CreateGameEvent(ServiceLocator.Current.Get<IEventInfoService>().GetRandomBigEventSo());
        }
    }


    //资源产出
    private void ResourceOutput()
    {
        //资源产出
        GameData.GetInstance().Supplies += (int)(GameData.GetInstance().Supplies_Output_Fix * Profession_List[0].GetOutputValue() + Profession_List[0].return_Rate);
        GameData.GetInstance().Science_Point += (int)(GameData.GetInstance().Science_Point_Output_Fix * Profession_List[1].GetOutputValue()+ Profession_List[1].return_Rate);
        GameData.GetInstance().Money += (int)(GameData.GetInstance().Money_Output_Fix * Profession_List[2].GetOutputValue()+ Profession_List[2].return_Rate);
        
        GameData.GetInstance().Money = Mathf.Min(GameData.GetInstance().Money, GameData.GetInstance().money_Limit[GameData.GetInstance().finance_Level]);

        //幸福度产出
        int happy = 0;
        happy = Profession_List[0].current_Happiness_Output_Value + Profession_List[1].current_Happiness_Output_Value + Profession_List[2].current_Happiness_Output_Value;
        GameData.GetInstance().Happiness += happy;

        GameData.GetInstance().Money_Spend_Current_Turn = 0;
    }

    private void SetAvailableMoney()
    {
        GameData.GetInstance().Money_Available = (int)(GameData.GetInstance().Money * GameData.GetInstance().Money_Available_Fix);
        GameData.GetInstance().All_Money_Current_Turn = GameData.GetInstance().Money_Available;
        //Debug.Log("可配置资金乘数：" + GameData.GetInstance().Money_Available_Fix);
        //Debug.Log("当前资金：" + GameData.GetInstance().Money + " 可配置资金：" + GameData.GetInstance().Money_Available);
    }


    //物资消耗
    public void SuppliesConsume()
    {
        for (int i = 0; i < Profession_List.Count; i++)
        {
            Profession_List[i].SuppliesConsume();
        }
    }

    //物资检查
    private void SuppliesTest()
    {
        if (GameData.GetInstance().Supplies <= 0)
        {
            GameOver();
        }
    }


    //幸福度检查
    private void HappinessTest()
    {
        if (GameData.GetInstance().Happiness >= GameData.GetInstance().Happiness_Goal)
        {
            GameSuccess();
        }
    }

    //更新所有事业信息
    public void UpdateAllProfession()
    {
        for (int i = 0; i < Profession_List.Count; i++)
        {
            Profession_List[i].UpdateInfo();
        }

        money_UI.UpdateValue();

    }

    //抽卡
    public void DrawCard()
    {
        if (GameData.GetInstance().Money >= GameData.GetInstance().Draw_Card_Required_Money * GameData.GetInstance().Draw_Card_Required_Money_Fix)
        {
            drawCard_UI.gameObject.SetActive(true);
            GameData.GetInstance().Money -= (int)(GameData.GetInstance().Draw_Card_Required_Money * GameData.GetInstance().Draw_Card_Required_Money_Fix);
            GameData.GetInstance().Money_Spend_Current_Turn += GameData.GetInstance().Draw_Card_Required_Money;
            money_UI.UpdateValue();
        }
        else
        {
            Debug.Log("科技点不足无法抽卡");
        }
        
    }

    void GameSuccess()
    {
        gameOver_UI.ShowGameOverUI(true);
    }

    void GameOver()
    {
        gameOver_UI.ShowGameOverUI(false);
    }

    //回到主菜单
    public void BackToMainMenu()
    {
        mainMenu_UI.gameObject.SetActive(true);
        gameOver_UI.gameObject.SetActive(false);
        GameData.GetInstance().turn_Num = 1;
        happiness_UI.UpdateValue();
    }



    //=========================================================================================================================

    //接口

    //=========================================================================================================================

    //设置指定事业等级为1，参数：序号
    public void SetProfessionLevel_One(int index)
    {
        Profession_List[index].isLevel_One = true;
    }



}
