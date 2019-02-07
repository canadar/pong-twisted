using UnityEngine;
using UnityEngine.UI;

public class PongManager : MonoBehaviour
{
    private int _blueScore;
    private int _redScore;
    
    private Text _blueScoreText;
    private Text _redScoreText;
    private Text _winnerText;

    private bool _winner;

    private Ball _ball;
        
    public void PlayerScored(string player)
    {
        if (player.Contains("Red"))
        {
            _redScore++;
        }
        else if (player.Contains("Blue"))
        {
            _blueScore++;
        }
        
        UpdateScoreText();
        CheckWinCondition();
        _ball.ResetBall();
    }
    
    private void Start()
    {
        _redScoreText = GameObject.FindGameObjectWithTag("RedScore").GetComponent<Text>();
        _blueScoreText = GameObject.FindGameObjectWithTag("BlueScore").GetComponent<Text>();
        _winnerText = GameObject.FindGameObjectWithTag("WinnerText").GetComponent<Text>();

        _ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>();
                        
        UpdateScoreText();
    }

    private void Update()
    {
        if (!_winner) return;
        _ball.enabled = false;
        _winnerText.text = _blueScore > _redScore ? "BLUE PLAYER WINS" : "RED PLAYER WINS";
    }

    private void CheckWinCondition()
    {
        if (_blueScore == 10 || _redScore == 10)
        {
            _winner = true;
        }
    }

    private void UpdateScoreText()
    {
        if (_redScoreText != null)
        {
            _redScoreText.text = _redScore.ToString();
        }

        if (_blueScoreText != null)
        {
            _blueScoreText.text = _blueScore.ToString();
        }
    }
}
