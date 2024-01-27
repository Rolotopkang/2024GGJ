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
    
}
