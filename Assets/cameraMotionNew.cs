using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMotionNew : MonoBehaviour
{

    [SerializeField]
    private Transform Target; //Player
    [SerializeField]
    private Transform cameraTransform;
    [SerializeField]
    private Transform mouseTarget;
    [SerializeField]
    private Vector3 Offset;
    [SerializeField]
    private float smoothTime;
    

    private Vector3 velocity = Vector3.zero;


    // Update is called once per frame
    private void Update()
    {
        Vector3 targetPosition = Target.position + Offset;
        targetPosition.z = cameraTransform.position.z;
        cameraTransform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        //transform.LookAt(mouseTarget); NE PAS UTILISER car la souris utilise la position sur l'écran donc big feedback loop
    }
}
