using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    Text Scoretext;
    private void Awake()
    {
        Scoretext = GetComponent<Text>();
        score = 0;

    }
    void Update()
    {
        Scoretext.text = "Score: " + score;
    }
}
