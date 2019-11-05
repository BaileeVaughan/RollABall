using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class EnemySpawner : NetworkBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval;

    public override void OnStartServer()
    {
        InvokeRepeating("SpawnEnemy", spawnInterval, spawnInterval);
    }

    // Update is called once per frame
    void SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-4f, 4f), this.transform.position.y, Random.Range(-4f, 4f));
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity) as GameObject;
        NetworkServer.Spawn(enemy);
        Destroy(enemy, 10);
    }
}
