using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private float lifeTime = 3.2f; 
    private ScoreManager scoreManager;
    private EffectNum effectNum;
    

    void Start () {
            scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
            effectNum = GameObject.Find("EffectNum").GetComponent<EffectNum>();
            Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider collider){
        if (collider.gameObject.tag == "Player"){
            
            if (this.gameObject.tag == "Box"){
                scoreManager.score += 1000;
                scoreManager.timer += 5f;
                scoreManager.boxes += 1;
                effectNum.makeEffectNum("+5", this.gameObject.transform.position, "Box");
            }
            else if (this.gameObject.tag == "Rock"){
                scoreManager.score -= 50;
                if (scoreManager.timer >= 6f) scoreManager.timer -= 5f;
                scoreManager.rocks += 1;
                effectNum.makeEffectNum("-5", this.gameObject.transform.position, "Rock");
            }
            else{
                scoreManager.score += 10;
                scoreManager.parts += 1;
                effectNum.makeEffectNum("+1", this.gameObject.transform.position, "Parts");
            }
            Destroy(gameObject);
        }
    }
}
