using UnityEngine;

public class PongManager : MonoBehaviour
{
    private int _blueScore = 0;
    private int _redScore = 0;

    private bool _winner;

    private GameObject _ball;
    private Transform _ballSpawnLocation;
    
    //Maybe use these for UI?
    public int RedScore
    {
        get { return _redScore; }
    }
    
    public int BlueScore
    {
        get { return _blueScore; }
    }

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
        
        CheckWinCondition();
        ResetBall();
    }
    
    private void Start()
    {
        _ball = GameObject.FindGameObjectWithTag("Ball");
        _ballSpawnLocation = _ball.transform;
    }

    private void Update()
    {
        if (_winner)
        {
            
        }
    }

    private void CheckWinCondition()
    {
        if (_blueScore == 10 || _redScore == 10)
        {
            _winner = true;
        }
    }

    private void ResetBall()
    {
        Destroy(_ball);
        Instantiate(_ball, _ballSpawnLocation, true);
    }
}
