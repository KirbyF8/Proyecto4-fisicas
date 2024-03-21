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
    [SerializeField] private GameObject[] powerUpIndicators; // 3 1 2

    private int Lives = 3;
    private bool GameOver = false;
    private Vector3 initialPosition;

    private UI_sc UIManager;
    private SpawManage_sc spawnmanager;
    private void Awake()
    {
        GameOver = false;
        Lives = 3;
        playerRigidbody = GetComponent<Rigidbody>();
        hasPowerUp = false;
        initialPosition = Vector3.zero;
    }

    private void Start()
    {
        HidePowerUpIndicators();
        spawnmanager = FindObjectOfType<SpawManage_sc>();
        UIManager = FindObjectOfType<UI_sc>();

    }

    private void Update()
    {
       

        if (GameOver)
        {
            return;
        }
        // Movement();
        verticalInput = Input.GetAxis("Vertical");

        playerRigidbody.AddForce(focalpoint_go.transform.forward * PlayerSpeed * verticalInput, ForceMode.Force);

        if (transform.position.y < -3f)
        {
            Lives--;
            if (Lives < 0)
            {
                //Game Over
                UIManager.ShowGameOverPanel();
                GameOver = true;
            } 
            else
            {
                transform.position = initialPosition;
                playerRigidbody.velocity = Vector3.zero;
                StartCoroutine(Invulberavility());
            }
            
        }
    }
    
    private void Movement()
    {
        /* Parar en seco
         if (Mathf.Abs(verticalInput) < 0.01f)
         {
             playerRigidbody.velocity = Vector3.zero;
         }
         */
       
    }

    private IEnumerator Invulberavility()
    {
        playerRigidbody.constraints = RigidbodyConstraints.FreezeAll;//RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        yield return new WaitForSeconds(0.5f);
        playerRigidbody.constraints = RigidbodyConstraints.None;
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
        
        foreach (GameObject indicator in powerUpIndicators)
        {
            indicator.SetActive(true);
        }

        for (int i = 0; i < powerUpIndicators.Length; i++)
        {
            
            yield return new WaitForSeconds(2);
            powerUpIndicators[i].SetActive(false);
        }

        spawnmanager.PowerUpEnd();
        hasPowerUp = false;
    }
   
    private void HidePowerUpIndicators()
    {
        foreach (GameObject indicator in powerUpIndicators)
        {
            indicator.SetActive(false);
        }
    }
    
    public bool GetGameOver()
    {
        return GameOver;
    }
}
