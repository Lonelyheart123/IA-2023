using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roulette
{
    public T Run<T>(Dictionary<T, int> items){
		int total = 0;
		
		foreach(var item in items){
			total += item.Value;
		}
		int random = Random.Range(0, total);
		
		foreach(var item in items){
			random -= item.Value;
			if(random <= 0)
				return item.Key;
		}
		
		return default(T);
	}
}
