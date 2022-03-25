using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    //public GameObject rampSwitch;
    public GameObject ramp;
    void Start()
    {
        ramp.GetComponent<Collider2D>().isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            ramp.GetComponent<Collider2D>().isTrigger = false;
        }
    }
}
