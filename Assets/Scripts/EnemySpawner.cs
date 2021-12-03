using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    private float time, r;
    private bool ship1, ship2;
    private int numSpawned;

    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;

        ship1 = true;
        ship2 = true;
        numSpawned = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 5)
        {
            GameObject enemy = Instantiate(enemyPrefab, new Vector3(r, 0, 12), transform.rotation);
            enemy.GetComponent<Rigidbody>().AddForce(-1 * transform.forward * 300, ForceMode.Acceleration);
            time = 0;
            ship1 = true;
            ship2 = true;
            print("Spawned: " + numSpawned++);
        }
        else if (time >= 4.5 && ship2)
        {
            GameObject enemy = Instantiate(enemyPrefab, new Vector3(r, 0, 12), transform.rotation);
            enemy.GetComponent<Rigidbody>().AddForce(-1 * transform.forward * 300, ForceMode.Acceleration);
            ship2 = false;
            print("Spawned: " + numSpawned++);
        }
        else if (time >= 4 && ship1)
        {
            r = Random.Range(-18, 18);
            GameObject enemy = Instantiate(enemyPrefab, new Vector3(r, 0, 12), transform.rotation);
            enemy.GetComponent<Rigidbody>().AddForce(-1 * transform.forward * 300, ForceMode.Acceleration);
            ship1 = false;
            print("Spawned: " + numSpawned++);
        }
    }
}
