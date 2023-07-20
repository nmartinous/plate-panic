using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Serialized to allow access within editor
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;

    private bool isWalking;

    private void Update()
    {
        // Get input normalized vector from the gameInput script's GetMovementVectorNormalized()
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        
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
