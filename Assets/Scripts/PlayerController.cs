using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Vector2 playerInput;
    [SerializeField] private float playerSpeed = 2f;
    [SerializeField] private float jumpForce =  5f; 

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        PlayerMovement();
    }
    public void OnMove(InputValue movementValue) 
    {
        playerInput = movementValue.Get<Vector2>();
    }

    public void OnJump(InputValue jumpValue)
    {
        if (jumpValue.isPressed)
        {
            Jump();
        }
     
    }

    private void Jump()
    {
        playerRb.linearVelocityY =  jumpForce; 
    }

    private void PlayerMovement()
    {
        playerRb.linearVelocityX = playerInput.x * playerSpeed; //movimenta o player no eixo X
    }
}
