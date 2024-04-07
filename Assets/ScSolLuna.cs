using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using System;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Linq.Expressions;


public class ScSolLuna : MonoBehaviour
{
    [SerializeField]
    private GameObject sphere;
    private Renderer sphereRender;
    private Color newSphereColor;
    private float randomChannelOne, randomChannelTwo, randomChannelThree, randomChannelFour;    


    // Start is called before the first frame update
    void Start()
    {
        sphereRender = sphere.GetComponent<Renderer>();
        gameObject.GetComponent<Button>().onClick.AddListener(ChangeSphereColor);
        
    }

    // Update is called once per frame
    void Update()
    {
        SceneManager.LoadScene(2);
    }

    private void ChangeSphereColor()
    {
        //randomChannelOne = Random.Range(214295, 214298);
        //randomChannelTwo = Random.Range(969201, 969204);
        //randomChannelThree = Random.Range(969292, 969294);
        //randomChannelFour = Random.Range(969203, 969206);
        //randomChannelOne = Random.Range(1.0f, 1.0f);
        //randomChannelTwo = Random.Range(1.0f, 0.99f);
        //randomChannelThree = Random.Range(0.0f, 1.0f);        

        //newSphereColor = new Color(randomChannelOne, randomChannelTwo, randomChannelThree, 1f);

        //sphereRender.material.SetColor("_Color", newSphereColor);
        

    }
}
