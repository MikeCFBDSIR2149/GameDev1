using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshUvTest : MonoBehaviour
{
    private void Start()
    {
        var mat = GetComponent<Renderer>().material;
        var oriValue = mat.mainTextureScale;

        oriValue.y = transform.localScale.y / 3;
        mat.mainTextureScale = oriValue;
    }
}

