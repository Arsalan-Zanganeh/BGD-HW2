using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSignal : MonoBehaviour
{
    // 1. Get the Renderer component
    public Renderer batSignal;
    public Vector3 rotateAmount;

    void Update()
    {
        // Example: Press the 'H' key to hide/show the object
        if (Input.GetKeyDown(KeyCode.B))
        {
            ToggleRenderer();
        }
        
        if (batSignal.enabled)
        {
            transform.Rotate(rotateAmount * Time.deltaTime);
        }
    }

    void ToggleRenderer()
    {
        // 1. Check if it exists to avoid errors
        if (batSignal != null)
        {
            // 2. Toggle the enabled state
            batSignal.enabled = !batSignal.enabled;
        }
    }
}
