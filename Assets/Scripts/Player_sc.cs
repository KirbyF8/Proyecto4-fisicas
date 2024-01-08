using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_s : MonoBehaviour
{
    [SerializeField] float PlayerSpeed = 15f;
    private Rigidbody playerRigidbody;
    private float verticalInput;

    [SerializeField] private GameObject focalpoint_go;

    private bool hasPowerUp;
    [SerializeField] private float powerUpForce = 100f;


    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        hasPowerUp = false;
    }

    private void Update()
    {
        /* Parar en seco
        if (Mathf.Abs(verticalInput) < 0.01f)
        {
            playerRigidbody.velocity = Vector3.zero;
        }
        */
        verticalInput = Input.GetAxis("Vertical");

        playerRigidbody.AddForce(focalpoint_go.transform.forward * PlayerSpeed * verticalInput, ForceMode.Force);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            hasPowerUp = true;

            StartCoroutine(PowerUpCount());
            
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 Direction = (other.transform.position - transform.position).normalized;

            enemyRigidbody.AddForce(Direction * powerUpForce, ForceMode.Impulse);
        }
    }

    private IEnumerator PowerUpCount()
    {
        
        yield return new WaitForSeconds(6);
        hasPowerUp = false;
    }
}
