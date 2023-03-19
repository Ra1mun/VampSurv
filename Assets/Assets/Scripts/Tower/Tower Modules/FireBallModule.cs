using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallModule : IActiveModule
{
    public override void UseModuleLogic()
    {
        Debug.Log("FireBall Is Active");
    }
    void Start()
    {
        UseModuleLogic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
