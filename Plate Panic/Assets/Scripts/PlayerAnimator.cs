using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking";

    private Animator animator;

    // Used to mark player object for obtaining isWalking state from IsWalking()
    [SerializeField] Player player;

    private void Awake()
    {
        // Set animator to the Animator associated with object script is attached to (in this case the player)
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Change the animator state to walking 
        animator.SetBool(IS_WALKING, player.IsWalking());
    }
}
