using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectManager : MonoBehaviour
{
    public GameObject[] Objects;// 生成するオブジェクト
    public float interval  = 0.2f;
    public float sizeNum = 1;
    public float startTime = 3;
    void Start()
    {
        InvokeRepeating("Generate", startTime, interval);
    }
    void Generate()
    {
        int num = Random.Range(0, Objects.Length-1);
        float x = Random.Range(-9f, 9f);// xを-30〜30の乱数にする
        float y = 20f;
        float z = 0; 
        float rx = Random.Range(-90f, 90f);
        float ry = Random.Range(-90f, 90f);
        float rz = Random.Range(-90f, 90f);
        float size = Random.Range(8f, 12f) * sizeNum;
        Vector3 position = new Vector3(x, y, z);// positionの座標をxyzにする
        GameObject obj = Instantiate(Objects[num], position, Quaternion.Euler(rx, ry, rz));// オブジェクトをxyzに生成する
        
        // 生成したオブジェクトの設定
        obj.transform.localScale = new Vector3(size, size, size); //大きさ
        obj.AddComponent<Rigidbody>();
        var col = obj.AddComponent<CapsuleCollider>();
        col.radius /= 1.8f;
        col.height = col.radius;
        col.isTrigger = true;
        if (obj.tag == "Box"){
            var par = obj.transform.GetChild(0);
            Component[] components = par.GetComponentsInChildren<Component>();
            foreach (Component component in components)
            {
                Vector3 tmp = component.transform.localScale;
                component.transform.localScale = tmp * (size / sizeNum) / 9;
            }
        }
        obj.AddComponent<DestroyObject>();
    }
}
