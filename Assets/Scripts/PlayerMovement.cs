using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Reference")]
    public Rigidbody2D rb;
    public Animator animator;

    [Header("Smìr pohybu")]
    public Vector2 movementDirection;

    [Header("Rychlost pohybu")]
    public float moveSpeed = 4f;

    private void Update()
    {
        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");

        // Omeu
        if (Mathf.Abs(movementDirection.x) > Mathf.Abs(movementDirection.y))
        {
            movementDirection.y = 0f;
        }
        else
        {
            movementDirection.x = 0f;
        }


        
        if (movementDirection != Vector2.zero)
        {
            animator.SetFloat("Horizontal", movementDirection.x);
            animator.SetFloat("Vertical", movementDirection.y);
        }
           
        animator.SetFloat("Speed", movementDirection.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementDirection * moveSpeed * Time.fixedDeltaTime);
    }
}