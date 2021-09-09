using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIChartButtonScript : MonoBehaviour
{




    public void CloseButtonEventDestroy()
    {
        Destroy(gameObject);
    }

    public void CloseButtonEventDisable()
    {
        gameObject.SetActive(false);
    }



}
