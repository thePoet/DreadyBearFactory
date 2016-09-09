using UnityEngine;
using System.Collections;

public class EyeAdder : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		Bear bear = other.gameObject.GetComponent<Bear>();
		if (bear != null)
		{
			GetComponent<AudioSource>().Play();
			bear.AddEye();
		}

	}
}
