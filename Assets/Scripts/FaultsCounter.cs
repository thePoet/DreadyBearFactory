using UnityEngine;
using System.Collections;

public class FaultsCounter : MonoBehaviour {

	public static FaultsCounter instance;
	public Transform[] bearLocations;

	int count;

	void Awake()
	{
		instance = this;
	}

	public void AddFault(Bear bear)
	{
		count++;
		if (count==1)
			bear.transform.position = bearLocations[0].position;
		if (count==2)
			bear.transform.position = bearLocations[1].position;
		if (count==3)
			bear.transform.position = bearLocations[2].position;

		if (count>3)
			Destroy(bear.gameObject);
	}

	public int GetCount()
	{
		return count;
	}




}
