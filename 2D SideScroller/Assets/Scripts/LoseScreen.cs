using UnityEngine;
using System.Collections;

public class LoseScreen : MonoBehaviour 
{
	public GUISkin GameSkin;
	private bool _isFirstMenu = true;
	//static int totalScore = new totalScore;
	public int endText;

	//private string _currentLevel = "EndingScreen";
	
	public Camera gameCamera;

	void OnGUI()
	{
		endText = GameManager.totalScore;
		GUI.skin = GameSkin;
		
		//GUI.Label(new Rect(30, 30, 300, 25), _gameName, "Menu Title");
		
		FirstMenu();

	}
	
	public void FirstMenu()
	{
		if (_isFirstMenu)
		{
			GUI.TextField(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 170, 150, 50), "Score : " + endText, "Box Style");
			//guiText.fontSize = 50;


			if (GUI.Button(new Rect(Screen.width / 2 - 180, Screen.height / 2 + 75, 150, 50), "Restart", "Button Style"))
			{
				//guiText.fontSize = 50;
				_isFirstMenu = false;
				Application.LoadLevel("Main Scene");
				//_isLevelSelectMenu = true;
			}
			if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 75, 150, 50), "Quit Game", "Button Style"))
			{
				Application.Quit();
			}
		}
	}
	void UpdateUI()
	{
		//TextScore.text = "Score: " + totalScore;
	}
}
