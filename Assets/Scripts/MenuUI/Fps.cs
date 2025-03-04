using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Fps : MonoBehaviour
{
  TextMeshProUGUI TextMeshProUGUI;
    private float delta;

    void Start()
    {
        TextMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }
    // Update is called once per frame
    void Update()
    {
        delta += (Time.unscaledDeltaTime - delta) * 0.1f;
        float fps = 1.0f / delta;
        TextMeshProUGUI.text = $"fps : {Mathf.Ceil(fps)}";
    }
}
