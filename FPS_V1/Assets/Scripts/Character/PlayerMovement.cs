using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12;
    //gravedad al momento de caer
    public float gravity = -25f;
    //la velocidad a la que caera el personaje
    Vector3 velocity;

    //cosas de la caida del personaje
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    //jump height
    public float jump = 4f;

    bool isGrounded;

    void Update()
    {
        //crea una esfera la cual revisa si es que esta tocando la posicion con la mascara y otorga un valor booleano
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //si es que entra aqui, no estamos cayendo y nuestra velocidad de caida es menor a 0
        //la velocidad de caida de pondra negativa para asi resetear la velocidad
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //obtiene los valores del eje horizontal y vertical
        float x = Input.GetAxis("Horizontal");        
        float z = Input.GetAxis("Vertical");

        //se crea una variable donde se multiplican los valores de "x" y "z" para mover al jugador
        //dependiendo hacia donde este volteando a ver
        Vector3 move = transform.right * x + transform.forward * z;

        //se usa una funcion del character controller para hacer el movimiento
        controller.Move(move * speed * Time.deltaTime);

        //se calcula a la velocidad de caida del personaje
        velocity.y += gravity * Time.deltaTime;

        //se implementa la caida
        controller.Move(velocity * Time.deltaTime);
        //se implementa el salto XD
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jump * -2 * gravity);
        }

    }
}
