using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackdrop_SU : MonoBehaviour
{
    public float speed = 0.2f;
    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GTTE_Main.GTTEPlaying)
        {
            scroll();
        }
    }

    void scroll()
    {
        meshRenderer.material.mainTextureOffset = new Vector2(Time.time * speed, 0);
    }
}
