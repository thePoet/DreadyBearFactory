using UnityEngine;
using System.Collections;

public class BearCreator : MonoBehaviour {

	public float interval;
	public int numToBeCreated;
	int numCreated = 0;
	public GameObject bearPrefab;
	public Belt belt;
	public bool[] recycled = new bool[13];

	public void StartLevel(int levelNum)
	{
		CancelInvoke();
		numCreated = 0;
		numToBeCreated = 10;
		InvokeRepeating( "CreateBear", 0f, interval);
	}

	public void Stop()
	{
		CancelInvoke();
	}

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void CreateBear () 
	{
		if (numCreated == numToBeCreated)
			return;

		numCreated++;

		GameObject newBear = Instantiate( bearPrefab );
		belt.AddToBelt( newBear.GetComponent<Bear>() );

		//if (Random.value < GameManager.instance.percentageOfBearsWithParts)
		if ( recycled[numCreated-1] )
			AddRandomFeaturesToBear(newBear.GetComponent<Bear>());

		GetComponent<AudioSource>().Play();
	}

	void AddRandomFeaturesToBear(Bear bear)
	{
		float randVal = Random.value;

		if (randVal < 0.25f)
			bear.AddEye();
		else if (randVal < 0.50f)
			bear.AddEar();
		else if (randVal < 0.75f)
		{
			bear.AddEye();
			bear.AddEar();
		}
		else
		{
			bear.AddEye();
			bear.AddEar();
			bear.AddEar();
		}
	}
}
