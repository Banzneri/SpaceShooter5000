using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{

    // Life Icons
    [SerializeField]
    private Image[] i_Lives;

    // Score Text
    [SerializeField]
    private Text t_Score;

    // Update is called once per frame
    void Update()
    {
        
    }

    // Update Score with given value
    public void UpdateScore(float score, float multiplier)
    {
        t_Score.text = "Score: " + score + "   x" + multiplier;
    }

    // Update lives with given value
    public void UpdateLives(int lives)
    {
        for (int i = 0; i < i_Lives.Length; i++)
        {
            i_Lives[i].enabled = i < lives;
        }
    }

}
