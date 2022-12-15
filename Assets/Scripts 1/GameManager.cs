using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public AudioSource audioSource;
    public Paddle playerPaddle;
    public int playerScore { get; private set; }
    public Text playerScoreText;

    public Paddle computerPaddle;
    public int computerScore { get; private set; }
    public Text computerScoreText;

    public string pongWin;
    public string pongLose;


    private void Start()
    {
        NewGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            NewGame();
        }

        if(playerScore >= 5 && pongWin != string.Empty)
        {
            SceneManager.LoadScene(pongWin);
        }

        if(computerScore >= 5 && pongLose != string.Empty)
        {
            SceneManager.LoadScene(pongLose);
        }
    }

    public void NewGame()
    {
        SetPlayerScore(0);
        SetComputerScore(0);
        StartRound();
    }

    public void StartRound()
    {
        playerPaddle.ResetPosition();
        computerPaddle.ResetPosition();
        ball.ResetPosition();
        ball.AddStartingForce();
    }

    public void PlayerScores()
    {
        audioSource.Play();
        SetPlayerScore(playerScore + 1);
        StartRound();
        
    }

    public void ComputerScores()
    {
        audioSource.Play();
        SetComputerScore(computerScore + 1);
        StartRound();
    }

    private void SetPlayerScore(int score)
    {
        playerScore = score;
        playerScoreText.text = score.ToString();
    }

    private void SetComputerScore(int score)
    {
        computerScore = score;
        computerScoreText.text = score.ToString();
    }

}
