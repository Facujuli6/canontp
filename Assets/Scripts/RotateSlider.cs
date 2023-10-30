using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateSlider : MonoBehaviour
{
    public GameObject proyectilPrefab;
    public Transform puntoDisparo;
    public float fuerzaDisparo = 15;
    public Slider rotationSlider;
    



    private float angleSliderNumber;
    
    private void Update()
    {
        angleSliderNumber = rotationSlider.value * 10f;
        this.transform.rotation = Quaternion.Euler(0, angleSliderNumber, 0);
        



        if (Input.GetKeyDown(KeyCode.Space))
        {
            Disparar();
        }
        void Disparar()
        {
            // Comprobar si el proyectilPrefab y el puntoDisparo están asignados
            if (proyectilPrefab != null && puntoDisparo != null)
            {
                // Crear una instancia del proyectil en el punto de disparo
                GameObject proyectil = Instantiate(proyectilPrefab, puntoDisparo.position, puntoDisparo.rotation);

                // Obtener el componente Rigidbody del proyectil
                Rigidbody rbProyectil = proyectil.GetComponent<Rigidbody>();

                // Aplicar fuerza al proyectil
                if (rbProyectil != null)
                {
                    rbProyectil.AddForce(puntoDisparo.position * 0.5f * fuerzaDisparo);
                   
                }
                else
                {
                    Debug.LogError("El proyectilPrefab debe tener un componente Rigidbody2D.");
                }
            }
            else
            {
                Debug.LogError("Asigna el proyectilPrefab y el puntoDisparo en el Inspector.");
            }
        }
    }
}
    
    