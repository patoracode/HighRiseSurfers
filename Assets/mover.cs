using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour
{
    public float defaultSpeed = .05f;
    public Vector3 velocity = new Vector3(0f, 0f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(0f, 0f, -defaultSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity;
    }



    public void SlowDown(float duration)
    {
        Debug.Log("enter slowdown");

        // Stop any ongoing slow-down coroutine
        StopAllCoroutines();

        // Start a coroutine to slow down and restore the speed
        StartCoroutine(SlowDownRoutine(duration));
    }

    private IEnumerator SlowDownRoutine(float duration)
    {
        Debug.Log("enter slowdown ROUTINE");

        // Halve the speed
        velocity.z = -defaultSpeed * .3f;

        // Wait for the specified duration
        yield return new WaitForSeconds(duration);

        // Restore the original speed
        velocity.z = -defaultSpeed;
    }
}
