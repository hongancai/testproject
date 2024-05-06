using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LionStatueController : MonoBehaviour
{
    public Text healthText;
    public GameObject restartButton;
    private int health = 3;

    private void Start()
    {
        UpdateHealthText();
    }

    private void UpdateHealthText()
    {
        healthText.text = "風獅爺HP : " + health;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Storm"))
        {
            health--;
            UpdateHealthText();

            if (health <= 0)
            {
                // Cube loses all health, show restart button
                restartButton.SetActive(true);
            }
        }
    }

    public void RestartGame()
    {
        health = 3;
        UpdateHealthText();
        restartButton.SetActive(false);
    }
}
