using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemGeneration : MonoBehaviour
{
    public GameObject ItemGoodPrefab; // Prefab del ítem bueno (estrella)
    public GameObject ItemBadPrefab; // Prefab del ítem malo (oso)

    public float minTime = 1f; // Tiempo mínimo entre generaciones
    public float maxTime = 2f; // Tiempo máximo entre generaciones

    void Start()
    {
        StartCoroutine(GenerateItemsRoutine());
    }

    IEnumerator GenerateItemsRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));

            // Genera un número aleatorio para determinar si se generará un ítem bueno o malo
            int randomIndex = Random.Range(0, 2);

            // Determina la posición de generación aleatoria dentro de la pantalla
            Vector3 spawnPosition = new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 4f), 0f);

            // Genera el ítem según el número aleatorio
            if (randomIndex == 0)
            {
                // Genera un ítem bueno (estrella)
                GameObject star = Instantiate(ItemGoodPrefab, spawnPosition, Quaternion.identity);
                star.tag = "ItemGood"; // Asigna la etiqueta "ItemGood"
            }
            else
            {
                // Genera un ítem malo (oso)
                GameObject bear = Instantiate(ItemBadPrefab, spawnPosition, Quaternion.identity);
                bear.tag = "ItemBad"; // Asigna la etiqueta "ItemBad"
            }
        }
    }
}