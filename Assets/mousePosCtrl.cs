using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousePosCtrl : MonoBehaviour
{
    public float zDepth = 2f;
    float sphereRadius = 0.1f;
    int layerMask;
    int maxScreenX = Screen.width;
    int maxScreenY = Screen.height;
    
    
    public float windowSize = 0.2f;
    
    float screenXwindow;
    float screenYwindow;
    
    Vector2 screenCenter;

    public float minAllowedY = -1f;
    public float maxAllowedY = 8f;

    float minX;
    float minY;
    float maxX;
    float maxY;

    void Start()
    {
        screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        screenXwindow = Screen.width * windowSize;
        screenYwindow = Screen.height * windowSize;
        layerMask = LayerMask.GetMask("environnementColliders");
        minX = screenCenter.x - screenXwindow;
        maxX = screenCenter.x + screenXwindow;
        minY = screenCenter.y - screenYwindow;
        maxY = screenCenter.y + screenYwindow;
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        // clamp (saturate) the values of the mouse position to our defined window
        mousePos.x = Mathf.Clamp(mousePos.x, minX, maxX);
        mousePos.y = Mathf.Clamp(mousePos.y, minY, maxY);

        // Note: the above also ends up clamping the speed of our character. 

        mousePos.z = zDepth; //manually setting the z position
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos); // mapping the mouse position on the screen to a point in the scene
        worldPosition.y = Mathf.Clamp(worldPosition.y, minAllowedY, maxAllowedY);

        Collider[] colliders = Physics.OverlapSphere(worldPosition, sphereRadius, layerMask);

        if (colliders.Length == 0) // make sure the cube is not inside any collider
        {
            transform.position = worldPosition; 
        }
    }
}
