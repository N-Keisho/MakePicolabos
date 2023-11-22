using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextUp : MonoBehaviour
{

    void Update()
    {
        Vector3 targetScreenPos = transform.position;
        targetScreenPos.y += 200 * Time.deltaTime;
        transform.position = targetScreenPos;    
    }
}
