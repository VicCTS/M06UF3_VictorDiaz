using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPosition;

    public float spanwRate = 0.5f;

    public float timer;
    public float waitTime = 2f;

    private bool activateSpawn = false;

    void Start()
    {
        //Llama a una funcion despues de x segundos
        //Invoke("SpawnEnemy", 1f);
        //Llama a una funcion despues de x segundos de forma repetida
        //InvokeRepeating("SpawnEnemy", 1f, spanwRate);
    }

    // Update is called once per frame
    void Update()
    {
        if(activateSpawn)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        // += Coge el valor actual de la variable y le suma Time.deltaTime
        timer += Time.deltaTime;

        //Esto es lo mismo de arriba
        //timer = timer + Time.deltaTime;

        if(timer >= waitTime)
        {
            //Instantiate(enemyPrefab, spawnPosition.position, spawnPosition.rotation);

            /*
            Instantiate(enemyPrefab, spawnPosition[0].position, spawnPosition[0].rotation);
            Instantiate(enemyPrefab, spawnPosition[1].position, spawnPosition[1].rotation);
            */

            for(int i = 0; i < spawnPosition.Length; i++)
            {
                Instantiate(enemyPrefab, spawnPosition[i].position, spawnPosition[i].rotation);
            }

            timer = 0;
        }
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            activateSpawn = true;
        }
    }
}
