using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EasyTransition;

public class ResultManager : MonoBehaviour
{
    private ScoreManager scoreManager;

    public TMP_Text scoreText;
    public TMP_Text boxesText;
    public TMP_Text partsText;
    public TMP_Text rocksText;
    public TMP_Text picolaboText;
    public TMP_Text titleText;

    private int tmp = 0;

    private string fase = "score";

    public GameObject Picolabo;

    private bool finish = false;
    public TransitionSettings transition;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        if (scoreManager.score > 250){
            tmp = scoreManager.score / 250;
            tmp = tmp * 250;
            scoreText.text = tmp.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fase == "score"){
            if (scoreManager.score != tmp){
                if (scoreManager.score < 0) tmp--;
                else if (scoreManager.score > 0) tmp++;
                scoreText.text = tmp.ToString();
            }
            else{
                fase = "boxes";
                tmp = 0;
                // Debug.Log(scoreManager.score);
            }
        }
        else if (fase == "boxes"){
            if (scoreManager.boxes > tmp){
                tmp++;
                boxesText.text = tmp.ToString();
            }
            else{
                fase = "parts";
                tmp = 0;
                // Debug.Log(scoreManager.boxes);
            }
        }
        else if (fase == "parts"){
            if (scoreManager.parts > tmp){
                tmp++;
                partsText.text = tmp.ToString();
            }
            else{
                fase = "rocks";
                tmp = 0;
                // Debug.Log(scoreManager.parts);
            }
        }
        else if (fase == "rocks"){
            if (scoreManager.rocks > tmp){
                tmp++;
                rocksText.text = tmp.ToString();
            }
            else{
                fase = "picolabo";
                tmp = 0;
                // Debug.Log(scoreManager.rocks);
            }
        }
        else if(fase == "picolabo"){
            int picolabos = scoreManager.boxes + scoreManager.parts / 10;
            StartCoroutine(Result(picolabos));
            fase = "finish";
            GameObject obj = GameObject.Find("ScoreManager");
            Destroy(obj);
        }
        else if(finish){
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                TransitionManager.Instance().Transition("Scenes/Title", transition, 0);
        }
    }

    IEnumerator Result(int picolabos){
        Vector3 position = new Vector3(-0.5f, 0, 0);
        Debug.Log(picolabos);
        for (int i = 1 ; i <= picolabos ; i++){
            Instantiate(Picolabo, position, Quaternion.Euler(0, 200, 0));
            if (i % 5 == 0){
                position.x = 0.5f;
                position.z += 1f;
            }
            else {
                position.x += 1f;
            }
            yield return new WaitForSeconds(0.5f);
        }
        picolaboText.text = "You Made " + picolabos.ToString() + " Picolabos!";
        titleText.text = "PRESS SPACE TO RTURN TITLE";
        finish = true;
    }
}
