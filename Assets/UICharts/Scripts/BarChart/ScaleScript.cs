using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScaleScript : MonoBehaviour
{

    public float Data;

    public TextMeshProUGUI ScaleData;

    public bool ShowScaleData;

    void Start()
    {
        // set scale data visibility according to flag
        if (!ShowScaleData) ScaleData.gameObject.SetActive(false);
    }

    public void SetScaleData(float d)
    {
        Data = d;
        ScaleData.SetText(Data.ToString());
    }
}
