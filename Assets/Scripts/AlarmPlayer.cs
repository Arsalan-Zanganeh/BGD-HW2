using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    private enum BatmanState
    {
        Normal,
        Stealth,
        Alert
    }

    private BatmanState currentState = BatmanState.Normal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            audioSource.Stop();
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
            audioSource.Stop();
            currentState = BatmanState.Normal;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentState == BatmanState.Alert)
            {
                audioSource.Stop();
                currentState = BatmanState.Normal;
            }
            else
            {
                audioSource.Play();
                currentState = BatmanState.Alert;
            }
        }
    }
}
