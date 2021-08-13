using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;


public class PieChart2 : MonoBehaviour
{
    
    public Image OrangePie;
    public Image BluePie;

    

    public TextMeshProUGUI OrangeTextObj;
    public TextMeshProUGUI BlueTextObj;


    public GameObject ModificationPopupRef;
    
    public InputField OrangeInput;
    public InputField BlueInput;


    public bool PlayAnimation;


    public int OrangeValue;
    // {
    //     get{ return _OrangeValue; }
    //     set
    //     {
    //         _OrangeValue = value;
    //         UpdateChart(_OrangeValue, BlueValue);        
    //     }
    // }
    // int _OrangeValue;

    
    public int BlueValue;
    // {
    //     get{ return _BlueValue; }
    //     set
    //     {
    //         _BlueValue = value;
    //         UpdateChart(OrangeValue, _BlueValue);
    //     }
    // }
    // int _BlueValue;
    

    void Start()
    {
        UpdateChart(OrangeValue, BlueValue);

        if (PlayAnimation)
        {
            // invoke pie grow event evry 5 seconds 
            InvokeRepeating("PieGrowEvent", 5.0f, 5.0f);
            
        }



    }

    void Update()
    {
        
    }



    IEnumerator fill(float Oamount, float Bamount)
    {
        // reset the pies
        ResetPie(OrangePie);
        ResetPie(BluePie);

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
            OrangePie.fillAmount = Mathf.Lerp(0f, Oamount, t);
            BluePie.fillAmount = Mathf.Lerp(0f, Bamount, t);  


            yield return null;
        }
    }

    public void UpdateChart(int O, int B) 
    {
        // set text
        OrangeTextObj.GetComponent<TextMeshProUGUI>().SetText(O.ToString());
        BlueTextObj.GetComponent<TextMeshProUGUI>().SetText(B.ToString());

        // calc sum
        float sum = O + B;


        // set percentage
        // OrangePie.fillAmount = O / sum;
        // BluePie.fillAmount = 1;
        

        // play fill animation
        StartCoroutine(fill(O / sum, 1));
    }


    public void UpdateChart(float O, float B) 
    {
        // set text
        OrangeTextObj.GetComponent<TextMeshPro>().SetText(O.ToString());
        BlueTextObj.GetComponent<TextMeshPro>().SetText(B.ToString());


        // calc sum
        float sum = O + B;

        print(sum);
        print(O / B);

        // set percentage
        OrangePie.fillAmount = O / sum;
        BluePie.fillAmount = 1;

    }




    void ResetPie(Image target)
    {
        target.fillAmount = 0;
    }

    void PieGrowEvent()
    {
        float sum = OrangeValue + BlueValue;
        StartCoroutine(fill(OrangeValue / sum, 1.0f));

    }


    // modify button event
    public void ModifyButton()
    {
        ModificationPopupRef.SetActive(true);
    }


    public void CloseButton()
    {

        // clear input field
        BlueInput.text = "";
        OrangeInput.text = "";

        ModificationPopupRef.SetActive(false);
    }
    
    // confirm button event
    public void ValueChangeConfirmButtonEvent()
    {


        // return if both input are empty
        if (BlueInput.text == "" && OrangeInput.text == "") return;


        // parse string to int
        if (BlueInput.text != "")
        {
            BlueValue = int.Parse(BlueInput.text);
        }

        if (OrangeInput.text != "")
        {
            OrangeValue = int.Parse(OrangeInput.text);
        }

        // update the chart
        UpdateChart(OrangeValue, BlueValue);


        // clear input field
        BlueInput.text = "";
        OrangeInput.text = "";

        ModificationPopupRef.SetActive(false);
    }


}
