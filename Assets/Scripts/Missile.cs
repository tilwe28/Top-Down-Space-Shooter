using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Missile : MonoBehaviour
{

    public GameObject explosionPrefab;
    private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z >= 12)
            Destroy(gameObject);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (!(collision.gameObject == GameObject.Find("Voyager") || collision.gameObject == GameObject.Find("PfCruiseMissile(Clone)")))
        {
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            scoreText.text = "Score: " + ++Movement.Score;
            Destroy(gameObject);
        }
    }
}
