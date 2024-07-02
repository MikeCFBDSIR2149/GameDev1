using System;
using System.Collections;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    public Camera mainCamera;
    public bool isDone;

    [Header("Move Time Mode")]
    public float moveDuration;
    public Vector3 moveDirection;

    [Header("Move Target Mode")]
    public Vector3 moveTarget;


    protected readonly LayerMask mask = 1 << 9;

    protected void OnMouseDrag()
    {
        MoveObject();
    }

    protected virtual void MoveObject()
    {
        var r = mainCamera.ScreenPointToRay(Input.mousePosition); //创建射线
        
        if (!Physics.Raycast(r, 140, mask)) 
            return; //检测

        object moveParameter;
        
        if (moveDuration == 0)
        {
            moveParameter = moveTarget;
        }
        else
        {
            moveParameter = moveDuration;
        }
        
        StartCoroutine(MoveCoroutine(moveParameter));
    }
    
    protected virtual IEnumerator MoveCoroutine(object moveParameter)
    {
        float time = 0;
        
        switch (moveParameter)
        {
            case float moveParameterDuration:
            {
                while (time < moveParameterDuration)
                {
                    transform.Translate(moveDirection * (speed * Time.deltaTime));
                    time += Time.deltaTime;
                    yield return null;
                }

                break;
            }
            case Vector3 moveParameterTarget:
            {
                while (transform.position != moveParameterTarget)
                {
                    transform.position = Vector3.MoveTowards(transform.position, moveParameterTarget, speed * Time.deltaTime);
                    yield return null;
                }

                break;
            }
        }

        isDone = true;
    }
}
