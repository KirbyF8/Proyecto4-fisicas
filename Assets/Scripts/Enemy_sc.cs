using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Enemy_sc : MonoBehaviour
{
    [SerializeField] float EnemySpeed = 5f;
    private Rigidbody enemyRigidbody;
    private GameObject player_go;
  

    [SerializeField] private GameObject focalpoint_go;
    private void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
        player_go = GameObject.Find("Player");
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (player_go.transform.position - transform.position).normalized;

        enemyRigidbody.AddForce(direction * EnemySpeed, ForceMode.Force);

        if (transform.position.y < -2.9)
        {
            Destroy(gameObject);
            
        }
    }
}
