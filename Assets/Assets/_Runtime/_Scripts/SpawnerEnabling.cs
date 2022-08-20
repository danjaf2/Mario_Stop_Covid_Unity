using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnabling : MonoBehaviour
{
    public GameObject[] spawn1;
    public GameObject[] spawn2;
    public GameObject[] spawn3;
    public GameObject[] spawn4;
    
    void Start()
    {

        for (int i = 0; i < spawn1.Length; i++)
        {
            spawn1[i].GetComponent<EnemySpawn>().isSpawner = SpawnerSelect.spawner1;
        }
        for (int i = 0; i < spawn2.Length; i++)
        {
            spawn2[i].GetComponent<EnemySpawn>().isSpawner = SpawnerSelect.spawner2;
        }
        for (int i = 0; i < spawn3.Length; i++)
        {
            spawn3[i].GetComponent<EnemySpawn>().isSpawner = SpawnerSelect.spawner3;
        }
        for (int i = 0; i < spawn4.Length; i++)
        {
            spawn4[i].GetComponent<EnemySpawn>().isSpawner = SpawnerSelect.spawner4;
        }
    }

    
}
