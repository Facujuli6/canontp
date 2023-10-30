using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileLauncher : MonoBehaviour
{
    public Slider directionSlider;
    public Slider angleSlider;
    public float projectileSpeed = 10f;
    public GameObject projectilePrefab;

    void Update()
    {
        // Obtén la dirección y el ángulo desde los sliders
        float direction = directionSlider.value;
        float angle = angleSlider.value;

        // Convierte el ángulo a radianes
        float angleInRadians = angle * Mathf.Deg2Rad;

        // Calcula la velocidad en los ejes x e y
        float speedX = projectileSpeed * Mathf.Cos(angleInRadians);
        float speedY = projectileSpeed * Mathf.Sin(angleInRadians);

        // Verifica si se presiona la tecla de disparo (por ejemplo, espacio)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Crea el proyectil en la posición actual del lanzador
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            // Obtén el componente Rigidbody del proyectil
            Rigidbody rb = projectile.GetComponent<Rigidbody>();

            // Ajusta la dirección según el valor del slider horizontal
            float adjustedDirection = directionSlider.value;

            // Asigna la velocidad al proyectil
            rb.velocity = new Vector3(speedX * Mathf.Cos(adjustedDirection), speedY) + transform.right * projectileSpeed * Mathf.Sin(adjustedDirection);
        }
    }
}

