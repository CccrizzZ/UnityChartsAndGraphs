using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LineGraph : MonoBehaviour
{



    // array for all the dots
    public List<GameObject> AllDots;


    // array for all dots data
    public List<float> AllDotsData;

    // array for all dots tags
    public List<string> AllDotsTag;


    // biggest data
    public float MaxData;
    

    // how many scale line
    public int ScaleLineCount;


    public string XNoteInput;
    public string YNoteInput;



    // axis note text object
    [SerializeField] TextMeshProUGUI XNote;
    [SerializeField] TextMeshProUGUI YNote;


    // scale & bar container
    [SerializeField] GameObject ScaleContainer;

    // for x scale 
    [SerializeField] GameObject DotsContainer;



    [SerializeField] bool ShowXAxisNote;
    [SerializeField] bool ShowYAxisNote;
    [SerializeField] bool ShowScale;
    [SerializeField] bool PlayAnimation;


    // bar and scale prefab
    [SerializeField] GameObject XAxisDotPrefab;
    [SerializeField] GameObject ScalePrefab;



    void Start()
    {
        
        // set game object to active according to flag
        if (!ShowXAxisNote) XNote.gameObject.SetActive(false);

        if (!ShowYAxisNote) YNote.gameObject.SetActive(false);

        if (!ShowScale) ScaleContainer.gameObject.SetActive(false);

        CreateDotsFromDataArray();



        // set the scale notes / unit
        XNote.SetText(XNoteInput);
        YNote.SetText(YNoteInput);




        if (!PlayAnimation)return;
        // play animation every 5 seconds starting after 5 seconds
        InvokeRepeating("LineGrowingAnimation", 5.0f, 5.0f);


    }

    void Update()
    {
        
    }


    void CreateDotsFromDataArray()
    {
        // traverse all dots data
        foreach (var item in AllDotsData)
        {
            var newDot = Instantiate(XAxisDotPrefab);
            var newDotScript = newDot.GetComponent<Dots>();

            // set data to dots
            newDotScript.setData(item);

            // refresh max data
            SetMaxData();

            
            // add to dots array & container
            AddToDotsArrayAndContainer(newDot);

        }


        
        UpdateAllDotsHeight();
        UpdateScaleContainer();

    }

    void UpdateAllDotsHeight()
    {
        foreach (var item in AllDots)
        {
            var DotsController = item.GetComponent<Dots>();
            DotsController.setMaxData(MaxData);
            DotsController.setDotHeightAccordingToData();  
        }
            
    }


    // add dot object to array and container
    void AddToDotsArrayAndContainer(GameObject dot)
    {
        AllDots.Add(dot);
        dot.transform.SetParent(DotsContainer.transform, false);
    }


    // append new scale line to scale container
    void AddScaleToScaleContainer(GameObject NewScale)
    {
        NewScale.transform.SetParent(ScaleContainer.transform, false);
    }


    public void UpdateScaleContainer()
    {

        // return if no max data
        if (MaxData == 0) return;
        
        // clear scale container game object
        if (ScaleContainer.transform.childCount !=0)
        {
            foreach (Transform child in ScaleContainer.transform) 
            {
                GameObject.Destroy(child.gameObject);
            }
        }


        // calculate section size according to max data value and number of scale lines
        var section = MaxData / ScaleLineCount;

        // create scale object
        for (int i = ScaleLineCount; i >= 1; i--)
        {

            // create new scale line
            var newScaleLine = Instantiate(ScalePrefab);
            var newScaleScript = newScaleLine.GetComponent<ScaleScript>();


            // data will be section * scaleline count
            newScaleScript.SetScaleData(section * i);


            // append scale lines to the scale container
            AddScaleToScaleContainer(newScaleLine);

        }
    }



    // find the biggest data
    void SetMaxData()
    {
        // return if list empty
        if (AllDotsData.Count == 0)return;


        // iterate all bars and find the max data
        float max = AllDotsData[0];
        foreach (var item in AllDotsData)
        {
            if (item > max)
            {
                max = item;
            }
        }
        MaxData = max; //+ max / (ScaleLineCount - 1);
    }



    void LineGrowingAnimation()
    {
        foreach (var item in AllDots)
        {
            item.GetComponent<Dots>().PlayAnimation();
        }
    }

}
