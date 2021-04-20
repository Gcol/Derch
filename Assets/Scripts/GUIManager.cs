using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour {
	public static GUIManager instance;

	public GameObject gameOverPanel;
	public GameObject gameGoingPanel;

	public Text scoreTxt;
	public Text scoreTxtGameOver;
	public Text moveCounterTxt;
	public Text Life;

	private int score;
	public int moveCounter;

	void Awake() {
		moveCounterTxt.text = moveCounter.ToString();
		instance = GetComponent<GUIManager>();
	}

	public int Score
	{
		get
		{
			return score;
		}

		set
		{
			score = value;
			scoreTxt.text = score.ToString();
		}
	}

	public int MoveCounter
	{
		get
		{
			return moveCounter;
		}

		set
		{
			moveCounter = value;
			if (moveCounter <= 0)
			{
				moveCounter = 0;
				GameOver();
			}
			moveCounterTxt.text = moveCounter.ToString();
		}
	}

	public void GameOver()
	{
		scoreTxtGameOver.text = scoreTxt.text;
		//ButtonsManager.LogKeeper += Score;
		MainGame.LogRessources += Score;
		Life.text = MainGame.LifeScore.ToString();
		gameGoingPanel.SetActive (false);
		gameOverPanel.SetActive (true);
		gameObject.SetActive(false);
		//SceneManager.LoadScene("Map");
	}

}
