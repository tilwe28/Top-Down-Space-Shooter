using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private bool changedDir;

    // Start is called before the first frame update
    void Start()
    {
        changedDir = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z <= 3.5 && transform.position.z > 3.3 && transform.position.x > 0 && !changedDir)
        {
            GetComponent<Rigidbody>().AddForce(transform.right * 300, ForceMode.Acceleration);
            changedDir = true;
        }
        if (transform.position.z <= 3.5 && transform.position.z > 3.3 && transform.position.x < 0 && !changedDir)
        {
            GetComponent<Rigidbody>().AddForce(-1 * transform.right * 300, ForceMode.Acceleration);
            changedDir = true;
        }
        if (transform.position.z <= -11)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
