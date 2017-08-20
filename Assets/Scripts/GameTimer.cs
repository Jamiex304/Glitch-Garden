using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {

	private Slider slider;
	private AudioSource audioSource;
	private bool isEndOfLevel = false;
	private LevelManager levelManager;
	private GameObject winAlert;
	
	public float levelSeconds = 100;//By Default 100 seconds
	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider>();
		audioSource = GetComponent<AudioSource>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		winAlert = GameObject.Find("WinAlert");
		if(!winAlert){
			Debug.LogWarning("Please Create WinAlert Text Feild");
		}
		winAlert.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = Time.timeSinceLevelLoad / levelSeconds;
		if(Time.timeSinceLevelLoad >= levelSeconds  && !isEndOfLevel){
			HandleWinCondition ();
			DestroyAllTaggedObjects();
		}
	}

	void HandleWinCondition()
	{
		audioSource.Play ();
		winAlert.SetActive (true);
		Invoke ("LoadNextLevel", audioSource.clip.length);
		isEndOfLevel = true;
	}
	
	void DestroyAllTaggedObjects(){
		GameObject[] taggedObjectArray = GameObject.FindGameObjectsWithTag("DestroyOnWin");
		foreach(GameObject taggedObject in taggedObjectArray){
			Destroy(taggedObject);
		}
	}
	
	void LoadNextLevel(){
		levelManager.LoadNextLevel();
	}
}
