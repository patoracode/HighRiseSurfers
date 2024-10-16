using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boardController : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_meanLev = 10f;
    private float m_trueLev;
    //private float currentTime = 0f;
    public float m_Speed = 5f;
    public float m_angleSpeed = 10f;
    public GameObject mouseTarget;
    private Quaternion targetRotation;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        m_trueLev = m_meanLev; // remains from a oscillating levitation idea that was too complex to put into place with rigidbodies
        m_Rigidbody.AddForce(Vector3.up * m_trueLev);

        Vector3 mouseTargetPosition = mouseTarget.transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(Camera.main.transform.forward);

        m_Rigidbody.MovePosition(transform.position + (mouseTargetPosition - transform.position) * Time.deltaTime * m_Speed);

        // Apply the rotation smoothly by using Lerp for a smooth transition
        Quaternion newRotation = Quaternion.Slerp(transform.rotation, targetRotation, Quaternion.Angle(transform.rotation, targetRotation)* Time.deltaTime * m_angleSpeed);
        m_Rigidbody.MoveRotation(newRotation);
    }

    /*
    // collision handler draft

    void OnCollisionEnter(Collision col)
    {
        float repulsion = 300f;
        m_Rigidbody.AddForce(col.contacts[0].normal*repulsion);
    }
    */
    }