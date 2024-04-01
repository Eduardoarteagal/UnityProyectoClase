using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float score;
    private TextMeshProUGUI textMesh;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        score += Time.deltaTime;
        textMesh.text = score.ToString("0");

    }

    public void AddScore()
    {
        score++;
        textMesh.text = score.ToString("0");
    }
}
