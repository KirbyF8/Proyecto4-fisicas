using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_sc : MonoBehaviour
{


  
    [SerializeField] private float cameraspeed = 35f;

    private float HorizontalInput;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");

        
        transform.Rotate(Vector3.up, cameraspeed * -HorizontalInput * Time.deltaTime);
    }

}
