using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallExplosion : MonoBehaviour
{

    private float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (gameObject == GameObject.Find("BigExplosionEffect(Clone)") && time>=1)
        {
            Destroy(gameObject);
            time = 0;
        }
        if (time>=0.5 && gameObject == GameObject.Find("SmallExplosionEffect(Clone)")) {
            Destroy(gameObject);
            time = 0;
        }
    }
}
