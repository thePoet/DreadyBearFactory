using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public GameObject title;
	public GameObject startGamePrompt;
	public GameObject[] levelInstructions;
	public BearCreator bearCreator;

	int activeLevel;

	void Awake()
	{
		instance = this;
	}

	void Start()
	{
		foreach( GameObject levelInst in levelInstructions)
			levelInst.SetActive(false);

		startGamePrompt.SetActive(true);
		title.SetActive(true);

	}

	public void OnStartGameClicked()
	{
		title.SetActive(false);
		startGamePrompt.SetActive(false);

		activeLevel = 1;
		Invoke("TitleForLevel", 0.5f);
	}

	void TitleForLevel()
	{
		levelInstructions[activeLevel-1].SetActive(true);
		Invoke ("StartLevel", 2f);
	}

	void StartLevel()
	{
		foreach( GameObject levelInst in levelInstructions)
			levelInst.SetActive(false);

		bearCreator.StartLevel(1);
	}



}
