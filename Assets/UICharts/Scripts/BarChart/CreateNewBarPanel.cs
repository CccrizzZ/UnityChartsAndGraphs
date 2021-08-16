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

    

    void Start()
    {
        
    }

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
        



        ClearData();
        gameObject.SetActive(false);

    }

    void ClearData()
    {

    }


    public void UpdateBarPreview()
    {
        BarPreview.GetComponent<Image>().color = new Color(R.value, G.value, B.value);
        
    }

}
