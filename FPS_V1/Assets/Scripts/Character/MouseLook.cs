using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //Sencibilidad del mouse
    public float mouseSensitivity = 100;
    //Posicion del personaje
    public Transform playerBody;
    //Posicion del arma
    public Transform gunPosition;
    public float gunRotation = 90;

    //Rotacion de la camara
    public float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

        #region Entrada de datos
        //Recibe los datos de movimiento del eje "x" y "y" del mouse y los multiplica por la sensibilidad
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        #endregion

        #region Movimiento del eje "y" sobre la camara y el arma
        /*
            Se le guarda el valor de "mouseY" en "xRotation" para dar ese valor y tener un valor entre su
            maximo de rotacion y el minimo, despues ese valor guardado se le rota al objeto en este caso
            la camara
        */
        xRotation -= mouseY;
        gunRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 30f);
        gunRotation = Mathf.Clamp(gunRotation, 0f, 120f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        gunPosition.localRotation = Quaternion.Euler(gunRotation, 0f, 0f);

        #endregion

        //Movimiento del eje x
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
