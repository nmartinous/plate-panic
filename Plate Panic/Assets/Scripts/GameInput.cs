using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        // Get and enable the input actions component for the player
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    public Vector2 GetMovementVectorNormalized()
    {
        // Store the inputted vector from the input actions component as inputVector
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        // Normalize
        inputVector = inputVector.normalized;

        return inputVector;
    }
}
