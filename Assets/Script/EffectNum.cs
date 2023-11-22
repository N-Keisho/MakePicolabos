using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EffectNum : MonoBehaviour
{

    public TMP_Text effectNumber;
    public GameObject canvas;
    public GameObject camera;

    public void makeEffectNum(string text, Vector3 position, string color){
        Vector3 targetScreenPos = camera.GetComponent<Camera>().WorldToScreenPoint(position);
        targetScreenPos.y = 300;
        TMP_Text Etext = Instantiate(effectNumber, targetScreenPos, Quaternion.Euler(0, 0, 0));
        // Etext.transform.parent = Canvas.transform;
        Etext.transform.SetParent(canvas.transform);
        Etext.text = text;
        if (color == "yellow") Etext.color = Color.red;
        else if(color == "blue") Etext.color = Color.blue;
        Destroy(Etext, 0.5f);
    }
}
