using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireButton : MonoBehaviour
{
    public Animator anima;
    public void turnOff()
    {
        anima.SetBool("on",false);
    }
}
