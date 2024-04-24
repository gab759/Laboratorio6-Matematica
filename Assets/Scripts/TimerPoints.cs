using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerPoints : MonoBehaviour
{
    private float points;
    private TextMeshProUGUI _compTextMesh;
    private void Awake()
    {
        _compTextMesh = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        points = points + Time.deltaTime;
        _compTextMesh.text = points.ToString("Puntos: 0");
    }
}
