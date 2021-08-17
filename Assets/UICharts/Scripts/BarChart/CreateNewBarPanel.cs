using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CreateNewBarPanel : MonoBehaviour
{


    [SerializeField] InputField DataInput;
    [SerializeField] InputField TagInput;

    [SerializeField] Slider R;
    [SerializeField] Slider G;
    [SerializeField] Slider B;
    
    [SerializeField] GameObject BarPreview;


    [SerializeField] BarChart10 BarChartController;


    void Update()
    {
        
    }

    public void CloseButtonEvent()
    {
        ClearData();
        gameObject.SetActive(false);
    }


    public void ConfirmButtonEvent()
    {

        if (DataInput.text == "") return;

        // create bar
        BarChartController.AddNewColoredBar(float.Parse(DataInput.text), new Color(R.value, G.value, B.value), TagInput.text);

        // update scale in case max value changed
        BarChartController.UpdateScaleContainer();

        // clear data and close the popup
        ClearData();
        gameObject.SetActive(false);

    }

    void ClearData()
    {
        DataInput.text = "";
        TagInput.text = "";
        R.value = 0;
        G.value = 0;
        B.value = 0;
        
    }


    public void UpdateBarPreview()
    {
        BarPreview.GetComponent<Image>().color = new Color(R.value, G.value, B.value);
        
    }

}
