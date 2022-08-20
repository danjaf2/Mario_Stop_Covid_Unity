using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
[ExecuteInEditMode()]
public class PanicMeter : MonoBehaviour
{
    public int value;
    public int min;
    public int max;
    public Image filling;
    public Image mask;
   
    public static int maximum;
   


  
    void Update()
    {
        maximum = max;
        getFill();
    }

    void getFill()
    {
        value=InfectPeople.panic;
        float mOffSet = max - min;
        float offSet = value - min;
        float fill = offSet / mOffSet;
        mask.fillAmount = Mathf.Clamp(fill, 0, 1);
    }
}
