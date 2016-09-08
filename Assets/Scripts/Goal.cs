using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour 
{
		void OnTriggerEnter2D(Collider2D other) 
		{
			Bear bear = other.gameObject.GetComponent<Bear>();

			if (bear != null)
			{
				bear.belt.RemoveBear(bear);
				ScoreCounter.instance.AddBear(bear);
	//			GameManager.instance.OnBearFinished();
			}
		}
}

