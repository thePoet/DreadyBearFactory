using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour {

//	public KeyCode key;
	public Belt feedBelt;
	public Belt destinationBeltA;
	public Belt destinationBeltB;
	public GameObject spriteAon;
	public GameObject spriteAoff;
	public GameObject spriteBon;
	public GameObject spriteBoff;

	public GameObject buttonDeactive;
	public BearDetector bearDetector;

	bool pushable = true;
	bool toA= true;

	// Use this for initialization
	void Start () 
	{
		feedBelt.nextBelt = destinationBeltA;
		UpdateSprite();
	}
	
	// Update is called once per frame
	void Update () 
	{
	/*	if (Input.GetKeyDown( key ))
		{
			Switch();
		}*/

		if ( bearDetector.IsDetected() && pushable )
		{
			pushable = false;
			UpdateSprite();
		}

		if ( !bearDetector.IsDetected() && !pushable )
		{
			pushable = true;
			UpdateSprite();
		}


	}


	void Switch()
	{
		toA = !toA;


		if (toA)
			feedBelt.nextBelt = destinationBeltA;
		else
			feedBelt.nextBelt = destinationBeltB;

		UpdateSprite();
	}

	void UpdateSprite()
	{
		spriteAon.SetActive(false);
		spriteAoff.SetActive(false);
		spriteBon.SetActive(false);
		spriteBoff.SetActive(false);

		if (toA && pushable)
			spriteAon.SetActive(true);
		if (toA && !pushable)
			spriteAoff.SetActive(true);
		if (!toA && pushable)
			spriteBon.SetActive(true);
		if (!toA && !pushable)
			spriteBoff.SetActive(true);
			

	}

	void OnMouseDown() 
	{
		if ( pushable )
		    Switch();
	}
}
