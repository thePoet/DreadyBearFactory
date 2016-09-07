using UnityEngine;
using System.Collections;

public class MouthAdder : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) 
	{
		Bear bear = other.gameObject.GetComponent<Bear>();
		if (bear != null)
		{
			bear.AddMouth();
		}

	}
}
