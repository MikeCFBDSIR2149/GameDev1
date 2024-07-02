using System.Collections;
using UnityEngine;

public class Level1Mesh2 : Move
{
    public GameObject portal1Enter;
    public GameObject portal1Exit;
    public Level1Mesh1 previousAction;

    public GameObject ground1;
    public GameObject ground2;

    protected override void MoveObject()
    {
        if (!previousAction.isDone)
            return;
        
        base.MoveObject();
        
        ground1.SetActive(false);
        ground2.SetActive(false);
        portal1Enter.SetActive(false);
        portal1Exit.SetActive(false);
    }
}
