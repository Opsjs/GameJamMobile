using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    int score = 0;
    [SerializeField] PlayerController playerController;

    private void Start()
    {
        score = 0;
        UpdateScore((float)score);
    }

    public void UpdateScore(float height)
    {
        score  = (int) (height * 100);
        scoreText.text = "Score : " + score;
    }
}
