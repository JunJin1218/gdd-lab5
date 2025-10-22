using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_Text scoreText;

    public int Score { get; private set; }

    void Start()
    {
        UpdateScoreUI();
    }

    // 점수 +1
    public void AddOnePoint()
    {
        Score++;
        UpdateScoreUI();
    }

    // 점수 UI 반영
    public void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + Score;
    }

    // 재시작 버튼에서 호출하도록 연결
    public void RestartGame()
    {
        // Score Reset
        Score = 0;

        // Scene Reload
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
