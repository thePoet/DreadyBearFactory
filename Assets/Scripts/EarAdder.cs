using UnityEngine;
using System.Collections;

public class EarAdder : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) 
	{
		Bear bear = other.gameObject.GetComponent<Bear>();
		if (bear != null)
		{
			GetComponent<AudioSource>().Play();
			bear.AddEar();
		}

	}
}
