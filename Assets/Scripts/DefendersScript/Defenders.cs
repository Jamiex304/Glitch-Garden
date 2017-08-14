using UnityEngine;
using System.Collections;

public class Defenders : MonoBehaviour {

	private StarDisplay starDisplay;
	public int starCost = 100;//By Default Change the Def Prebabs to give each there own value
	
	void Start(){
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
	}
	
	public void AddStars(int amount){
	//Star Amount in the Star Fire Animation Currently Set to 10
		starDisplay.AddStars(amount);
	}
}
