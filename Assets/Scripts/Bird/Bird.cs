using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMovementController))]
public class Bird : MonoBehaviour
{
    private BirdMovementController _playerMover;
    private BotBirdController _botMover;
    private int _score;

    public event UnityAction GameOver;
    public event UnityAction<int> ScoreChanged;

    private void Start()
    {
        _playerMover = GetComponent<BirdMovementController>();
    }
    
    public void IncreaseScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    public void ResetPlayer()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
        _playerMover.ResetBird();
    }

    public void Die()
    {
        GameOver?.Invoke();
    }
}
