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

    [SerializeField] GameObject DotObj;


    [SerializeField] TextMeshProUGUI IndicatorText;


    float StartRectY;

    void Start()
    {
        // save starting y position
        StartRectY = DotObj.GetComponent<RectTransform>().localPosition.y;

        


    }


    public void setDotHeightAccordingToData()
    {
        print (data / MaxData);
        DotObj.GetComponent<RectTransform>().localPosition = new Vector2(0, (data / MaxData ) * maxHeight /2);
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
            DotObj.GetComponent<RectTransform>().localPosition = new Vector2(0, Mathf.Lerp(StartRectY, (data / MaxData / 2) * maxHeight, t));


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
}
