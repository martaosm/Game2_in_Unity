using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnAndOff : MonoBehaviour
{
    public Collider2D swi;
    public Animator[] anima;
    public bool isOn = true;
    private bool timerOn = false;
    public float timeToJump = 5f;
    public Text timerText;

    public GameObject fire;

    public int id;

    private void Start()
    {
        for (int i = 0; i < anima.Length; i++)
        {
            anima[i].SetBool("on",true); 
            anima[i].SetBool("off",false); 
        }
        GameEvents.current.onFireTriggerEnter += onSwitchEnter;

    }
    private void Update()
    {
        if (timerOn == true)
        {
            timer();
        }

        if (timerOn == false)
        {
            timeToJump = 5f;
        }
    }
    private void onSwitchEnter(int id)
    {
        if (id == this.id)
        {

            for (int i = 0; i < anima.Length; i++)
            {
                anima[i].SetBool("off", true);
                anima[i].SetBool("on", false);

            }

            fire.GetComponent<Collider2D>().enabled = false;
            timerOn = true;
        }
    }

    private void timer()
    { 
        timerText.enabled = true;
        if (timeToJump > 0)
        {
            timeToJump -= Time.deltaTime;
        }
    
        if (timeToJump < 0)
        {
            for (int i = 0; i < anima.Length; i++)
            { 
                anima[i].SetBool("off",false); 
                anima[i].SetBool("on",true);
            }
            fire.GetComponent<Collider2D>().enabled = true;
            timerOn = false;
            timerText.enabled = false;
        }
    
        double x = System.Math.Round(timeToJump, 0);
        timerText.text = x.ToString();
    }
}
