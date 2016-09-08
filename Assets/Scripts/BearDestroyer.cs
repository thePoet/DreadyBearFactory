using UnityEngine;
using System.Collections;

public class BearDestroyer : MonoBehaviour {

	public bool destroyMutants;
	public bool destroyUnfinished;

	void OnTriggerEnter2D(Collider2D other) 
	{
		Bear bear = other.gameObject.GetComponent<Bear>();

		if (bear != null)
		{
			if (destroyMutants &&  (bear.earCount > 2 || bear.eyeCount > 2 || bear.mouthCount > 1) )
					DestroyBear(bear);
			else if (destroyUnfinished && (bear.earCount != 2 || bear.eyeCount != 2 || bear.mouthCount != 1) )
					DestroyBear(bear);

		}
	}

	void DestroyBear(Bear bear)
	{

		bear.belt.RemoveBear(bear);
		Destroy(bear.gameObject);

	}
}
