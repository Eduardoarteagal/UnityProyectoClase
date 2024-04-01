using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManagement : MonoBehaviour
{
    public float movementSpeed = 2f; // Velocidad de movimiento del objeto
    public Transform[] patrolPoints; // Puntos de patrulla a los que se dirigirá el objeto
    private int currentPatrolIndex = 0; // Índice actual en la ruta de patrulla
    public float detectionDistance = 5f; // Distancia de detección del jugador
    public Transform player; // Referencia al transform del jugador
    private bool isFollowingPlayer = false; // Indica si el objeto está siguiendo al jugador

    private void Start()
    {
        StartCoroutine(PatrolRoutine());
    }

    private void Update()
    {
        // Verificar si el jugador está dentro de la distancia de detección
        if (Vector2.Distance(transform.position, player.position) < detectionDistance)
        {
            isFollowingPlayer = true;
        }
    }

    IEnumerator PatrolRoutine()
    {
        while (true)
        {
            // Si está siguiendo al jugador, moverse hacia su posición
            if (isFollowingPlayer)
            {
                Vector3 targetPosition = player.position;
                while (transform.position != targetPosition)
                {
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
                    yield return null;
                }
            }
            else // Si no está siguiendo al jugador, patrullar los puntos normales
            {
                Vector3 targetPosition = patrolPoints[currentPatrolIndex].position;
                while (transform.position != targetPosition)
                {
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
                    yield return null;
                }
                currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
            }

            yield return null;
        }
    }
}