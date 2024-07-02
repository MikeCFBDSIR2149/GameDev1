using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Mesh9 : Move
{
    [Header("Special")] 
    public Level2Mesh56 previousAction1;
    public Level2Mesh56 previousAction2;
    public GameObject cube;
    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;

    protected override void MoveObject()
    {
        if (!previousAction1.isStep1Done || !previousAction2.isStep1Done)
            return;

        base.MoveObject();
    }
}
