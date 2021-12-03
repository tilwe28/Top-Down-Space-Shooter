using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{

    private float time;
    public static int Score;
    private Text livesText;
    private int lives;
    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        Score = 0;
        livesText = GameObject.Find("Lives").GetComponent<Text>();
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, 0, -7);
        time += Time.deltaTime;
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && GetComponent<Rigidbody>().position.x > -20)
        {
            transform.Translate((Vector3.left) * Time.deltaTime * 20);
            float z = Input.GetAxis("Horizontal") * -30.0f;
            Vector3 euler = transform.localEulerAngles;
            euler.z = Mathf.Lerp(euler.z, z, 60 * Time.deltaTime);
            transform.localEulerAngles = euler;
            //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z + time);
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
            transform.Translate((Vector3.right) * Time.deltaTime * 20);
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == GameObject.Find("SpaceshipSpecular(Clone)"))
        {
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            lives--;
            livesText.text = "Lives: " + lives;
            if (lives == 0)
            {
                UnityEditor.EditorApplication.isPlaying = false;
                Application.Quit();
            }
        }
    }
}
