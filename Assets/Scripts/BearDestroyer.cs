using UnityEngine;
using System.Collections;

public class BearDestroyer : MonoBehaviour {

	public bool destroyMutants;
	public bool destroyUnfinished;
	public GameObject fire;
	public Animator animator;

	Bear toBeDestroyed;

	void Start()
	{
		if (fire!=null)
			HideFire();


	}

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
		toBeDestroyed=bear;

		if (animator!=null)
		{
			animator.SetTrigger("theTrigger");
			Invoke("ReallyDestroyBear",0.35f);
		}

		if (fire!=null)
		{
			fire.SetActive(true);
			Invoke("HideFire", 1f);
			ReallyDestroyBear();
		}

	}

	void ReallyDestroyBear()
	{
		if (toBeDestroyed!=null)
		{
			toBeDestroyed.belt.RemoveBear(toBeDestroyed);
			FaultsCounter.instance.AddFault( toBeDestroyed );
			toBeDestroyed=null;
		}
	}

	void HideFire()
	{
		fire.SetActive(false);
	}
}
