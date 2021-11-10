using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectPeople : MonoBehaviour
{

    private void OnTriggerEnter(Collider col)
    {
        
        calculateChance(col);
    }
    private void OnTriggerExit(Collider col)
    {
        calculateChance(col);
    }


    public void calculateChance(Collider col)
    {
        if (col.gameObject.layer == 3)
        {
            Citizen person = col.gameObject.GetComponent<Citizen>();
            if (person.getSprite() == 2 || person.getSprite() == 5)
            {
                return;
            }
            int randomizer = -1;
            switch (person.getSprite())
            {
                case 0:
                    randomizer = Random.Range(0, 7);
                    break;
                case 1:
                    randomizer = Random.Range(0, 9);
                    break;
                case 3:
                    randomizer = Random.Range(0, 4);
                    break;
                case 4:
                    randomizer = Random.Range(0, 6);
                    break;
            }
            if (randomizer == 0)
            {
                person.editSprite(5);
                if (LoadLevel.special)
                {
                    GiveMasks.score -= 2;
                }
            }


        }
    }



    }
