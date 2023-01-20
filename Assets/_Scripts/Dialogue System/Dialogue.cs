using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {
	[TextArea(3, 10)]
	public string[] sentences;
	int index = 0;

	public string Next()
    {
		return sentences[++index];
    }

	public string Previous()
    {
		return sentences[--index];
	}

	public string Current()
    {
		return sentences[index];
    }

	public bool isEnd()
    {
		return index == sentences.Length - 1;
    }
}
