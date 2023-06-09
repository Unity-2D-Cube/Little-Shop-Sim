using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsManagerScript : MonoBehaviour
{
    public static TextMeshProUGUI text;

    public static int appleAmmout;


    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();

        appleAmmout = PlayerPrefs.GetInt("Text_Score_Apples", appleAmmout);

        text.text = appleAmmout.ToString();
    }

    private void LateUpdate()
    {
        text.text = appleAmmout.ToString();

        text.text = "" + appleAmmout;

        PlayerPrefs.SetInt("Text_Score_Apples", appleAmmout );

    }






} // Class
