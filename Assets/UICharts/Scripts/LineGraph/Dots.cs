using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


// Dots controller
public class Dots : MonoBehaviour
{

    const float maxHeight = 350f;

    // this dot's data
    [SerializeField] float data;


    // biggest number in the data array
    float MaxData;

    public GameObject DotObj;


    [SerializeField] TextMeshProUGUI IndicatorText;


    [SerializeField] LineRenderer Line;

    public GameObject NextDot;
    public GameObject NextXScale;

    Vector2 DotPosition;

    float StartRectY;




    void Start()
    {
        // save starting y position
        StartRectY = DotObj.GetComponent<RectTransform>().localPosition.y;

        


    }


    public void setDotHeightAccordingToData()
    {
        // print (data / MaxData);
        // DotObj.GetComponent<RectTransform>().localPosition = new Vector2(0, (data / MaxData ) * maxHeight /2);
        DotPosition = new Vector2(0, (data / MaxData ) * maxHeight );
        DotObj.GetComponent<RectTransform>().localPosition = DotPosition;
        


        // print( data + " ----- " + (data / MaxData ) * maxHeight);

        PlayAnimation();

    }

    public void setData(float x)
    {
        data = x;
        IndicatorText.SetText(x.ToString());
    }

    public void setMaxData(float x)
    {
        MaxData = x;
    }


    IEnumerator fill()
    {
        // reset the bars
        ResetLine();
        


        // set duration
        float duration = 1.0f;

        // set interpolation value
        float t = 0.05f;

    
        // start lerping
        while (t < 1.0f)
        {
            // set time
            t += Time.deltaTime / duration;

            // lerp the fill amount of pies
            DotObj.GetComponent<RectTransform>().localPosition = new Vector2(0, Mathf.Lerp(StartRectY, DotPosition.y, t));


            // keeps the line connected
            ConnectDotToNextDot();
            yield return null;
        }
    }


    // reset dots height to 0
    void ResetLine()
    {
        DotObj.GetComponent<RectTransform>().localPosition = new Vector2(StartRectY, 0f);

    }

    public void PlayAnimation()
    {
        StartCoroutine(fill());
    }


    public void HideLine()
    {
        Line.gameObject.SetActive(false);
    }

    
    public void ConnectDotToNextDot()
    {
        if (!NextXScale) return;

        Line.SetPosition(0, new Vector3(0 , 0 + DotObj.GetComponent<RectTransform>().anchoredPosition.y - 175f, 0));
        Line.SetPosition(1, new Vector3(NextXScale.GetComponent<RectTransform>().anchoredPosition.x - GetComponent<RectTransform>().anchoredPosition.x , NextDot.GetComponent<RectTransform>().anchoredPosition.y - 175f, 0));

        

    }

}
