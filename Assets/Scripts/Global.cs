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
    

    //��һ�غ�
    void NextTurn()
    {
        IncidentUpdate();
        ResourceOutput();
        SuppliesTest();
        HappinessText();
    }

    //�¼�����
    private void IncidentUpdate()
    {

    }


    //��Դ����
    private void ResourceOutput()
    {

    }

    //���ʼ��
    private void SuppliesTest()
    {

    }


    //�Ҹ��ȼ��
    private void HappinessText()
    {

    }

    //Ͷ�ʣ���������ţ���ֵ
    public void Invest(int index,int value)
    {

    }


    void GameSuccess()
    {

    }

    void GameOver()
    {

    }

    //�ص����˵�
    public void BackToMainMenu()
    {
        mainMenu_UI.gameObject.SetActive(true);
    }

}
