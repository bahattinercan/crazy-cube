using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score;
    public Text scoreText;
    private Animator animator;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        score = 0;
    }

    private void Start()
    {
        animator = scoreText.GetComponent<Animator>();
    }

    public void AddScore(int point)
    {
        score += point;
        scoreText.text = score.ToString();
        animator.Play("scoreText_collect");
    }
}