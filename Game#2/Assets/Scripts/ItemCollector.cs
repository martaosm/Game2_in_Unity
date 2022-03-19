using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int apples = 0;
    private int pineapples = 0;
    private int melons = 0;
    private int points = 0;
    [SerializeField] private Text pointsText;
    [SerializeField] private AudioSource pointsSound;
    void Update()
    {
        OnTriggerEnter2D(GetComponent<Collider2D>());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple") || collision.gameObject.CompareTag("Pineapple") || collision.gameObject.CompareTag("Melon"))
        {
            Destroy(collision.gameObject);
            if (collision.gameObject.CompareTag("Apple"))
            {
                apples++;
                points++;
            }
            if (collision.gameObject.CompareTag("Pineapple"))
            {
                pineapples = pineapples + 10;
                points = points + 10;
            }
            if (collision.gameObject.CompareTag("Melon"))
            {
                melons = melons + 20;
                points = points + 20;
            }
            pointsSound.Play();
            pointsText.text = "Points: " + points;
        }
    }
}
