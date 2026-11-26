using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class coincounterui : MonoBehaviour
{
    [SerializeField]
    public TMP_Text scoreText;

    [SerializeField]
    public static int score;

    void Start()
    {
        scoreText = GetComponent<TMP_Text>();

        
    }
    void Update()
    {
        scoreText.text = "Coins: " + score.ToString();

    }

    public static void AddScore(int coinPoint)
    {
        score += coinPoint;
    }
}
