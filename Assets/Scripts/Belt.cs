using UnityEngine;
using System.Collections;

using System.Collections.Generic;

public class Belt : MonoBehaviour 
{
	public Transform startMarker;
	//public Transform endMarker;
	public Belt nextBelt;
	public float speed;
	public static float minAllowedDistance = 4f;


	public List<Bear> bears = new List<Bear>();




	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (nextBelt == null || nextBelt.startMarker == null)
			return;
		
		Transform endMarker = nextBelt.startMarker;
		
		foreach(Bear bear in bears)
		{
			float speedModifier = GameManager.instance.speedFactor;
			bear.transform.position = Vector3.MoveTowards( bear.transform.position, endMarker.position, speed * speedModifier * Time.deltaTime );
		}

		foreach( Bear bear in bears)
		{
			if (Vector3.Distance( bear.transform.position, endMarker.position ) < 0.001f && nextBelt.IsRoomOnBelt())
			{
				
				RemoveBear( bear );
				nextBelt.AddToBelt( bear );
				break; // TODO: shame 
			}
		}

	
	}

	public void AddToBelt(Bear bear)
	{
		bear.transform.position = startMarker.position;
		bears.Add(bear);
		bear.belt = this;
	}

	public bool IsRoomOnBelt()
	{
		foreach( Bear bear in bears)
		{
			if (Vector3.Distance( bear.transform.position, startMarker.position ) < minAllowedDistance)
				return false;
		}

		return true;
	}

	public void RemoveBear(Bear bear)
	{
		bear.belt = null;
		bears.Remove( bear );
	}



}
