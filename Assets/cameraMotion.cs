using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMotion : MonoBehaviour
{
    private Vector3 speed;
    private float speedVal = 1f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0f, 0f, 2.75f);
    }

    // Update is called once per frame
    void Update()
    {
        speed.x = Input.GetAxis("Mouse X") * speedVal;
        speed.y = Input.GetAxis("Mouse Y") * speedVal;
        Debug.Log(speed);

        transform.Translate(speed);
    }
}
