using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    private float time;

    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        float r = Random.Range(-18, 18);
        GameObject enemy = Instantiate(enemyPrefab, new Vector3(r, 0, 12), transform.rotation);
        enemy.GetComponent<Rigidbody>().AddForce(-1 * transform.forward * 300, ForceMode.Acceleration);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        float r = Random.Range(-20, 20);
        if (time >= 7)
        { 
            GameObject enemy = Instantiate(enemyPrefab, new Vector3(r, 0, 12), transform.rotation);
            enemy.GetComponent<Rigidbody>().AddForce(-1 * transform.forward * 300, ForceMode.Acceleration);
            time = 0;
        }
        else if (time >= 6)
        {
            GameObject enemy = Instantiate(enemyPrefab, new Vector3(r, 0, 12), transform.rotation);
            enemy.GetComponent<Rigidbody>().AddForce(-1 * transform.forward * 300, ForceMode.Acceleration);
        }
        else if (time >= 5)
        {
            GameObject enemy = Instantiate(enemyPrefab, new Vector3(r, 0, 12), transform.rotation);
            enemy.GetComponent<Rigidbody>().AddForce(-1 * transform.forward * 300, ForceMode.Acceleration);
        }
    }
}
