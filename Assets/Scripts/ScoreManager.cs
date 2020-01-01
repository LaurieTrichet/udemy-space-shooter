using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    private int score = 0;

    public int Score { get => score; set => score = value; }

    private void Awake()
    {
        SetSingleton();
    }

    void SetSingleton()
    {
        if ( FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Reset()
    {
        Destroy(gameObject);
    }
}
