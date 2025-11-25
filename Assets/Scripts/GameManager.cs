using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TMP_Text healthText;
    public TMP_Text scoreText;

    int score = 0;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        // Optional:
        // DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        UpdateScoreText();
    }

    public void UpdateHealth(int current, int max)
    {
        if (healthText != null)
            healthText.text = $"Health: {current}/{max}";
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = $"Score: {score}";
    }
}
