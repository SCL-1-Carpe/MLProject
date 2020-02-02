using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{
    [SerializeField]
    Text InputText,CalcResultText;
    string Inputstring;
    string[] PreviousText, InfoText;
    CalcType ProcessingCalcType = CalcType.None;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddText(string s)
    {
        Inputstring += s;

    }
    public void SetCalcMode(CalcType type)
    {
        switch (type)
        {
            case CalcType.None:
                break;
            case CalcType.Addtion:
                PreviousText = new string[] { Inputstring };
                break;
            case CalcType.Subtraction:
                PreviousText = new string[] { Inputstring };
                break;
            case CalcType.Multiplication:
                PreviousText = new string[] { Inputstring };
                break;
            case CalcType.Division:
                PreviousText = new string[] { Inputstring };
                break;
            case CalcType.Sin_r:
                SetResult(Mathf.Sin(float.Parse(Inputstring)).ToString());
                break;
            case CalcType.Cos_r:
                SetResult(Mathf.Cos(float.Parse(Inputstring)).ToString());
                break;
            case CalcType.Tan_r:
                SetResult(Mathf.Tan(float.Parse(Inputstring)).ToString());
                break;
            case CalcType.Sin_d:
                break;
            case CalcType.Cos_d:
                break;
            case CalcType.Tan_d:
                break;
            case CalcType.Asin:
                SetResult(Mathf.Asin(float.Parse(Inputstring)).ToString());
                break;
            case CalcType.Acos:
                break;
            case CalcType.Atan:
                break;
            case CalcType.Log:
                break;
            default:
                break;
        }
    }
    public void Calculation()
    {
        switch (ProcessingCalcType)
        {
            case CalcType.None:
                break;
            case CalcType.Addtion:
                break;
            case CalcType.Subtraction:
                break;
            case CalcType.Multiplication:
                break;
            case CalcType.Division:
                break;
            case CalcType.Sin_r:
                break;
            case CalcType.Cos_r:
                break;
            case CalcType.Tan_r:
                break;
            case CalcType.Sin_d:
                break;
            case CalcType.Cos_d:
                break;
            case CalcType.Tan_d:
                break;
            case CalcType.Asin:
                break;
            case CalcType.Acos:
                break;
            case CalcType.Atan:
                break;
            case CalcType.Log:
                break;
            default:
                break;
        }
    }

    void SetResult(string result)
    {
        CalcResultText.text = result;
        InputText.text = "";
    }

    public enum CalcType
    {
        None, Addtion, Subtraction, Multiplication, Division, Sin_r, Cos_r, Tan_r, Sin_d, Cos_d, Tan_d, Asin, Acos, Atan, Log
    }
}
