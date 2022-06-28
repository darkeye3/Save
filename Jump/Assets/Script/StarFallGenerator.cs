using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarFallGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject starfallPrefab;
    float minspan = 3.5f;
    float maxspan = 8.0f;
    float span;
    float delta = 0;
    // Start is called before the first frame update
    void Start()
    {
        span = Random.Range(minspan, maxspan);
    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;
        if (delta > span)
        {
            delta = 0;
            GameObject go = Instantiate(starfallPrefab) as GameObject;
            int px = Random.Range(-1, 2);
            if(px > 0.3)
            {
                px = 2;
            }
            else if(px < -0.3)
            {
                px = -2;
            }
            else
            {
                px = 0;
            }

            go.transform.position = new Vector3(px, 70, 0);
        }
    }
}
