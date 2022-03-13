using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatform : MonoBehaviour
{
    Animator anima;
    void Start()
    {
        anima = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            anima.SetBool("collisiom", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            anima.SetBool("collisiom", false);
        }
    }
}
