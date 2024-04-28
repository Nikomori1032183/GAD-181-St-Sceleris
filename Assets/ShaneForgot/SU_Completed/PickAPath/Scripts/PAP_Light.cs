using OpenCover.Framework.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class PAP_Light : MonoBehaviour
{
    Color colour = Color.red;
    Light plight;
    float fadeTime = 0;
    float fadeStart = 0;
    bool firstColour;

    // Start is called before the first frame update
    void Start()
    {
        plight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        policeLight(plight);
    }

    public void policeLight(Light Light, Color colour1, Color colour2, float fadeLength)
    {
        if (fadeTime == 0)
        {
            fadeTime = fadeLength;
        }

        if (colour == colour1)
        {
            fadeStart = 0;
            firstColour = true;
        }
        if (colour == colour2)
        {
            fadeStart = 0;
            firstColour = false;
        }

        fadeStart += Time.deltaTime * fadeTime;

        if (firstColour)
        {
            colour = Color.Lerp(colour1, colour2, fadeStart);
        }
        if (!firstColour)
        {
            colour = Color.Lerp(colour2, colour1, fadeStart);
        }

        Light.color = colour;
    }

    public void policeLight(Light light)
    {
        policeLight(light, Color.red, Color.cyan, 2);
    }

    public void policeLight(Light light, int fadeLength)
    {
        policeLight(light, Color.red, Color.cyan, fadeLength);
    }

    public void policeLight(Light light, Color colour1, Color colour2)
    {
        policeLight(light, colour1, colour2, 2);
    }
}
