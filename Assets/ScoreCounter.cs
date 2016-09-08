using UnityEngine;
using System.Collections;

public class ScoreCounter : MonoBehaviour {

	public GameObject[] spots;

	public static ScoreCounter instance;

	int count=0;
	int max=10;

	void Awake()
	{
		instance = this;
	}

	public void Empty(int maximum)
	{
		max=maximum;
		for (int i=0;i<10;i++)
		{
			spots[i].SetActive( i<max );
		}
	}

	public void AddBear(Bear bear)
	{

		if (count<max-1)
		{
			bear.transform.parent = transform;
			bear.transform.position = spots[count].transform.position;
		}
		else
			Destroy(bear.gameObject);

		count++;

	}

	public int GetCount()
	{
		return count;
	}

	public void Show(bool show)
	{
		gameObject.SetActive(show);
	}
}
