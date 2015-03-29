using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	public float movementSpeed;
	public GameManager gameManager;

	private ParallaxController _parallaxController;

	void Awake()
	{
		_parallaxController = GetComponent<ParallaxController> ();
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Asteroid") {
			Application.LoadLevel("EndingScreen");
		}
	}

	void Update()
	{
		//float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Jump") * 2;
		Vector2 movement = new Vector2 (1f, y);
		transform.Translate (movement * movementSpeed * Time.deltaTime);
		_parallaxController.Scroll (movement *= -1);
	}
}