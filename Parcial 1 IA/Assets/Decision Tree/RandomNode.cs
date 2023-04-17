using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNode : INode
{
    Roulette _roulette;
	Dictionary<INode, int> _items;
	
	public RandomNode(Roulette roulette, Dictionary<INode, int> items)
	{
		_roulette = roulette;
		_items = items;
	}
	
	public void Execute ()
	{
		_roulette.Run(_items).Execute();
	}
}