using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
   
    public static int maximumAmount;
    public static int currentAmount;
    public GameObject spawnPoint;
    public GameObject NPC;
    public bool isSpawner;

    public static int spawnRate=2;
    
    // Start is called before the first frame update
    void Start()
    {
        currentAmount = 0;
        maximumAmount = SliderText.nSus + SliderText.nSusM + SliderText.nVac + SliderText.nInfected + SliderText.nNormal + SliderText.nNormalM;
        Debug.Log(SliderText.nSus);
        InvokeRepeating("SpawnNPC", 3f, 3f);
    }

    // Update is called once per frame
    private void Update()
    {
       
    }

    public int amountOfPeople()
    {
        return currentAmount;
    }
    public void setAmountOfPeople(int number)
    {
        currentAmount = number;
    }



    public void SpawnMob()
    {
        Citizen.IncreaseCitizen();
        maximumAmount = SliderText.nSus + SliderText.nSusM + SliderText.nVac + SliderText.nInfected + SliderText.nNormal + SliderText.nNormalM;
        for (int i = 0; i <= 6; i++)
        {
            Instantiate(NPC, new Vector3(spawnPoint.transform.position.x, 1.03f, 0), Quaternion.identity);
        }  
    }

    void SpawnNPC()
    {

        // if (Countdown.levelCleared == true)
        // {
        Debug.Log("tried");
        if (isSpawner)
            {
                if (currentAmount < maximumAmount)
                {

                    int randomizer = Random.Range(-1, spawnRate);
                   if (randomizer == 0)
                    {
                        Debug.Log("spawned");
                        currentAmount++;
                        Instantiate(NPC, new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z), Quaternion.identity);

                   }

                }
            }


        }
       
       
        
    //}
}
