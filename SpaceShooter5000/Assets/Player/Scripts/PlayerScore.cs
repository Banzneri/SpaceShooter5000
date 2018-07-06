using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{

    public float f_StartMultiplier;
    // Current Score
    [HideInInspector] public float f_Score = 0f;

    // Current Multiplier
    [HideInInspector] public float f_Multiplier;

    // Timer for multiplier
    private float f_ScoreTimer;

    private UIHandler _ui;

    // Use this for initialization
    void Start()
    {
        f_Multiplier = f_StartMultiplier;
        _ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UIHandler>();
        _ui.UpdateScore(f_Score, f_Multiplier);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(float score)
    {
        f_Score += score * f_Multiplier;
        _ui.UpdateScore(f_Score, f_Multiplier);
    }
}
