using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScAgua : MonoBehaviour
{
    public Animator Tap;
    public GameObject openBtn;
    public GameObject closeBtn;
    public ParticleSystem RunningWater;

    private bool inReach;
    private bool isOpen;
    private bool isClosed;

    // Start is called before the first frame update
    void Start()
    {
        //inReach = false;
        //isClosed = true;
        //isOpen = false;
        //closeBtn.SetActive(false);
        //openBtn.SetActive(false);
        //RunningWater.Stop();

    }

    // Update is called once per frame
    void Update()
    {
        if (inReach && isClosed && Input.GetButtonDown("Interact"))
        {
            Tap.SetBool("Open", true);
            Tap.SetBool("Closed", false);
            openBtn.SetActive(false);
            isOpen = true;
            isClosed = false;
            RunningWater.Play();
        }

        else if (inReach && isOpen && Input.GetButtonDown("Interact"))
        {
            Tap.SetBool("Open", false);
            Tap.SetBool("Closed", true);
            closeBtn.SetActive(false);
            isClosed = true;
            isOpen = false;
            RunningWater.Stop();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach" && isClosed)
        {
            inReach = true;
            openBtn.SetActive(true);
        }

        if (other.gameObject.tag == "Reach" && isOpen)
        {
            inReach = true;
            closeBtn.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openBtn.SetActive(false);
            closeBtn.SetActive(false);
        }
    }

}

