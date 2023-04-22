using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionNode : ITreeNode
{
    public delegate bool myDelegate();
	
	myDelegate _question;
	ITreeNode _tN;
	ITreeNode _fN;
	
	public QuestionNode(myDelegate question, ITreeNode tN, ITreeNode fN){
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
