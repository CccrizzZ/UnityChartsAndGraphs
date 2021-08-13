using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class BarChart10 : MonoBehaviour
{

    // maximum 10 bars per chart
    public const int MaxBar = 10;


    // biggest data
    public float MaxData;
    

    // how many scale line
    public int ScaleLineCount;


    // array for all the bars and scales
    public List<GameObject> AllBars;
    public List<GameObject> AllScales;
    

    // array for bar data
    public List<float> AllBarDatas;
    

    // bar and scale prefab
    [SerializeField] GameObject BarPrefab;
    [SerializeField] GameObject ScalePrefab;



    // axis note text object
    [SerializeField] TextMeshProUGUI XNote;
    [SerializeField] TextMeshProUGUI YNote;


    // scale & bar container
    [SerializeField] GameObject ScaleContainer;
    [SerializeField] GameObject BarContainer;


    // flags
    [SerializeField] bool ShowXAxisNote;
    [SerializeField] bool ShowYAxisNote;
    [SerializeField] bool ShowScale;


    void Start()
    {
        
        // set game object to active according to flag
        if (!ShowXAxisNote) XNote.gameObject.SetActive(false);

        if (!ShowYAxisNote) YNote.gameObject.SetActive(false);

        if (!ShowScale) ScaleContainer.gameObject.SetActive(false);


        // init lists
        // AllBars = new List<GameObject>();
        // AllScales = new List<GameObject>();
        // AllBarDatas = new List<float>();

        // InitBarContainer();



        AddRandomColorBar(AllBarDatas[0]);
        AddRandomColorBar(AllBarDatas[1]);
        AddRandomColorBar(AllBarDatas[2]);



        InitScaleContainer();


    }

    void Update()
    {
        
    }


    void InitBarContainer()
    {
        // return if no 0 data
        if (AllBarDatas.Count == 0) return;

        // create bars according to datas

    }


    void InitScaleContainer()
    {

        // calculate section size according to max data value and number of scale lines
        var section = MaxData / ScaleLineCount - 1;

        var x = ScaleLineCount;
        // for (int i = 1; i <= ScaleLineCount; i++)
        for (int i = ScaleLineCount; i >= 1; i--)
        {

            // create new scale line
            var newScaleLine = Instantiate(ScalePrefab);
            var newScaleScript = newScaleLine.GetComponent<ScaleScript>();


            // data will be section * scaleline count
            newScaleScript.Data = section * x;


            // append scale lines to the scale container
            AddScaleToScaleContaine(newScaleLine);

            // ScaleLineCount--;
        }
    }


    // create a random bar with random color and data and add it to the container
    void AddRandomColorBar(float data)
    {
        // instantiate new bar
        var newBar = Instantiate(BarPrefab);
        var newBarScript = newBar.GetComponent<BarScript>();

        // random color
        newBarScript.BarColor = new Color(Random.Range(0.4f, 1f), Random.Range(0.4f, 1f), Random.Range(0.4f, 1f));
      
        // random data
        // var newData = Random.Range(1,10000);
        var newData = data;

        // set data to bar
        newBarScript.setData(newData);
        
        // push data to the data list
        AllBarDatas.Add(newData);

        // add to bar list
        AllBars.Add(newBar); 

        // set max data
        SetMaxData();

        // resize all bars in the bar list
        ResizeAllBars();

        // add to container
        AddBarToBarContainer(newBar);


    }





    // append new bar to bar container
    void AddBarToBarContainer(GameObject NewBar)
    {
        NewBar.transform.SetParent(BarContainer.transform, false);
    }
    
    // append new scale line to scale container
    void AddScaleToScaleContaine(GameObject NewScale)
    {
        NewScale.transform.SetParent(ScaleContainer.transform, false);
    }


    void ResizeAllBars()
    {
        foreach (var item in AllBars)
        {
            var bs = item.GetComponent<BarScript>();
            bs.MaxData = MaxData;
            bs.ReSize();
        }
    }


    // set max data and resize all bars
    void SetMaxData()
    {
        // return if list empty
        if (AllBarDatas.Count == 0)return;


        // iterate all bars and find the max data
        float max = AllBarDatas[0];
        foreach (var item in AllBarDatas)
        {
            if (item > max)
            {
                max = item;
            }
        }
        MaxData = max;

    }





    void SetXNote(string note)
    {
        XNote.SetText(note);
    }
    void SetYNote(string note)
    {
        YNote.SetText(note);
    }



}
