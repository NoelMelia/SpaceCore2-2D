using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange : MonoBehaviour
{
    [SerializeField]private GameObject cube;
    private Renderer newColour;
    private Color[] colors = new Color[4];
     
     void Start()
    {
        colors[0] = Color.blue;
        colors[1] = Color.red;
        colors[2] = Color.green;
        colors[3] = Color.yellow;
        
        
        newColour = cube.GetComponent<Renderer>();
        newColour.material.color = colors[Random.Range(0, colors.Length)];
    }

    public void ChangeColour(){ 
        newColour.material.color = colors[Random.Range(0, colors.Length)];
        //Debug.Log(newColour.ToString());
        //.SetColor("_Color", colors[Random.Range(0, colors.Length)]);
    }

}
