using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public GameObject platformPrefab;
    public float counter = 0;
    public float initialSpawnHeight = 0.0f;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
       // platformPrefab = GameObject.Find("Platform");
    }

    // Update is called once per frame
    void Update()
    {
       platformPrefab = GetComponent<GameObject>();
    }

     void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("Collision detected");
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("Player collided with platform.");
                PlatformSpanner();
            }
        }


    void PlatformSpanner()
    {
        for (counter = 0; counter < 10; counter++)
        {
            Debug.Log("Counter is :" + counter);
            Vector2 spawnPosition = new Vector2(Random.Range(-40, 40), initialSpawnHeight);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            Debug.Log("New platform spawned...");
            initialSpawnHeight = initialSpawnHeight + 13.0f;
        }
    }
}
