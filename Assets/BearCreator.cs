using UnityEngine;
using System.Collections;

public class BearCreator : MonoBehaviour {

	public float interval;
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
		GameObject newBear = Instantiate( bearPrefab );
		belt.AddToBelt( newBear.GetComponent<Bear>() );
	}
}
