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

    [SerializeField] private float startDelay = 2f;
    private float spawnInterval = 2.4f;
   
    // Start is called before the first frame update

    private void Start()
    {
        Enemy_Limiter = 3;
        PowerUpE = true;
        InvokeRepeating("SpawnEnemy", startDelay, spawnInterval);
        InvokeRepeating("SpawnPowerUp", startDelay * 2, spawnInterval);
    }
    private void SpawnEnemy()
    {
        PlacementX = Random.Range(-cameraLimitx, cameraLimitx);
        PlacementY = Random.Range(-cameraLimity, cameraLimity);
        if (Enemy_Limiter >= 0)
        {
            Instantiate(Enemy, new Vector3(PlacementX, 0, PlacementY), Quaternion.Euler(0, 0, 0));
            Enemy_Limiter--;
            
        }
    }

    private void SpawnPowerUp()
    {
        PlacementX = Random.Range(-cameraLimitx, cameraLimitx);
        PlacementY = Random.Range(-cameraLimity, cameraLimity);
        
       
        if (PowerUpE)
        {
            Instantiate(PowerUp, new Vector3(PlacementX, 0, PlacementY), Quaternion.Euler(0, 0, 0));
            PowerUpE = false;
        }
    }
}
