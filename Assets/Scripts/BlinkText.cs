using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlinkText : MonoBehaviour
{
    public TextMeshProUGUI pressAnyKey;
    public float blinkTime;
    float startTime;
    bool isVisible;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float elapsedTime = Time.time - startTime;

        Color textColor = pressAnyKey.color;
        textColor.a = isVisible ? 1 - elapsedTime / blinkTime : elapsedTime / blinkTime;
        pressAnyKey.color = textColor;

        if (elapsedTime >= blinkTime)
        {
            isVisible = !isVisible;
            startTime = Time.time;
        }

    }
}
