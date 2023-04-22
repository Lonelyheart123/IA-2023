using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNode : ITreeNode
{
    Roulette _roulette;
	Dictionary<ITreeNode, int> _items;
	
	public RandomNode(Roulette roulette, Dictionary<ITreeNode, int> items)
	{
		_roulette = roulette;
		_items = items;
	}
	
	public void Execute ()
	{
		_roulette.Run(_items).Execute();
	}
}