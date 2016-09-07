using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bear : MonoBehaviour {

	static List<Bear> allBears = new List<Bear>();

	public GameObject[] eyes;
	public GameObject[] ears;
	public GameObject[] mouths;

	public Belt belt  = null;

	public int eyeCount = 0;
	public int earCount = 0;
	public int mouthCount = 0;

	static int BearCount()
	{
		return allBears.Count;
	}

	static void DestroyAll()
	{
		for (int i=allBears.Count; i>0; i--)
			Destroy(allBears[i]);
	}

	void Awake () 
	{
		allBears.Add(this);

		foreach (GameObject eye in eyes)
			eye.SetActive(false);
		foreach (GameObject ear in ears)
			ear.SetActive(false);
		foreach (GameObject mouth in mouths)
			mouth.SetActive(false);
	}

	public void AddEye()
	{
		if (eyeCount<3)
			eyes[eyeCount].SetActive(true);
		eyeCount++;
	}
	public void AddEar()
	{
		if (earCount<3)
			ears[earCount].SetActive(true);
		earCount++;
	}
	public void AddMouth()
	{
		if (mouthCount<2)
			mouths[mouthCount].SetActive(true);
		mouthCount++;
	}

	
	void Update () {
	
	}
}
