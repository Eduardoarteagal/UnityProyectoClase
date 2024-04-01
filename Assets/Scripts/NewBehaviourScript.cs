using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject[] TilemapPrefabs;
    public float minDistance = 5f;
    public float maxDistance = 10f;

    void Start()
    {
        StartCoroutine(GeneratePlatforms());
    }

    IEnumerator GeneratePlatforms()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minDistance, maxDistance));

            // Selecciona un prefab aleatorio de plataforma
            GameObject selectedPlatform = TilemapPrefabs[Random.Range(0, TilemapPrefabs.Length)];

            // Genera la plataforma en la posición del objeto que contiene este script
            Instantiate(selectedPlatform, transform.position, Quaternion.identity);
        }
    }
}
