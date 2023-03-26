using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSelectUI : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    TextMesh textMesh;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        textMesh = GetComponentInChildren<TextMesh>();
        spriteRenderer.color = new Color32(255,255,255,0);
        textMesh.color = new Color32(255,255,255,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
