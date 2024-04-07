using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrecerArbol : MonoBehaviour
{
    //var maxSize : 
    float maxSize;
    //var growRate:
    float growRate;
    //var scale :
    float scale = 0.0f;
    //Color[] colorVariations;
    // Start is called before the first frame update
    void Start()
    {
        maxSize = Random.Range(1.0f, 1.5f); //2.0 , 6.0
        growRate = Random.Range(1.0f, 1.5f);
        //this.transform.Find("Tree 1").GetComponent<Renderer>();//.material.color = colorVariations[Random.Range(0, colorVariations.Length)];

        //this.transform.Find("Tree 1").renderer.material.color = colorVariations[Random.Range(0, (colorVariations.Length))];
    }

    // Update is called once per frame
    void Update()
    {
        if (scale < maxSize)
        {
            this.transform.localScale = Vector3.one * scale;
            scale += growRate * Time.deltaTime;
        }
    }
}
