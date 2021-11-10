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

    public static int nVac=1;
    public static int nNormal=1;
    public static int nNormalM=1;
    public static int nSus=1;
    public static int nSusM=1;
    public static int nInfected=1;

   

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<TextMeshProUGUI>().SetText("1");
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
