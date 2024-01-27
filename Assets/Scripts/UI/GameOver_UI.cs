using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver_UI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void ShowGameOverUI(bool flag)
    {
        gameObject.SetActive(true);
        if (flag)
        {

        }
        else
        {

        }
    }


    public void OnBecameInvisible()
    {
        Global.GetInstance().BackToMainMenu();
    }

}
