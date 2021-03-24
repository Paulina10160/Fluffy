using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWalls : MonoBehaviour
{
    public Transform scrollContainer;
    public GameObject prefab;
    public float spawnTimeMin;
    public float spanwTimeMax;
    public float offsetMin;
    public float offsetMax;


    private float lastSpawnTime;
    private float spawnTime;

    // Update is called once per frame
    void Update()
    {
        if(Time.time - lastSpawnTime > spawnTime)
        {
            lastSpawnTime = Time.time;
            spawnTime = Random.Range(spawnTimeMin, spanwTimeMax);
            var obj = Instantiate(prefab, scrollContainer);
            obj.transform.position = new Vector3(transform.position.x, transform.position.y + Random.Range(offsetMin, offsetMax), transform.position.z);
        }
    }
}
