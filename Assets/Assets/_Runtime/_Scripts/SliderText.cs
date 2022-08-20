using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SliderText : MonoBehaviour
{

  
    private enum citizenState
    {
        Normal,
        mNormal,
        Vac,
        Sus,
        mSus,
        Infected
    }
    public int selectedEnum;

    public static int nVac=5;
    public static int nNormal=5;
    public static int nNormalM=5;
    public static int nSus=5;
    public static int nSusM=5;
    public static int nInfected=5;

   

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<TextMeshProUGUI>().SetText("5");
    }

    private void Update()
    {
        
    }

    public void changeText(float number)
    {
        this.GetComponent<TextMeshProUGUI>().SetText(number.ToString());

        switch (selectedEnum)
        {
            case 0:
                nNormal = (int)number;
                break;
            case 1:
                nNormalM = (int)number;
                break;
            case 2:
                nVac = (int)number;
                break;
            case 3:
                nSus = (int)number;
                break;
            case 4:
                nSusM = (int)number;
                break;
            case 5:
                nInfected= (int)number;
                break;

        }
    }
}
