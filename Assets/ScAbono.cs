using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScAbono : MonoBehaviour
{
    public GameObject[] prefabs = null;
    public Camera cam = null;

    public GameObject target;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InstantiateObject();
        
    }

    public void Object1()
    {
        target = prefabs[0];
       
    }

    public void Object2()
    {
        target = prefabs[1];
    }

    public void InstantiateObject()
    {
        if (!EventSystem.current.IsPointerOverGameObject()) { 
            if(Input.GetMouseButtonDown(0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if(Physics.Raycast(ray, out hit))
                {
                    Instantiate(target, hit.point, Quaternion.identity);
                }
            }
        }
    }

}
