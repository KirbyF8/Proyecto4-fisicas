using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Enemy_sc : MonoBehaviour
{
    [SerializeField] float EnemySpeed = 5f;
    private Rigidbody enemyRigidbody;
    private GameObject player_go;

    private SpawManage_sc spawnmanager;
    private Player_s Player;

    [SerializeField] private GameObject focalpoint_go;
    private void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
        player_go = GameObject.Find("Player");
        Player = FindObjectOfType<Player_s>();
        spawnmanager = FindObjectOfType<SpawManage_sc>();
    }


    // Update is called once per frame
    void Update()
    {
        if (!Player.GetGameOver())
        {
           GoToPlayer();
        }


        if (transform.position.y < -2.9)
        {
            spawnmanager.EnemyDestroyed();
            Destroy(gameObject);


        }

    }

    private void GoToPlayer()
    {
        if (spawnmanager.GameHasStarted) 
        
        {
            Vector3 direction = (player_go.transform.position - transform.position).normalized;

            enemyRigidbody.AddForce(direction * EnemySpeed, ForceMode.Force);
        }
      

    }

}
