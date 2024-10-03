using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float speed;
	public int health = 5;
	private int score = 0;
	private Rigidbody rb;
	private Scene currentScene;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.W))
		{
			rb.AddForce(Vector3.forward * speed - rb.velocity);
		} else if (Input.GetKey(KeyCode.D))
		{
			rb.AddForce(Vector3.right * speed - rb.velocity);
		} else if (Input.GetKey(KeyCode.S))
		{
			rb.AddForce(Vector3.back * speed - rb.velocity);
		} else if (Input.GetKey(KeyCode.A))
		{
			rb.AddForce(Vector3.left * speed - rb.velocity);
		} else {
			rb.velocity = new Vector3(0, 0, 0);
		}
	}

	void Update() {
		if (health == 0)
		{
			Debug.Log("Game Over!");
			currentScene = SceneManager.GetActiveScene();
			SceneManager.LoadScene(currentScene.name);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Pickup")
		{
			score += 1;
			Debug.Log("Score: " + score);
			Destroy(other.gameObject);
		}
		if (other.gameObject.tag == "Trap")
		{
			health -= 1;
			Debug.Log("Health: " + health);
		}
		if (other.gameObject.tag == "Goal")
		{
			Debug.Log("You win!");
		}
	}
}
