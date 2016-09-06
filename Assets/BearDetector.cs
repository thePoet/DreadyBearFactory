using UnityEngine;
using System.Collections;

public class BearDetector : MonoBehaviour 
{
	int bearCount = 0;

	public bool IsDetected()
	{
		if (bearCount==0)
			return false;
		return true;
	}

	void OnTriggerEnter2D(Collider2D coll) 
	{
		Bear bear =  coll.gameObject.GetComponent<Bear>();
		if (bear != null)
		{
			bearCount++;
		}

	}

	void OnTriggerExit2D(Collider2D coll) 
	{
		Bear bear =  coll.gameObject.GetComponent<Bear>();
		if (bear != null)
		{
			bearCount--;
		}

	}

}
