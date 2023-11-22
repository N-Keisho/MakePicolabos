using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyTransition;
public class Title : MonoBehaviour
{
    public TransitionSettings transition;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            TransitionManager.Instance().Transition("Scenes/Main", transition, 0);
    }
}
