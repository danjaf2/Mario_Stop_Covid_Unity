using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnabling : MonoBehaviour
{
    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;
    public GameObject spawn5;
    public GameObject spawn6;
    public GameObject spawn7;
    public GameObject spawn8;
    void Start()
    {
        spawn1.GetComponent<EnemySpawn>().isSpawner = SpawnerSelect.spawner1;
        spawn2.GetComponent<EnemySpawn>().isSpawner = SpawnerSelect.spawner2;
        spawn3.GetComponent<EnemySpawn>().isSpawner = SpawnerSelect.spawner3;
        spawn4.GetComponent<EnemySpawn>().isSpawner = SpawnerSelect.spawner4;
        spawn5.GetComponent<EnemySpawn>().isSpawner = SpawnerSelect.spawner5;
        spawn6.GetComponent<EnemySpawn>().isSpawner = SpawnerSelect.spawner6;
        spawn7.GetComponent<EnemySpawn>().isSpawner = SpawnerSelect.spawner7;
        spawn8.GetComponent<EnemySpawn>().isSpawner = SpawnerSelect.spawner8;
    }

    
}
