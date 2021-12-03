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
    private Quaternion startRotation, tilt;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        Score = 0;
        livesText = GameObject.Find("Lives").GetComponent<Text>();
        lives = 3;
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0);
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, 0, -7);
        time += Time.deltaTime;
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && GetComponent<Rigidbody>().position.x > -20)
        {
            transform.Translate((Vector3.left) * Time.deltaTime * 20);
            if (transform.localEulerAngles.z < 40 || transform.localEulerAngles.z>315)
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z + (time*4));
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            tilt = Quaternion.Euler(startRotation.eulerAngles.x, startRotation.eulerAngles.y, startRotation.eulerAngles.z);
            time = 0;
        }

        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && GetComponent<Rigidbody>().position.x < 20)
        {
            transform.Translate((Vector3.right) * Time.deltaTime * 20);
            if (transform.localEulerAngles.z > 320 || transform.localEulerAngles.z < 45)
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z - (time*4));
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            tilt = Quaternion.Euler(startRotation.eulerAngles.x, startRotation.eulerAngles.y, startRotation.eulerAngles.z);
            time = 0;
        }
        if (!Input.anyKey)
        {
            time = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, tilt, Time.deltaTime * 10);
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
