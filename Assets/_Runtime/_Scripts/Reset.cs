using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Citizen.normalTotal = 0;
        Citizen.mNormalTotal = 0;
        Citizen.mSusTotal = 0;
        Citizen.susTotal = 0;
        Citizen.infectedTotal = 0;
        Citizen.vacTotal = 0;
        Citizen.speedMultipler = 1;

        SliderText.nVac = 1;
        SliderText.nNormal = 1;
        SliderText.nNormalM = 1;
        SliderText.nSus = 1;
        SliderText.nSusM = 1;
        SliderText.nInfected = 1;

        SpawnerSelect.spawner1 = true;
        SpawnerSelect.spawner2 = true;
        SpawnerSelect.spawner3 = true;
        SpawnerSelect.spawner4 = true;
        SpawnerSelect.spawner5 = true;
        SpawnerSelect.spawner6 = true;
        SpawnerSelect.spawner7 = true;
        SpawnerSelect.spawner8 = true;
    }
    public void Exit()
    {
        Application.Quit();
    }

  
}
