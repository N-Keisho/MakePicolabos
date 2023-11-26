using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EffectNum : MonoBehaviour
{

    public TMP_Text effectNumber;
    public GameObject canvas;
    public GameObject camera;

    private Color boxColor;
    private Color rockColor;

    void Start()
    {
        string htmlString = "#C68E23";// 赤色のカラーコード
        ColorUtility.TryParseHtmlString(htmlString, out boxColor);
        htmlString = "#8C8991";
        ColorUtility.TryParseHtmlString(htmlString, out rockColor);
    }

    public void makeEffectNum(string text, Vector3 position, string color)
    {
        Vector3 targetScreenPos = camera.GetComponent<Camera>().WorldToScreenPoint(position);
        targetScreenPos.y = 100;
        TMP_Text Etext = Instantiate(effectNumber, targetScreenPos, Quaternion.Euler(0, 0, 0));
        // Etext.transform.parent = Canvas.transform;
        Etext.transform.SetParent(canvas.transform, false);
        Etext.text = text;
        Etext.transform.position = targetScreenPos;
        if (color == "Box") Etext.color = boxColor;
        else if (color == "Rock") Etext.color = rockColor;
        Destroy(Etext, 0.5f);
    }
}
