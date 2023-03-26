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

    public void Visible(){
        spriteRenderer.color = new Color32(255,255,255,255);
        textMesh.color = new Color32(0,0,0,255);
    }
}
