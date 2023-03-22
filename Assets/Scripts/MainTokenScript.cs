using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTokenScript : MonoBehaviour{

    private SpriteRenderer spriteRenderer;
    public Sprite face;
    public Sprite back;

    public void OnMouseDown(){
        // flip card on mouseclick
        if (spriteRenderer.sprite == back) {
            spriteRenderer.sprite = face;
        }    
        else{ 
            spriteRenderer.sprite = back;    
        }    
    }

    private void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}