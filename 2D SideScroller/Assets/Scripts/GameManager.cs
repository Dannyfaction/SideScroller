using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	
	public Text ScoreText;
	public Text TextScore;
	
	public static int totalScore;

	public void Start()
	{
//		GameObject[] objects = GameObject.FindGameObjectsWithTag ("Collectable");
		totalScore = 0;
		UpdateUI();
	}
	
	void Update()
	{
		UpdateUI ();
		totalScore += 1;
	}

	void UpdateUI()
	{
		ScoreText.text = "Score: " + totalScore;
		//TextScore.text = "Score: " + totalScore;
	}
}

