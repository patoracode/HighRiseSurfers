using UnityEngine;

public class PickupPanneau : MonoBehaviour
{
    public float slowDownDuration = 10f; // slowdown duration in seconds

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object colliding with the sign has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Find all GameObjects with the "Mover" tag
            GameObject[] moverObjects = GameObject.FindGameObjectsWithTag("Mover");
            if (moverObjects != null && moverObjects.Length > 0)
            {
                // Get the Mover component from the first GameObject in the array
                mover moverComponent = moverObjects[0].GetComponent<mover>();
                if (moverComponent != null)
                {
                    // Call the SlowDown method on the Mover component
                    moverComponent.SlowDown(slowDownDuration);
                }
            }

            // Destroy the sign after being picked up
            Destroy(gameObject);
        }
    }
}
