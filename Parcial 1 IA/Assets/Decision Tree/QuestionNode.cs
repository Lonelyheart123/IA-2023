using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionNode : INode
{
    public delegate bool myDelegate();
	
	myDelegate _question;
	INode _tN;
	INode _fN;
	
	public QuestionNode(myDelegate question, INode tN, INode fN){
		_question = question;
		_fN = fN;
		_tN = tN;
	}
	
	public void Execute(){
		if(_question == null) return;
		
		if(_question())
			_tN.Execute();
		else
			_fN.Execute();
	}
}
