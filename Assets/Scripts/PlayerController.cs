using System;
using System.Collections;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;
    Vector2 playerInput;

    [Header("Configurações do Player")]
    [SerializeField] float playerSpeed = 6f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float acceleration = 10f;
    [SerializeField] float decceleration = 6f;
    [SerializeField] float velPower = 1.2f;

    [Header("Checagem")]
    public bool isJumping;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>(); // pega o rigidbody2d
    }

    void Update()
    {

    }
    void FixedUpdate()
    {
        PlayerMovement();
    }
    public void OnMove(InputValue movementValue) // pega o input do movimento do player
    {
        playerInput = movementValue.Get<Vector2>();
    }

    public void OnJump(InputValue jumpValue)
    {
        if (!isJumping && jumpValue.isPressed) // enquanto nao estiver pulando ele pula
        {
            Jump();
        }
    }

    private void PlayerMovement()
    {
        float targetSpeed = playerInput.x * playerSpeed; // guarda o valor da velocidade que o player quer chegar
        
        float speedDif = targetSpeed - playerRb.linearVelocity.x; // pega a diferença entre a velocidade que o player quer chegar com a velocidade atual, 
                                                                  // se o player esta com 1 de velocidade, falta 4 para chegar no objetivo
        
        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration; // se mathf.abs(targetSpeed) for maior que 0.01 o accelRate é acceleration
                                                                                           // se não é decceleration. O mathf.Abs (Mathf.Absolute) apenas "remove"
                                                                                           // o sinal negativo de qualquer número, para evitar que quando você ande
                                                                                           // para a esquerda o jogo entenda que você está desacelerando
        
        float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPower) * Mathf.Sign(speedDif); // acelera até a velocidade que quero chegar, respeitando
                                                                                                      // os valores sempre positivos. O Mathf.Pow é uma potencia
                                                                                                      // e faz o trabalho da suavização. O Mathf.Sign serve para pegar
                                                                                                      // o sinal da diferença para dizer se estamos indo para a esquerda
                                                                                                      // (negativo) ou direita (positivo)

        playerRb.AddForce(movement * Vector2.right); // adiciona força no vetor da direita (se negativa vai para esquerda)
    }
    private void Jump()
    {
        playerRb.linearVelocity = new Vector3(playerRb.linearVelocity.x, jumpForce, playerRb.linearVelocity.z);
    }
}
