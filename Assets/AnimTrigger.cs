using UnityEngine;
using System.Collections;

public class AnimTrigger : MonoBehaviour {


	public Animator anim;


	void OnTriggerEnter2D(Collider2D coll) 
	{
		Bear bear =  coll.gameObject.GetComponent<Bear>();
		if (bear != null)
			anim.SetTrigger("theTrigger");
	}
}
