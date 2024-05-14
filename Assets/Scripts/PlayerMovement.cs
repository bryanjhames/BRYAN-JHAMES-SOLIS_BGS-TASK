using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Rigidbody2D myRigidbody;
    [SerializeField] private Vector3 playerMovement;
    [SerializeField] private Animator animator;

    public float MoveX { get; private set; }
    public float MoveY { get; private set; }

    private void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        playerMovement = Vector3.zero;
        playerMovement.x = Input.GetAxisRaw("Horizontal");
        playerMovement.y = Input.GetAxisRaw("Vertical");

        MoveX = playerMovement.x;
        MoveY = playerMovement.y;

        UpdateAnimationAndMove();
    }

    private void UpdateAnimationAndMove()
    {
        if (playerMovement != Vector3.zero)
        {
            MoveCharacter(playerMovement);
            animator.SetFloat("moveX", playerMovement.x);
            animator.SetFloat("moveY", playerMovement.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    private void MoveCharacter(Vector3 movement)
    {
        // Calculate the next position the player wants to move to
        Vector3 newPosition = transform.position + movement * speed * Time.deltaTime;

        // Perform a collision check before moving
        RaycastHit2D hit = Physics2D.Linecast(transform.position, newPosition);

        // If there's no obstacle, move the player
        if (hit.collider == null)
        {
            myRigidbody.MovePosition(newPosition);
        }
    }
}
