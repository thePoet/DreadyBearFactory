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
	public GameObject livesCounter;


	public int numBearsToWin;
	public float speedFactor = 1.0f;
	public float percentageOfBearsWithParts = 0.3f;
	public float secondsBetweenBearsCreated = 3.0f;
	public int numBearsToBeCreated = 5;

	public BearCreator bearCreator;


	bool gameIsOn = false;
	//int bearsFinished = 0;

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
		livesCounter.SetActive(false);
		ScoreCounter.instance.Show(false);

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
		gameIsOn = true;

		foreach( GameObject levelInst in levelInstructions)
			levelInst.SetActive(false);

		bearCreator.interval = secondsBetweenBearsCreated;
		bearCreator.numToBeCreated = numBearsToBeCreated;
		bearCreator.StartLevel(1);
		//bearsFinished = 0;
		bearCountText.text = "0 / " + numBearsToWin;
		livesCounter.SetActive(true);
		ScoreCounter.instance.Empty( numBearsToWin );
		ScoreCounter.instance.Show(true);

	}
	/*
	public void OnBearFinished()
	{
		bearsFinished++;
		bearCountText.text = bearsFinished + " / " + numBearsToWin;
	}*/

	void Update()
	{
		if (gameIsOn && ScoreCounter.instance.GetCount() >= numBearsToWin)
		{
			gameIsOn = false;
			victoryScreen.SetActive(true);
		}

		if (gameIsOn && FaultsCounter.instance.GetCount() > 2)
		{
			gameIsOn = false;
			Invoke("GameOver", 1f );
		}
	}

	void GameOver()
	{
		livesCounter.SetActive(false);
		gameOverScreen.SetActive(true);
	}

}
