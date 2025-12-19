using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionControl : MonoBehaviour
{
    public Material material1;
    public Material material2;

    private enum BatmanState 
    { 
        Normal,
        Stealth,
        Alert 
    }

    private BatmanState currentState = BatmanState.Normal;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (currentState == BatmanState.Stealth)
            {
                material1.EnableKeyword("_EMISSION");
                material2.EnableKeyword("_EMISSION");
                currentState = BatmanState.Normal;
            }
            else
            {
                material1.DisableKeyword("_EMISSION");
                material2.DisableKeyword("_EMISSION");
                currentState = BatmanState.Stealth;
            }
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            material1.EnableKeyword("_EMISSION");
            material2.EnableKeyword("_EMISSION");
            currentState = BatmanState.Normal;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            material1.EnableKeyword("_EMISSION");
            material2.EnableKeyword("_EMISSION");
            if (currentState == BatmanState.Alert)
            {
                currentState = BatmanState.Normal;
            }
            else
            {
                currentState = BatmanState.Alert;
            }
        }
    }
}
