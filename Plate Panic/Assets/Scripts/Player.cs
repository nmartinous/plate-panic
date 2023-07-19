using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Serialized to allow access within editor
    [SerializeField] private float moveSpeed = 7f;

    private bool isWalking;

    private void Update()
    {
        // Vector for storing movement inputs
        Vector2 inputVector = new Vector2(0, 0);

        // Recieve player input from WASD keys
        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = 1;
        }

        // Normalize inputVector to prevent diagonal movement being faster
        inputVector = inputVector.normalized;
        
        // Store inputVector as a Vector3 for applying player movement
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        
        // Apply player movement with moveDir and moveSpeed and considering frame rate with deltaTime
        transform.position += moveDir * Time.deltaTime * moveSpeed;

        // isWalking is true when the player is moving
        isWalking = moveDir != Vector3.zero;

        float rotateSpeed = 10f;

        // Rotate player model to face moving direction (uses Slerp to gradually rotate over time)
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
    }

    // Used to send isWalking state to other scripts
    public bool IsWalking()
    {
        return isWalking;
    }
}
