using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EasyTransition;
public class ScoreManager : MonoBehaviour
{
    public float timer = 30f;
    private float counter = 3f;
    
    
    private float spanTime = 0;
    public TMP_Text scoreText;
    public TMP_Text counterText;
    public TMP_Text timerText;
    public TMP_Text boxesText;
    public TMP_Text partsText;
    public TMP_Text rocksText;

    public int score = 0;
    public int boxes = 0;
    public int parts = 0;
    public int rocks = 0;

    private bool finish = false;
    public TransitionSettings transition;

    public GameObject[] Managers;
    // Start is called before the first frame update
    void Start()
    {
        timerText.text = timer.ToString();
        counterText.text = counter.ToString();
        DontDestroyOnLoad(gameObject);
        timer += counter;
    }

    // Update is called once per frame
    void Update()
    {
        if (!finish)
        {
            scoreText.text = score.ToString();
            boxesText.text = boxes.ToString();
            partsText.text = parts.ToString();
            rocksText.text = rocks.ToString();

            spanTime += Time.deltaTime; //spanTimeに1フレームごとの経過時間を足します。(約0.016を足します)

            if (spanTime > 1)   //spanTimeが1より大きかったら(約1秒を超えたら)
            {
                spanTime = 0;   //spanTimeをゼロに初期化します
                timer -= 1;     //制限時間を1減らします(-1します)
                counter -= 1;
                if (counter > 0) counterText.text = counter.ToString();
                else if (counter == 0) counterText.text = "Start";
                else
                {
                    counterText.text = "";

                    if (timer > 0)
                    {
                        timerText.text = timer.ToString(); //timerTextの文字を「制限時間：timerの値」にします
                    }
                    else
                    {
                        for (int i = 0; i < Managers.Length; i++) Destroy(Managers[i]);
                        timerText.text = "0"; //timerTextの文字を「ゲーム終了」にします
                        counterText.text = "Finish";
                        finish = true;
                        TransitionManager.Instance().Transition("Scenes/Result", transition, 2);

                    }
                }
            }
        }
    }
}
