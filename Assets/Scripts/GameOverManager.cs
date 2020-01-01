using UnityEngine;

[RequireComponent(typeof(ScoreDisplay))]

public class GameOverManager : MonoBehaviour
{
    private ScoreDisplay scoreDisplay = null;
    private ScoreManager scoreManager = null;
    void Start()
    {
        scoreDisplay = GetComponent<ScoreDisplay>();
        scoreManager = FindObjectOfType<ScoreManager>();
        UpdateScoreDisplay();
        scoreManager.Reset();
    }

    private void UpdateScoreDisplay()
    {
        scoreDisplay.UpdateScoreDisplay(scoreManager.Score.ToString());
    }
}
