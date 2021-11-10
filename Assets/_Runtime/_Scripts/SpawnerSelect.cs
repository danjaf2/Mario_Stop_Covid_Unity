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
    public static bool spawner5 = true;
    public static bool spawner6 = true;
    public static bool spawner7 = true;
    public static bool spawner8 = true;

    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;
    public GameObject spawn5;
    public GameObject spawn6;
    public GameObject spawn7;
    public GameObject spawn8;
   

    // Update is called once per frame
    void Update()
    {
        spawner1 = spawn1.GetComponent<Toggle>().isOn;
        spawner2 = spawn2.GetComponent<Toggle>().isOn;
        spawner3 = spawn3.GetComponent<Toggle>().isOn;
        spawner4 = spawn4.GetComponent<Toggle>().isOn;
        spawner5 = spawn5.GetComponent<Toggle>().isOn;
        spawner6 = spawn6.GetComponent<Toggle>().isOn;
        spawner7 = spawn7.GetComponent<Toggle>().isOn;
        spawner8 = spawn8.GetComponent<Toggle>().isOn;
    }
}
