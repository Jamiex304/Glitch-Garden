using UnityEngine;
using System.Collections;

public class SetUserPrefs : MonoBehaviour {
	private MusicManager musicManager;
	
	// Use this for initialization
	void Start () {
		//Get the Save Volume Pref
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		if(musicManager){
			//Debug.Log ("Found : " + musicManager);
			float volume = PlayerPrefsMaster.GetMasterVol();
			musicManager.ChangeVolume(volume);
		}else{
			Debug.LogWarning("No Music Manager Found On Start Scene, Cant Set User Pref Volume || Script - SetUserPrefs.cs");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
