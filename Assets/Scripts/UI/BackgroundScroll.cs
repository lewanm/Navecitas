using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackgroundScroll : MonoBehaviour
{


    float moveVelocity = 1;
    [SerializeField] GameObject ObjectBelow;
    void Start()
    {

    }
    void Update()
    {

        if (transform.position.y <= -10)
        {
            transform.position = ObjectBelow.transform.position + new Vector3(0, 10, 0);
        } 

        transform.position += new Vector3(0, -moveVelocity * Time.deltaTime, 0);

        
    }
}
