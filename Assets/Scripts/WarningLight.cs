using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningLight : MonoBehaviour
{
    public Light pointLight;
    private float timer = 0f;
    private float interval = 0.5f;
    private bool isRed = true;
    private enum BatmanState
    {
        Normal,
        Stealth,
        Alert
    }

    private BatmanState currentState = BatmanState.Normal;

    void Start()
    {
        // Get the Light component attached to this GameObject
        pointLight = GetComponent<Light>();

        // Initialize with the first color
        pointLight.color = Color.red;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            pointLight.intensity = 0;
            if (currentState == BatmanState.Stealth)
            {
                currentState = BatmanState.Normal;
            }
            else
            {
                currentState = BatmanState.Stealth;
            }
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            pointLight.intensity = 0;
            currentState = BatmanState.Normal;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentState == BatmanState.Alert)
            {
                pointLight.intensity = 0;
                currentState = BatmanState.Normal;
            }
            else
            {
                pointLight.intensity = 2.25f;
                currentState = BatmanState.Alert;
            }
        }
        // Add the time passed since the last frame to our timer
        timer += Time.deltaTime;

        // Check if 0.5 seconds have passed
        if (timer >= interval)
        {
            // Reset timer
            timer = 0f;

            // Toggle the color
            if (isRed)
            {
                pointLight.color = Color.blue;
            }
            else
            {
                pointLight.color = Color.red;
            }

            // Flip the boolean state
            isRed = !isRed;
        }
    }
}
