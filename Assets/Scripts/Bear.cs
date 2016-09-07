using UnityEngine;
using System.Collections;

public class Bear : MonoBehaviour {



	public GameObject[] eyes;
	public GameObject[] ears;
	public GameObject[] mouths;

	int eyeCount = 0;
	int earCount = 0;
	int mouthCount = 0;

	void Awake () 
	{
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
