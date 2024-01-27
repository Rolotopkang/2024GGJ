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
        GameInit();
    }


    void GameInit()
    {
        GameData.GetInstance().Money = 0;
        GameData.GetInstance().Science_Point = 0;
        GameData.GetInstance().Happiness = 0;
        GameData.GetInstance().Supplies = GameData.GetInstance().initial_Supplies;
    }


    //下一回合
    void NextTurn()
    {
        IncidentUpdate();
        ResourceOutput();
        SuppliesTest();
        HappinessText();
        
        GameData.GetInstance().ResetOutputFix();
    }

    //事件更新
    private void IncidentUpdate()
    {

    }


    //资源产出
    private void ResourceOutput()
    {
        GameData.GetInstance().ResourceOutput();
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
