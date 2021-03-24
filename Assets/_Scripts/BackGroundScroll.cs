using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroll : MonoBehaviour
{
    public float scroll_Speed = 0.1f;

    private MeshRenderer mesh;
    private float x_Scroll;

    private void Awake() {
        mesh = GetComponent<MeshRenderer>();
    }

    private void Update() {
        if(PauseMenu.IsPaused){

        }else{
            Scroll();
        }
        
    }

    private void Scroll()
    {
        x_Scroll = Time.time * scroll_Speed;

        Vector2 offset = new Vector2(x_Scroll, 0f);

        mesh.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
