using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextUp : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 tmp = transform.position;
        tmp.y += 2;
        transform.position = tmp;    
    }
}
