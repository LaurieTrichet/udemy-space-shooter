using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text scoreText;

    public void UpdateScoreDisplay(string score)
    {
        scoreText.SetText(score);
    }
}
