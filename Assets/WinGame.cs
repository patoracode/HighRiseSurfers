using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    public ExitButton exitButton;

    void OnTriggerEnter(Collider other)
    {
        // Check if the object colliding with the coin has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // exit the game
            exitButton.doExitGame();
        }
    }
}
