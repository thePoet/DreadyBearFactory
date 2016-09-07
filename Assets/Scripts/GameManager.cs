using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject title;
	public GameObject startGamePrompt;
	public GameObject[] levelInstructions;

	int activeLevel;

	void Start()
	{

	}

	void OnStartGameClicked()
	{
		title.SetActive(false);
		startGamePrompt.SetActive(false);
		activeLevel = 1;
		Invoke("TitleForLevel", 1f);
	}

	void TitleForLevel()
	{
		levelInstructions[activeLevel].SetActive(true);
	}

	void StartLevel()
	{
		foreach( GameObject levelInst in levelInstructions)
			levelInst.SetActive(false);
		
	}



}
