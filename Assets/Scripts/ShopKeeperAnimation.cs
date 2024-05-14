using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeperAnimation : MonoBehaviour
{
    public PlayerMovement player; // Assign the player GameObject in the Inspector
    private Animator animator;

    // Define the default facing direction
    private float defaultMoveX = 0;
    private float defaultMoveY = -1;

    private void Start()
    {
        animator = GetComponent<Animator>();
        ResetToDefaultFacing();
    }

    private void UpdateFacingDirection()
    {
        float moveX = player.MoveX;
        float moveY = player.MoveY;

        if (Mathf.Abs(moveX) > Mathf.Abs(moveY))
        {
            // Horizontal facing
            if (moveX > 0)
            {
                // Facing right
                animator.SetFloat("moveX", -1);
                animator.SetFloat("moveY", 0);
            }
            else if (moveX < 0)
            {
                // Facing left
                animator.SetFloat("moveX", 1);
                animator.SetFloat("moveY", 0);
            }
        }
        else
        {
            // Vertical facing
            if (moveY > 0)
            {
                // Facing up
                animator.SetFloat("moveX", 0);
                animator.SetFloat("moveY", -1);
            }
            else if (moveY < 0)
            {
                // Facing down
                animator.SetFloat("moveX", 0);
                animator.SetFloat("moveY", 1);
            }
        }
    }

    private void ResetToDefaultFacing()
    {
        animator.SetFloat("moveX", defaultMoveX);
        animator.SetFloat("moveY", defaultMoveY);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UpdateFacingDirection();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ResetToDefaultFacing();
        }
    }
}
