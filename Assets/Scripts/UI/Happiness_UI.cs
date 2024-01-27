using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Happiness_UI : MonoBehaviour
{
    public TMP_Text turn_text;
    public Image happiness_Image;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }


    public void Init()
    {
        happiness_Image.fillAmount = 0;
    }


    public void UpdateValue()
    {
        happiness_Image.fillAmount = (float)GameData.GetInstance().Happiness/ (float)GameData.GetInstance().Happiness_Goal;
        //Debug.Log("幸福度更新");

        turn_text.text = "第"+GameData.GetInstance().turn_Num + "回合";
    }

}
