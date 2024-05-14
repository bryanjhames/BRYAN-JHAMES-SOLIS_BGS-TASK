using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRigidbody;
    [SerializeField] private Animator anim;

    [SerializeField] private Vector3 playerMovement;
    [SerializeField] private float speed = 5f;
   
    private void Start() {
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate() {
        playerMovement = Vector3.zero;
        playerMovement.x = Input.GetAxisRaw("Horizontal");
        playerMovement.y = Input.GetAxisRaw("Vertical");

        UpdateAnimationAndMove();
    }

    private void UpdateAnimationAndMove() {
        if (playerMovement != Vector3.zero) {
            MoveCharacter();
            anim.SetFloat("moveX", playerMovement.x);
            anim.SetFloat("moveY", playerMovement.y);
            anim.SetBool("moving", true);
        } else {
            anim.SetBool("moving", false);
        }
    }

    private void MoveCharacter() {
        myRigidbody.MovePosition(transform.position + playerMovement * speed * Time.deltaTime);
    }
}
