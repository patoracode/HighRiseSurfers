using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 50f * Time.deltaTime, 0);

    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object colliding with the coin has the "Player" tag
        if (other.CompareTag("Player"))
        {
            boardController player = other.GetComponent<boardController>();
            if (player != null)
            {
                player.AddCoin();
            }

            // Destroy the coin after being picked up
            Destroy(gameObject);
        }
    }

    
}
