using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUI : MonoBehaviour
{
    public static int entersome;
    public int startCoinQuantity;
    public Text coinQuantity;

    private void Start()
    {
        entersome = startCoinQuantity;
    }
    
    private void Update()
    {
        coinQuantity.text = entersome.ToString();
    }
}
