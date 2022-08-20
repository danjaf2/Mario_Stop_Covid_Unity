using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerSelect : MonoBehaviour
{
    public static bool spawner1 = true;
    public static bool spawner2 = true;
    public static bool spawner3 = true;
    public static bool spawner4 = true;

    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;
    
   

    // Update is called once per frame
    void Update()
    {
        spawner1 = spawn1.GetComponent<Toggle>().isOn;
        spawner2 = spawn2.GetComponent<Toggle>().isOn;
        spawner3 = spawn3.GetComponent<Toggle>().isOn;
        spawner4 = spawn4.GetComponent<Toggle>().isOn;
    }
}
