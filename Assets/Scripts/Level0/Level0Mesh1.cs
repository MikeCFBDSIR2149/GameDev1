using UnityEngine;

public class Level0Mesh1 : Rotate
{
    protected override void Update()
    {
        base.Update();
        
        if (!isHit) 
            return;
        
        if (time > 0)
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime, Space.Self);
        }
        else
        {
            timeRock = false;
        }
    }
}