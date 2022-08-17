using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotBirdController : BirdMovementController
{
    [SerializeField] private float _fitness;
    [SerializeField] private float _spawnTime;

    private NeuralNetwork _network;
    private NNManager _manager;

    public float Fitness => _fitness;
    public NeuralNetwork Network => _network;
    public bool IsAlive { get; private set; }

    protected override void Update()
    {
        if (IsAlive)
        {
            _fitness = Time.time - _spawnTime;
            InitNetwork();
        }

        
    }

    public void SetNetwork(NeuralNetwork network)
    {
        _network = network;
    }

    private void InitNetwork()
    {
        float[] inputs = new float[4];
        //input[0] =....

        var output = _network.FeedForward(inputs);

        if (output[0] > 0)
            Jump();

    }
}
