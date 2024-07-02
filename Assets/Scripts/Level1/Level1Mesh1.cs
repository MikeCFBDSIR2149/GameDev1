using UnityEngine;

public class Level1Mesh1 : Rotate
{
    public GameObject Cube1;
    public GameObject Cube2;
    public GameObject ground3;
    public GameObject ground4;
    public GameObject ground5;
    
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
            ground5.SetActive(true);
            isDone = true;
        }

    }

    protected override void MoveObject()
    {
        base.MoveObject();
        ground3.SetActive(false);
        ground4.SetActive(false);
        Cube1.SetActive(true);
        Cube2.SetActive(true);
    }
}
