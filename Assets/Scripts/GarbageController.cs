using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageController : MonoBehaviour
{
    public Transform Fox; // Referencia al jugador
    public float distance = 15f; // Distancia que queremos mantener entre el jugador y el GarbageCollector
    public float moveSpeed = 5f; // Velocidad de movimiento del GarbageCollector

    void Update()
    {
        if (Fox != null) // Verificamos que la referencia al jugador no sea nula
        {
            // Calculamos la posición a la que queremos que vaya el GarbageCollector
            Vector3 targetPosition = Fox.position + Vector3.right * distance;

            // Movemos el GarbageCollector hacia la posición del jugador con la distancia deseada
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
