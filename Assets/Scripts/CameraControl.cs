using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject Objetivo;
    public float MaxPositionX;
    public float MinPositionX;
    public float MaxPositionY;
    public float MinPositionY;
    float Xposition;
    float Yposition;
    Vector3 Velocidad;
    public float CameraSpeed;

    void Update()
    {
        Xposition = Mathf.Clamp(Objetivo.transform.position.x, MinPositionX, MaxPositionX);
        Yposition = Mathf.Clamp(Objetivo.transform.position.y, MinPositionY, MaxPositionY);

        // Usar las posiciones clamped para calcular la posici�n objetivo de la c�mara
        Vector3 ObjetivePosition = new Vector3(Xposition, Yposition, -10);

        // Mover suavemente la c�mara hacia la posici�n objetivo
        transform.position = Vector3.SmoothDamp(transform.position, ObjetivePosition, ref Velocidad, CameraSpeed);
    }
}
