using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRb;
    Vector2 playerInput;
    public float playerSpeed = 5f;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        PlayerMovement();
    }
    public void OnMove(InputValue movementValue) //pega o input do movimento do player
    {
        playerInput = movementValue.Get<Vector2>();
    }
    void PlayerMovement() //movimento do player + lado que esta olhando
    {
        playerRb.linearVelocityX = playerInput.x * playerSpeed; //movimenta o player no eixo X
    }
}
