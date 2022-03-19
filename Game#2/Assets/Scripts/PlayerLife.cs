using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private AudioSource deathSound;
    private Animator anima;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        { 
            Death();
        }
    }
    private void Death()
    {
        rb.bodyType = RigidbodyType2D.Static;
        deathSound.Play();
        anima.SetTrigger("death");
        Invoke("turnOff", 1f);
        Invoke("RestartLevel", 2f);
    }

    private void turnOff()
    {
        this.gameObject.SetActive(false);
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
