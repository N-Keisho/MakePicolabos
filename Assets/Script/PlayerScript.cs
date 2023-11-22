using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1f;// 移動スピードを入れるための変数

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            transform.Rotate(0, 180, 0);
        }
    }
           
    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == "right" || collision.gameObject.tag == "left") transform.Rotate(0, 180, 0);
    }

    private void OnCollisionExit(Collision collision){
        
    }
}
