using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpIndicator_sc : MonoBehaviour
{

    // [SerializeField] private Transform Player;
    
    void Update()
    {
        transform.rotation = Quaternion.identity;


    }
    /* La manera correcta
    private void LateUpdate()
    {
        transform.position = Player.position;
    }
    */
}
