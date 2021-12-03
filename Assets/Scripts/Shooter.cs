using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public GameObject missilePrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float side = -0.75f;
            if (Random.Range(0, 2) == 1)
                side = 0.75f;
            Vector3 spawnPos = new Vector3(transform.position.x + side, 0, transform.position.z + 0.75f);
            GameObject missile = Instantiate(missilePrefab, spawnPos, new Quaternion(0f, 0f, 0f, 0f));
            missile.GetComponent<Rigidbody>().AddForce(transform.forward*1000, ForceMode.Acceleration);
        }
    }
}
