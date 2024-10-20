using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
    public int coinCount = 0;
    public TextMeshProUGUI scoreText;
    public Vector3 posOffset = new Vector3(0f, 0f, -5f);
    public float deathBarrier = .5f;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        m_trueLev = m_meanLev; // remains from a oscillating levitation idea that was too complex to put into place with rigidbodies
        m_Rigidbody.AddForce(Vector3.up * m_trueLev);

        Vector3 mouseTargetPosition = mouseTarget.transform.position + posOffset;
        Quaternion targetRotation = Quaternion.LookRotation(Camera.main.transform.up);

        m_Rigidbody.MovePosition(transform.position + (mouseTargetPosition - transform.position) * Time.deltaTime * m_Speed);

        Debug.Log(transform.position.z);
        if (transform.position.z < deathBarrier)
        {
            Die();
        }

        // Apply the rotation smoothly by using Lerp for a smooth transition
        Quaternion newRotation = Quaternion.Slerp(transform.rotation, targetRotation, Quaternion.Angle(transform.rotation, targetRotation)* Time.deltaTime * m_angleSpeed);
        m_Rigidbody.MoveRotation(newRotation);
    }

    public void AddCoin()
    {
        coinCount++;
        UpdateScoreUI();
    }

    public void UpdateScoreUI()
    {
        scoreText.text = "Score: " + coinCount.ToString();
    }

    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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