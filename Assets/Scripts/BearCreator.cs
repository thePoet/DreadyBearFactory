using UnityEngine;
using System.Collections;

public class BearCreator : MonoBehaviour {

	public float interval;
	public int numToBeCreated;
	int numCreated = 0;
	public GameObject bearPrefab;
	public Belt belt;

	// Use this for initialization
	void Start () 
	{
		InvokeRepeating( "CreateBear", 0f, interval);
	}
	
	// Update is called once per frame
	void CreateBear () 
	{
		if (numCreated == numToBeCreated)
			return;

		numCreated++;

		GameObject newBear = Instantiate( bearPrefab );
		belt.AddToBelt( newBear.GetComponent<Bear>() );

		if (numCreated > 2)
			AddRandomFeaturesToBear(newBear.GetComponent<Bear>());
	}

	void AddRandomFeaturesToBear(Bear bear)
	{
		float randVal = Random.value;

		if (randVal < 0.3f)
			bear.AddEye();
		else if (randVal < 0.6f)
			bear.AddEar();
		//else if (randVal < 0.45f)
	//		bear.AddMouth();
	}
}
