using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    //
    [SerializeField] int PointsPerBlocksDestroyed = 83;
    [SerializeField] int currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }    
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }
    public void AddToScore()
    {
        currentScore += PointsPerBlocksDestroyed;
        scoreText.text = currentScore.ToString();
    }    
    public void ResetGame()
    {
        Destroy(gameObject);
    }    
}
