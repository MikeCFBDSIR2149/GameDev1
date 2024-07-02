using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 30;
    public float time = 3;
    public bool timeRock;
    public Camera mainCamera;

    public bool isHit;
    public bool isDone;
    
    protected readonly LayerMask mask = 1 << 9;

    protected virtual void Update()
    {
        if (time <= -10)
        {
            timeRock = false;
            time = 3;
        }
        if (timeRock)
        {
            time -= Time.deltaTime;
        }
    }

    protected void OnMouseDrag()
    {
        MoveObject();
    }

    protected virtual void MoveObject()
    {
        if (time is < 0 and > - 10)
            return;
        var r = mainCamera.ScreenPointToRay(Input.mousePosition); //创建射线
        if (!Physics.Raycast(r, 1000, mask)) 
            return; //检测
        timeRock = true;
        isHit = true;
    }
}
