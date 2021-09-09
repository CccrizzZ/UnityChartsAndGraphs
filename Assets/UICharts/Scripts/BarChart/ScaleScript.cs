using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScaleScript : MonoBehaviour
{

    public float Data;

    public string S_Data;

    public TextMeshProUGUI ScaleData;

    public bool ShowScaleData;



    void Start()
    {
        // set scale data visibility according to flag
        if (!ShowScaleData) ScaleData.gameObject.SetActive(false);

        // SetStringData(S_Data);
    


    }

    public void SetScaleData(float d)
    {
        Data = Mathf.Round(d);
        ScaleData.SetText(Data.ToString());
    }

    public void SetStringData(string s)
    {
        ScaleData.SetText(s);
    }
}
