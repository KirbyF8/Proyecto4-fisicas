using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawManage_sc : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] GameObject PowerUp;

    private float cameraLimitx = 7.5f;
    private float cameraLimity = 7.5f;
    private float PlacementX;
    private float PlacementY;

    public float Enemy_Limiter;
    private bool PowerUpE;
    public bool GameHasStarted;
    
    public int EnemyCount;
    private int EnemyInWave = 1;

    private Player_s Player;

    private void Start()
    {

        GameHasStarted = false;

        PowerUpE = true;
       

        Player = FindObjectOfType<Player_s>();
    }
    private void Update()
    {
        //EnemyCount = FindObjectsOfType<Enemy_sc>().Length;
        if (Player.GetGameOver())
        {
            return;
        }

        if (EnemyCount <= 0 && GameHasStarted == true)
        {
            EnemyInWave++;
            WaveManager(EnemyInWave);
        }
    }

    private void SpawnEnemy()
    {
        PlacementX = Random.Range(-cameraLimitx, cameraLimitx);
        PlacementY = Random.Range(-cameraLimity, cameraLimity);
        Instantiate(Enemy, new Vector3(PlacementX, 0, PlacementY), Quaternion.Euler(0, 0, 0));
    }

    public void GameStart()
    {
        GameHasStarted = true;
        WaveManager(EnemyInWave);
    }
   

    public void EnemyDestroyed()
    {
        EnemyCount--;
    }

    public void PowerUpEnd()
    {
        
        PowerUpE = true;
    }

    private void WaveManager(int Enemies)
    {
        for (int i = 0; i < Enemies; i++)
        {
           
            SpawnEnemy();
            EnemyCount++;
            
            if (PowerUpE)
            {
                Instantiate(PowerUp, new Vector3(PlacementX, 0, PlacementY), Quaternion.Euler(0, 0, 0));
                PowerUpE = false;
            }
        }
    }

    public void ResetValues()
    {
        Player.ResetValues();
        EnemyInWave = 1;
        EnemyCount = 1;
        SpawnEnemy();
        
    }
}
