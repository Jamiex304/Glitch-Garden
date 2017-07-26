using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsMaster : MonoBehaviour {

	public Slider volSlider;
	public Slider diffSlider;
	
	public LevelManager levelManager;
	
	private MusicManager musicManager;

	// Use this for initialization
	void Start () {
		//Music Slider
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		//Debug.Log (musicManager);
		volSlider.value = PlayerPrefsMaster.GetMasterVol();
		
		//Difficulty Slider
		diffSlider.value = PlayerPrefsMaster.GetDifficulty();
	}
	
	// Update is called once per frame
	void Update () {
		musicManager.ChangeVolume(volSlider.value);
	}
	
	public void SaveAndReturn(){
		//Save Values
		PlayerPrefsMaster.SetMasterVol(volSlider.value);
		PlayerPrefsMaster.SetDifficulty(diffSlider.value);
		//Return to Start Level
		levelManager.LoadLevel("01a_StartMenu");
	}
	
	public void SetDefaultValues(){
		volSlider.value = 0.075f;
		diffSlider.value = 1f;
	}
}
