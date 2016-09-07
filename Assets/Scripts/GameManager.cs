using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public GameObject title;
	public GameObject startGamePrompt;
	public GameObject[] levelInstructions;
	public GameObject gameOverScreen;
	public GameObject victoryScreen;
	public Text bearCountText;

	public BearCreator bearCreator;

	int bearsFinished = 0;

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
		gameOverScreen.SetActive(false);
		victoryScreen.SetActive(false);
		bearCountText.text = "";

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
		bearsFinished = 0;
		bearCountText.text = "Bears: 0 / 10";
	}

	public void OnBearFinished()
	{
		bearsFinished++;
		bearCountText.text = "Bears: " + bearsFinished + " / 10";
	}


}
