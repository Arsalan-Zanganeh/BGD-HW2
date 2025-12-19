using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSignal : MonoBehaviour
{
    // 1. Get the Renderer component
    public Renderer batSignal;

    void Update()
    {
        // Example: Press the 'H' key to hide/show the object
        if (Input.GetKeyDown(KeyCode.B))
        {
            ToggleRenderer();
        }
    }

    void ToggleRenderer()
    {
        // 2. Check if it exists to avoid errors
        if (batSignal != null)
        {
            // 3. Toggle the enabled state
            batSignal.enabled = !batSignal.enabled;
        }
    }
}
