using UnityEngine;
using System.Collections;
//Attached to the MusicMaster GameObject Only One Per Game 
public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;//Array Size is Public change the number depending on scenes
	
	private AudioSource audioSource;
	
	
	// Use this for initialization
	void Awake(){
		DontDestroyOnLoad(gameObject);
		Debug.Log("Dont Destory on load: " + name);
	}
	
	void Start(){
		audioSource = GetComponent<AudioSource>();
		//Get the Save Volume Pref
		audioSource.volume = PlayerPrefsMaster.GetMasterVol();
	}
	
	public void ChangeVolume(float volume){
		audioSource.volume = volume;
	}
	
	void OnLevelWasLoaded(int level){
		AudioClip thisLevelMusic = levelMusicChangeArray[level];
		Debug.Log("Playing clip: "+ thisLevelMusic);
		
		if(thisLevelMusic){//If there is some music attached in the Array (Do this)
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play ();		
		}
	}
}
