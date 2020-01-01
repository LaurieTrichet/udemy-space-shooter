using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Loader))]

[RequireComponent(typeof(ScoreDisplay))]

public class GameManager : MonoBehaviour
{
    [SerializeField] float gameOverDelayInSec = 2.0f;
    
    private Loader loader = null;
    private ScoreDisplay scoreDisplay = null;
    private ScoreManager scoreManager = null;
    
    private void Start()
    {
        loader = GetComponent<Loader>();
        scoreDisplay = GetComponent<ScoreDisplay>();
        scoreManager = FindObjectOfType<ScoreManager>();
        UpdateScoreDisplay();
    }

    public void AddToScore(int points)
    {

        scoreManager.Score += points;
        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay()
    {
        scoreDisplay.UpdateScoreDisplay(scoreManager.Score.ToString());
    }

    public void PlayerHasDied()
    {
        StartCoroutine(GoToGameOver());
    }

    IEnumerator GoToGameOver()
    {
        yield return new WaitForSeconds(gameOverDelayInSec);
        loader.LoadGameOver();
    }

}
