using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : Singleton<Global>
{
    //public static Global Instance;

    public MainMenu_UI mainMenu_UI;
    public GameOver_UI gameOver_UI;
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
        
    }


    //下一回合
    public void NextTurn()
    {
        IncidentUpdate();
        ResourceOutput();
        SuppliesConsume();
        SuppliesTest();
        HappinessText();
        
        //重置产出修正值为1
        GameData.GetInstance().ResetOutputFix();
        //重置事业
        for (int i = 0; i < Profession_List.Count; i++)
        {
            Profession_List[i].ResetData();
        }

        GameData.GetInstance().turn_Num += 1;
        Debug.Log("下一回合");
    }

    //事件更新
    private void IncidentUpdate()
    {

    }


    //资源产出
    private void ResourceOutput()
    {
        //资源产出
        GameData.GetInstance().Supplies += (int)(GameData.GetInstance().Supplies_Output_Fix * Profession_List[0].current_Output_Value);
        GameData.GetInstance().Science_Point += (int)(GameData.GetInstance().Science_Point_Output_Fix * Profession_List[1].current_Output_Value);
        GameData.GetInstance().Money += (int)(GameData.GetInstance().Money_Output_Fix * Profession_List[2].current_Output_Value);

        //幸福度产出
        int happy = 0;
        happy = Profession_List[0].current_Happiness_Output_Value + Profession_List[1].current_Happiness_Output_Value + Profession_List[2].current_Happiness_Output_Value;
        GameData.GetInstance().Happiness += happy;

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
    private void HappinessText()
    {
        if (GameData.GetInstance().Happiness >= GameData.GetInstance().Happiness_Goal)
        {
            GameSuccess();
        }
    }

    //投资，参数：序号，数值
    public void Invest(int index, int value)
    {
        Profession_List[index].UpdateInvest(value);
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
    }

}
