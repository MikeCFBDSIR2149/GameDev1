using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Mesh56 : Move
{
    [Header("Special")] 
    public Level2Mesh34 previousAction;
    public bool isStep1Done;

    protected override void MoveObject()
    {
        if (!previousAction.isDone)
            return;
        
        var r = mainCamera.ScreenPointToRay(Input.mousePosition); //创建射线

        if (!Physics.Raycast(r, 1000, mask))
            return; //检测

        StartCoroutine(!isStep1Done ? MoveCoroutine(moveTarget) : MoveCoroutine(moveDuration));
    }

    protected override IEnumerator MoveCoroutine(object moveParameter)
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

                isDone = true;

                break;
            }
            case Vector3 moveParameterTarget:
            {
                while (transform.position != moveParameterTarget)
                {
                    transform.position = Vector3.MoveTowards(transform.position, moveParameterTarget, 
                        speed / 5 * Time.deltaTime);
                    yield return null;
                }
                
                isStep1Done = true;

                break;
            }
        }
    }
}
