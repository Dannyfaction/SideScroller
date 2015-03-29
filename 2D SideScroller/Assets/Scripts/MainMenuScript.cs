using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour 
{
	public GUISkin GameSkin;
	
	private bool _isFirstMenu = true;
	private bool _isLoadGameMenu = false;
	private bool _isLevelSelectMenu = false;
	private bool _isOptionsMenu = false;
	private bool _isAudioOptions = false;
	private bool _isGraphicsOptions = false;
	private bool _isNewGameMenu = false;
	
	private string _gameName = "Asteroids";
	private string _playerName = "";
	private string _playerGender = "";
	private string _currentLevel = "Main Scene";
	
	private float _gameVolume = 0.6f;
	private float _gameFOV = 60.0f;
	
	public Camera gameCamera;
	
	// Use this for initialization
	void Start () 
	{
		// PlayerPrefs.DeleteAll();
		
		_gameVolume = PlayerPrefs.GetFloat("Game Volume", _gameVolume);
		_gameFOV = PlayerPrefs.GetFloat("Game FOV", _gameFOV);
		
		if(PlayerPrefs.HasKey("Game Volume"))
		{
			AudioListener.volume = PlayerPrefs.GetFloat("Game Volume");
		}
		else
		{
			PlayerPrefs.SetFloat("Game Volume", _gameVolume);
		}
		
		if(PlayerPrefs.HasKey("Game FOV"))
		{
			gameCamera.fieldOfView = PlayerPrefs.GetFloat("Game FOV");
		}
		else
		{
			PlayerPrefs.SetFloat("Game FOV", _gameFOV);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void OnGUI()
	{
		GUI.skin = GameSkin;
		
		GUI.Label(new Rect(30, 30, 300, 25), _gameName, "Menu Title");
		GUI.Label(new Rect(30, 120, 300, 25), "Controls: Arrow Keys", "Menu Title");
		GUI.Label(new Rect(30, 150, 300, 25), "Avoid the asteroids", "Menu Title");

		
		FirstMenu();
//		LoadGameMenu();
		LevelSelectMenu();
		OptionsMenu();
		NewGameOptions();
		AudioOptionsDisplay();
		GraphicsOptionsDisplay();
		
		if(_isLevelSelectMenu == true || _isLoadGameMenu == true || _isOptionsMenu == true || _isNewGameMenu == true)
		{
			if(GUI.Button(new Rect(10, Screen.height - 35, 150, 25), "Back", "Button Style"))
			{
				_isLoadGameMenu = false;
				_isLevelSelectMenu = false;
				_isOptionsMenu = false;
				_isNewGameMenu = false;
				_isAudioOptions = false;
				_isGraphicsOptions = false;
				
				_isFirstMenu = true;
			}
		}
	}
	
	public void FirstMenu()
	{
		if (_isFirstMenu)
		{
			/*
			if (GUI.Button(new Rect(10, Screen.height / 2 - 100, 150, 25), "New Game", "Button Style"))
			{
				_isFirstMenu = false;
				_isNewGameMenu = true;
			}
			if (GUI.Button(new Rect(10, Screen.height / 2 - 65, 150, 25), "Load Game", "Button Style"))
			{
				_isFirstMenu = false;
				_isLoadGameMenu = true;
			}
			*/
			if (GUI.Button(new Rect(10, Screen.height / 2 - 30, 150, 25), "Start Game", "Button Style"))
			{
				_isFirstMenu = false;
				Application.LoadLevel("Main Scene");
				//_isLevelSelectMenu = true;
			}
			
			if (GUI.Button(new Rect(10, Screen.height / 2 + 5, 150, 25), "Options", "Button Style"))
			{
				_isFirstMenu = false;
				_isOptionsMenu = true;
			}
			
			if (GUI.Button(new Rect(10, Screen.height / 2 + 40, 150, 25), "Quit Game", "Button Style"))
			{
				Application.Quit();
			}
		}
	}
	
	public void NewGameOptions()
	{
		if(_isNewGameMenu)
		{
			GUI.Label(new Rect(10, Screen.height / 2 - 200, 200, 50), "New Game", "Sub Menu Title");
			
			GUI.Label(new Rect(10, Screen.height / 2 - 100, 90, 25), "Player Name:");
			_playerName = GUI.TextField(new Rect(120, Screen.height / 2 - 100, 200, 25), _playerName);
			
			GUI.Label(new Rect(10, Screen.height / 2 - 65, 90, 25), "Player Gender:");
			_playerGender = GUI.TextField(new Rect(120, Screen.height / 2 - 65, 200, 25), _playerGender);
			
			if(_playerName != "" && _playerGender != "")
			{
				if (GUI.Button(new Rect(10, Screen.height / 2 - 30, 150, 25), "Create Chatacter", "Button Style"))
				{
					PlayerPrefs.SetString("Player Name", _playerName);
					PlayerPrefs.SetString("Player Gender", _playerGender);
					PlayerPrefs.SetString("Current Level", _currentLevel);
					
					//  Application.LoadLevel("Level01");
				}
			}
			else
			{
				if (GUI.Button(new Rect(10, Screen.height / 2 - 30, 150, 25), "Generating", "Button Style"))
				{
					
				}
			}
		}
	}
	/*
	public void LoadGameMenu()
	{
		if(_isLoadGameMenu)
		{
			GUI.Label(new Rect(10, Screen.height / 2 - 200, 200, 50), "Load Game", "Sub Menu Title");
			GUI.Box(new Rect(10, Screen.height / 2 - 100, Screen.width / 2 + 100, Screen.height - 450), "Choose Save Game", "Box Style");
			
			if(PlayerPrefs.HasKey("Player Name"))
			{
				GUI.Label(new Rect(20, Screen.height / 2 - 65, 200, 25), "Player Name: " + PlayerPrefs.GetString("Player Name"));
				GUI.Label(new Rect(230, Screen.height / 2 - 65, 200, 25), PlayerPrefs.GetString("Player Gender"));
				
				if (GUI.Button(new Rect(Screen.width / 2 - 220, Screen.height / 2 - 65, 150, 25), "Load Character", "Button Style"))
				{
					Application.LoadLevel(PlayerPrefs.GetString("Current Level"));
				}
				
				if (GUI.Button(new Rect(Screen.width / 2 - 60, Screen.height / 2 - 65, 150, 25), "Delete Character", "Button Style"))
				{
					PlayerPrefs.DeleteAll();
				}
			}
		}
	}
*/
	public void LevelSelectMenu()
	{
		if(_isLevelSelectMenu)
		{
			GUI.Label(new Rect(30, Screen.height / 2 - 200, 200, 50), "Level Select", "Sub Menu Title");
			// Top Buttons
			if (GUI.Button(new Rect(10, Screen.height / 2 - 100, 200, 150), "Jelle", "Button Style"))
			{
				Application.LoadLevel("Level01");
			}
			
			if (GUI.Button(new Rect(220, Screen.height / 2 - 100, 200, 150), "Ruben", "Button Style"))
			{
				
			}
			
			if (GUI.Button(new Rect(430, Screen.height / 2 - 100, 200, 150), "Rosmerta", "Button Style"))
			{
				
			}

		}
	}
	
	public void OptionsMenu()
	{
		if(_isOptionsMenu)
		{
			GUI.Label(new Rect(30, Screen.height / 2 - 200, 200, 50), "Options", "Sub Menu Title");
			
			if (_isAudioOptions == true || _isGraphicsOptions == true)
			{
				GUI.Box(new Rect((Screen.width / 2)+380, 0, (Screen.width / 2)-380, Screen.height), "", "Box Style");
			}
			
			if (GUI.Button(new Rect(10, Screen.height / 2 - 30, 150, 25), "Audio Options", "Button Style"))
			{
				_isGraphicsOptions = false;
				_isAudioOptions = true;
			}
			
			if (GUI.Button(new Rect(20, Screen.height / 2 + 5, 150, 25), "Graphics Options", "Button Style"))
			{
				_isAudioOptions = false;
				_isGraphicsOptions = true;
			}
		}
	}
	
	public void AudioOptionsDisplay()
	{
		if(_isAudioOptions)
		{
			GUI.Label(new Rect(Screen.width / 2 + 400, 30, 200, 50), "Audio", "Sub Menu Title");
			
			GUI.Label(new Rect(Screen.width / 2 + 400, 115, 200, 25), "Game Volume:");
			_gameVolume = GUI.HorizontalSlider(new Rect(Screen.width / 2 + 400, 150, Screen.width / 2 -450, 25), _gameVolume, 0.0f, 1.0f);
			GUI.Label(new Rect(Screen.width - 35, 145, 50, 25), "" + (System.Math.Round(_gameVolume, 2)));
			AudioListener.volume = _gameVolume;
			/*
			if (GUI.Button(new Rect(Screen.width / 2 + 10, Screen.height - 35, 150, 25), "Apply", "Button Style"))
			{
				PlayerPrefs.SetFloat("Game Volume", _gameVolume);
			}
			*/
		}
	}
	
	public void GraphicsOptionsDisplay()
	{
		if(_isGraphicsOptions)
		{
			GUI.Label(new Rect((Screen.width / 2) + 400, 30, 200, 50), "Video", "Sub Menu Title");
			
			//GUI.Label(new Rect(Screen.width / 2 + 10, 115, 200, 25), "Game FOV:");
			//_gameFOV = GUI.HorizontalSlider(new Rect(Screen.width / 2 + 10, 150, Screen.width / 2 - 55, 25), _gameFOV, 40.0f, 100.0f);
			//GUI.Label(new Rect(Screen.width - 35, 145, 50, 25), "" + (int)_gameFOV);
			//gameCamera.fieldOfView = _gameFOV;
			
			GUILayout.BeginVertical();
			
			GUI.Label(new Rect(Screen.width / 2 + 400, 200, 200, 25), "Graphics Quality");
			for(int i = 0; i < QualitySettings.names.Length; i++)
			{
				if (GUI.Button(new Rect(Screen.width / 2 + 400, 235 + i * 35, 150, 25), QualitySettings.names[i], "Button Style"))
				{
					QualitySettings.SetQualityLevel(i, true);
				}
			}
			
			GUILayout.EndVertical();
			/*
			if (GUI.Button(new Rect(Screen.width / 2 + 10, Screen.height - 35, 150, 25), "Apply", "Button Style"))
			{
				PlayerPrefs.SetFloat("Game FOV", _gameFOV);
			}
			*/
		}
	}
}
