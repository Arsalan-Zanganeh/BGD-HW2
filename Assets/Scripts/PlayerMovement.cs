using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maximumSpeed;
    public float rotationSpeed;
    public float jumpSpeed;
    public Transform cameraTransform;

    private Animator animator;
    private CharacterController characterController;
    private float ySpeed;
    private float originalStepOffset;
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
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude) / 2;
        if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && currentState != BatmanState.Stealth)
        {
            inputMagnitude *= 2;
        }
        animator.SetFloat("Input Magnitude", inputMagnitude, 0.05f, Time.deltaTime);
        float speed = inputMagnitude * maximumSpeed;
        movementDirection = Quaternion.AngleAxis(cameraTransform.eulerAngles.y, Vector3.up) * movementDirection;
        movementDirection.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime;

        // if (characterController.isGrounded)
        // {
        //     characterController.stepOffset = originalStepOffset;
        //     ySpeed = -0.5f;
        // 
        //     if (Input.GetButtonDown("Jump"))
        //     {
        //         ySpeed = jumpSpeed;
        //     }
        // }
        // else
        // {
        //     characterController.stepOffset = 0;
        // }

        if (Input.GetKeyDown(KeyCode.C))
        {
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
            currentState = BatmanState.Normal;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentState == BatmanState.Alert)
            {
                currentState = BatmanState.Normal;
            }
            else
            {
                currentState = BatmanState.Alert;
            }
        }

        Vector3 velocity = movementDirection * speed;
        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            // animator.SetBool("isMoving", true);
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            //animator.SetBool("isMoving", false);
        }

        void OnApplicationFocus(bool focus)
        {
            if (focus)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }

    }
}
