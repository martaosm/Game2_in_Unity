using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnAndOff : MonoBehaviour
{
    //public BoxCollider2D box;
    public BoxCollider2D[] fire;
    public Collider2D swi;
    //public GameObject fireTrapButton;
    public Animator[] anima;
    public bool isOn = true;
    private bool timerOn = false;
    public float timeToJump = 5f;
    public Text timerText;

    private void Start()
    {
        for (int i = 0; i < anima.Length; i++)
        {
            anima[i].SetBool("on",true); 
            anima[i].SetBool("off",false); 
        }
        
    }

    private void Update()
    {
        OnTriggerEnter2D(swi);
        if (timerOn == true)
        {
            timer();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < anima.Length; i++)
            {
                anima[i].SetBool("off",true); 
                anima[i].SetBool("on",false);
                
            }

            for (int i = 0; i < fire.Length; i++)
            {
                fire[i].enabled = false;
            }
            
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

            for (int i = 0; i < fire.Length; i++)
            {
                fire[i].enabled = true;
            }
            timerOn = false;
            timerText.enabled = false;
        }

        double x = System.Math.Round(timeToJump, 0);
        timerText.text = x.ToString();
    }

}
