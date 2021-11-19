using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && GetComponent<Rigidbody>().position.x > -20)
        {
            transform.Translate((Vector3.left) * Time.deltaTime * 10);
            float z = Input.GetAxis("Horizontal") * -30.0f;
            Vector3 euler = transform.localEulerAngles;
            euler.z = Mathf.Lerp(euler.z, z, 60 * Time.deltaTime);
            transform.localEulerAngles = euler;
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            float z = Input.GetAxis("Horizontal") * 0;
            Vector3 euler = transform.localEulerAngles;
            euler.z = Mathf.Lerp(euler.z, z, 60 * Time.deltaTime);
            transform.localEulerAngles = euler;
        }

        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && GetComponent<Rigidbody>().position.x < 20)
        {
            transform.Translate((Vector3.right) * Time.deltaTime * 10);
            float z = Input.GetAxis("Horizontal") * -30.0f;
            Vector3 euler = transform.localEulerAngles;
            euler.z = Mathf.Lerp(euler.z, z, 60 * Time.deltaTime);
            transform.localEulerAngles = euler;
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            float z = Input.GetAxis("Horizontal") * 0;
            Vector3 euler = transform.localEulerAngles;
            euler.z = Mathf.Lerp(euler.z, z, 60 * Time.deltaTime);
            transform.localEulerAngles = euler;
        }
    }
}
