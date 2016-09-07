using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour {

//	public KeyCode key;
	public Belt feedBelt;
	public Belt destinationBeltA;
	public Belt destinationBeltB;
	public GameObject spriteA;
	public GameObject spriteB;
	public GameObject buttonDeactive;
	public BearDetector bearDetector;

	// Use this for initialization
	void Start () 
	{
		feedBelt.nextBelt = destinationBeltA;
		spriteB.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
	/*	if (Input.GetKeyDown( key ))
		{
			Switch();
		}*/
		if ( bearDetector.IsDetected() )
			buttonDeactive.SetActive(true);
		else
			buttonDeactive.SetActive(false);
		
	}


	void Switch()
	{
		if (feedBelt.nextBelt == destinationBeltB)
			feedBelt.nextBelt = destinationBeltA;
		else
			feedBelt.nextBelt = destinationBeltB;

		spriteA.SetActive(!spriteA.activeSelf);
		spriteB.SetActive(!spriteB.activeSelf);

	}

	void OnMouseDown() 
	{
		if ( !bearDetector.IsDetected() )
		    Switch();
	}
}
