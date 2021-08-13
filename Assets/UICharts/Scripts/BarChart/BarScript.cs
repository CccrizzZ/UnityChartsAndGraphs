using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class BarScript : MonoBehaviour
{


    // the width and max hight of a bar
    public const float BarHight = 350;
    public const float BarWidth = 20;



    // data
    [SerializeField]
    float Data;

    // max data of all bars in the chart
    public float MaxData;


    // text objects
    public TextMeshProUGUI TopTag;
    public TextMeshProUGUI BottomTag;




    // flags
    public bool ShowTopTag;
    public bool ShowBottomTag;


    // bar color
    public Color BarColor;


    void Start()
    {
        // set max data to data if it is not set
        if (MaxData == 0) MaxData = Data;

        // set bar color
        gameObject.GetComponent<Image>().color = BarColor;

        // set bar height
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(BarWidth, BarHight * (Data / MaxData));



        // init or hide top tag
        if (!ShowTopTag)
        {
            TopTag.gameObject.SetActive(false);
        }
        else
        {
            // init top tag
            TopTag.color = BarColor;
            TopTag.SetText(Data.ToString());
        }

        // bottom  tag
        if (!BottomTag) BottomTag.gameObject.SetActive(false);
        



    }

    void Update()
    {
        
    }


    // resize bar
    public void ReSize()
    {
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(BarWidth, BarHight * (Data / MaxData));
    }



    // setters 
    public void setData(float data)
    {
        Data = data;
    }

    public void setBottomTag(string s)
    {
        BottomTag.SetText(s);
    }
    
    public void setColor(Color c)
    {
        GetComponent<Image>().color = c;
    }



}
