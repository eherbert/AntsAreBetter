
using UnityEngine;

using System.Collections;



public class BackgroundColorScript : MonoBehaviour
{
    public float colorChangeFactor;
    public float maxMinRange;
    public bool rotatingColor;
    
    //private GameObject background;
    private bool stepOne;
    private bool stepTwo;
    private bool stepThree;
    private bool stepFour;
    private bool stepFive;
    private bool stepSix;
    
    // Use this for initialization
    void Start()
    {
        stepOne = true;
        stepTwo = false;
        stepThree = false;
        stepFour = false;
        stepFive = false;
        stepSix = false;
    }



    // Update is called once per frame

    void Update()
    {
        if(rotatingColor) UpdateColor();
    }

    void UpdateColor()
    {
        float a, b, c;
        if (stepOne) //if(Camera.main.backgroundColor.r>=1.0f && Camera.main.backgroundColor.g<=0.0f)
        {
            a = (0.0f);
            b = Mathf.Abs(colorChangeFactor);
            c = (0.0f);
            if (Camera.main.backgroundColor.g >= maxMinRange)
            {
                stepOne = false;
                stepTwo = true;
            }
        }
        else if (stepTwo) //if(Camera.main.backgroundColor.b>=1.0f && Camera.main.backgroundColor.g<=0.0f)
        {
            a = -Mathf.Abs(colorChangeFactor);
            b = (0.0f);
            c = (0.0f);
            if (Camera.main.backgroundColor.r <= (1-maxMinRange))
            {
                stepTwo = false;
                stepThree = true;
            }
        }
        else if (stepThree) //if(Camera.main.backgroundColor.r<=0.0f && Camera.main.backgroundColor.b>=1.0f)
        {
            a = (0.0f);
            b = Mathf.Abs(colorChangeFactor);
            c = (0.0f);
            if (Camera.main.backgroundColor.g >= maxMinRange)
            {
                stepThree = false;
                stepFour = true;
            }
        }
        else if (stepFour) //if(Camera.main.backgroundColor.r<=0.0f && Camera.main.backgroundColor.g>=1.0f)
        {
            a = (0.0f);
            b = (0.0f);
            c = -Mathf.Abs(colorChangeFactor);
            if (Camera.main.backgroundColor.b <= (1-maxMinRange))
            {
                stepFour = false;
                stepFive = true;
            }
        }
        else if (stepFive) //if(Camera.main.backgroundColor.g>=1.0f && Camera.main.backgroundColor.b<=0.0f)
        {
            a = Mathf.Abs(colorChangeFactor);
            b = (0.0f);
            c = (0.0f);
            if (Camera.main.backgroundColor.r >= maxMinRange)
            {
                stepFive = false;
                stepSix = true;
            }
        }
        else if (stepSix) //if(Camera.main.backgroundColor.r>=1.0f && Camera.main.backgroundColor.b<=0.0f)
        {
            a = (0.0f);
            b = -Mathf.Abs(colorChangeFactor);
            c = (0.0f);
            if (Camera.main.backgroundColor.g <= (1-maxMinRange))
            {
                stepSix = false;
                stepOne = true;
            }
        }
        else
        {
            a = (0.0f);
            b = -Mathf.Abs(colorChangeFactor);
            c = (0.0f);
            if (Camera.main.backgroundColor.g <= (1-maxMinRange))
            {
                stepOne = true;
            }
        }

        Camera.main.backgroundColor += new Color(a, b, c);
    }
}