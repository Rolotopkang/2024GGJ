using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Awake()
    {
        MusicMgr.GetInstance().Init();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayEffectAudio()
    {
        MusicMgr.GetInstance().PlayEffectMusic("GetCoin", "bonus_coin_1");
    }
    
}
