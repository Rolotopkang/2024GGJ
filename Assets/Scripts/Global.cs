using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : Singleton<Global>
{
    public static Global Instance ;

    public MainMenu_UI mainMenu_UI;
    public GameOver_UI gameOver_UI;
    public List<Profession_UI> Profession_List = new List<Profession_UI>();

    

    // Start is called before the first frame update
    void Start()
    {
        
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

    }
    

    //下一回合
    void NextTurn()
    {
        IncidentUpdate();
        ResourceOutput();
        SuppliesTest();
        HappinessText();
    }

    //事件更新
    private void IncidentUpdate()
    {

    }


    //资源产出
    private void ResourceOutput()
    {

    }

    //物资检查
    private void SuppliesTest()
    {

    }


    //幸福度检查
    private void HappinessText()
    {

    }

    //投资，参数：序号，数值
    public void Invest(int index,int value)
    {

    }


    void GameSuccess()
    {

    }

    void GameOver()
    {

    }

    //回到主菜单
    public void BackToMainMenu()
    {
        mainMenu_UI.gameObject.SetActive(true);
    }

}
