using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NNManager : MonoBehaviour
{
    [SerializeField] private PipeGenerator _pipeGenerator;
    [SerializeField] private BotBirdController _botBird;

    [Space]
    [Header("Evolvement variables")]
    [SerializeField] private int _populationSize;
    [SerializeField] private float _mutationChance;
    public Pipe NearestPipe { get; private set; }

    //UI

    public void BotDie()
    {

    }

    private float _maxFitness;
    private int _generationCount;
    private int _deadCount;

    private List<BotBirdController> _birds;
    private List<BotBirdController> _lastPopulation;
    private int[] _layers;

    private void Start()
    {
        SetLayers(4, 8, 8, 1);
    }

    private void Update()
    {
        //mix UI
    }

    private void FixedUpdate()
    {
        _birds.Sort(SortByFitness);

        if (_birds.Count > 0)
            _maxFitness = Math.Max(_birds[0].Fitness, _maxFitness);
    }

    public void SetLayers(params int[] layers)
    {
        _layers = layers;
    }

    private void StartGeneration()
    {
        _generationCount++;
        _deadCount = 0;
        _lastPopulation = _birds;
        _birds = new List<BotBirdController>();
        InstantiatePopulation();

    }

    private void EndGeneration()
    {
        //UI params reload
        //Save best score in this generation to json / other markup format file
        //Destroy birds in current generation here, override object pool logic + refactor object pool
        //StartGeneration()
    }

    private void InstantiatePopulation()
    {
        //for
        //SetNetwork | MutateLastPopulation
    }

    private void MutateLastPopulation(int i)
    {
        int top = 3;

        if (i < top)
        {
            NeuralNetwork copyNetwork = _lastPopulation[i].Network;
            _birds[i].SetNetwork(copyNetwork);
        }
        else if (i < _populationSize * 0.25f)
        {
            NeuralNetwork copyNetwork = _lastPopulation[i].Network;
            copyNetwork.Mutate((int)_mutationChance, 3);
            _birds[i].SetNetwork(copyNetwork);
        }
        else if (i < _populationSize * 0.5f)
        {
            NeuralNetwork copyNetwork = _lastPopulation[i].Network;
            copyNetwork.Mutate((int)_mutationChance, 3);
            _birds[i].SetNetwork(copyNetwork);
        }
        else if (i < _populationSize * 0.75f)
        {
            NeuralNetwork copyNetwork = _lastPopulation[i].Network;
            copyNetwork.Mutate((int)(_mutationChance * 0.5f), 3);
            _birds[i].SetNetwork(copyNetwork);
        }
        else if (i < _populationSize * 1.00f)
        {
            NeuralNetwork copyNetwork = _lastPopulation[i].Network;
            copyNetwork.Mutate((int)_mutationChance * 2, 3);
            _birds[i].SetNetwork(copyNetwork);
        }
    }

    private int SortByFitness(BotBirdController botBird1, BotBirdController botBird2)
    {
        return -(botBird1.Fitness.CompareTo(botBird2.Fitness));
    }
}
