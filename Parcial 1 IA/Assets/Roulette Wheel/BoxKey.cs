using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxKey : MonoBehaviour
{
    //Variables de Roulette Wheel
    Roulette _roulette;
    Dictionary<ActionNode, int> _rouletteNodes = new Dictionary<ActionNode, int>();

    Transform target;
    public float range = 30;
    public float angle = 90;
    public LayerMask maskObstacle;
    public LayerMask maskTargets;
    public float time;
    float _counter = 0;

    private void Awake()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void Start()
    {
        CreateRoulette();
    }

    void Update()
    {
        _counter += Time.deltaTime;
        if (_counter >= time)
        {
            RouletteAction();
            _counter = 0;
        }
    }

    void Key()
    {
        Debug.Log("You got the key!");
    }

    void NotKey()
    {
        Debug.Log("No key :(");
    }

    public Transform[] CheckTargets()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, range, maskTargets);
        Transform[] targets = new Transform[colls.Length];

        for (int i = 0; i < colls.Length; i++)
        {
            targets[i] = colls[i].transform;
        }
        return targets;
    }

    public void CreateRoulette()
    {
        Debug.Log("Box Roulette Created");
        _roulette = new Roulette();

        ActionNode reward = new ActionNode(Key);
        ActionNode empty = new ActionNode(NotKey);

        _rouletteNodes.Add(reward, 98);
        _rouletteNodes.Add(empty, 2);

        ActionNode rouletteAction = new ActionNode(RouletteAction);

    }

    public void RouletteAction()
    {
        ActionNode nodeRoulette = _roulette.Run(_rouletteNodes);
        nodeRoulette.Execute();
    }
}
