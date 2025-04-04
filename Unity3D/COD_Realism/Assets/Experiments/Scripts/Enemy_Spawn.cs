using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    int enemyCount;
    int spawnRate;
    GameObject enemyPrefab;
    private List<Collider> spawnablePlanes = new List<Collider>();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy());
    }

    void Update()
    {
        
    }

    IEnumerator spawnEnemy()
    {
        while (true)
        {
            int no_planes = 0;
            spawnRate = Random.Range(1, 4);
            if (enemyCount < 10)
            {
                Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position, 1f);
                foreach (var collider in colliders)
                {
                    if (collider.tag == "Ground")
                    {
                        spawnablePlanes.Add(collider);
                        no_planes ++;

                    }
                }

                Debug.Log("enemySpawned");
                GameObject enemy = GameObject.Instantiate(enemyPrefab, spawnablePlanes[Random.Range(0, no_planes)].transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
                enemyCount++;                    
                
            }
            yield return new WaitForSeconds(spawnRate);
        }
    }


}
