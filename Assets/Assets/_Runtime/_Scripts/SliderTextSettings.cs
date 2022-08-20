using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SliderTextSettings : MonoBehaviour
{


    public int barNumber;

    // Start is called before the first frame update
    void Start()
    {
        if (barNumber == 0)
        {
            this.GetComponent<TextMeshProUGUI>().SetText("1");
        }
        else if (barNumber == 1)
        {
            this.GetComponent<TextMeshProUGUI>().SetText("0.5");
        }
        else if (barNumber == 2)
        {
            this.GetComponent<TextMeshProUGUI>().SetText("2");
        }

    }

    private void Update()
    {

    }

    public void changeText(float number)
    {
        if (barNumber==0|| barNumber == 1)
        {
            number = Mathf.Round(number * 100f) / 100f;
        }
        this.GetComponent<TextMeshProUGUI>().SetText(number.ToString());

        if (barNumber == 0)
        {
            Citizen.speedMultipler = number;
        }
        else if (barNumber == 1)
        {
            Countdown.speedIncreasePerRound=number;
        }
        else if (barNumber == 2)
        {
            EnemySpawn.spawnRate = (int)number;
        }
    }
}
