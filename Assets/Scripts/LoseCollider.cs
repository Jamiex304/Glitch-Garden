using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;
	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	void OnTriggerEnter2D(){
		print ("Lose Collider Hit");
		levelManager.LoadLevel("03b_Lose");
	}
}
