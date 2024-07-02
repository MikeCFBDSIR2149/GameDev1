using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Mesh34 : Move
{
    [Header("Special")] 
    public Level2Mesh2 previousAction;

    protected override void MoveObject()
    {
        if (!previousAction.isStep1Done)
            return;
        
        base.MoveObject();
    }
}
