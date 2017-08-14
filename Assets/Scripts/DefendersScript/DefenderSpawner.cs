using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;
	private GameObject defenderParent;
	private StarDisplay starDisplay;
	
	void Start(){
		defenderParent = GameObject.Find ("Defenders");
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
		
		if(!defenderParent){
			defenderParent = new GameObject("Defenders");
		}
	}
	
	void OnMouseDown(){
		Vector2 rawPos = CalaculateWorldPointOfMouseClick();
		Vector2 roundPos = SnapToGrid(rawPos);
		//print (Input.mousePosition);
		//print (SnapToGrid(CalaculateWorldPointOfMouseClick()));
		GameObject defender = Button.selectedDefender;
		
		//Spawn a Defender if you have the correct value amount for a spawn
		int defenderCost = defender.GetComponent<Defenders>().starCost;
		if(starDisplay.UseStars(defenderCost) == StarDisplay.Status.Success){
			SpawnDefender (roundPos, defender);
		}else{
			Debug.Log("Insufficient Stars for Spawn");
		}
	}
	
	void SpawnDefender (Vector2 roundPos, GameObject defender)
	{
		Quaternion zeroRot = Quaternion.identity;
		GameObject newDef = Instantiate (defender, roundPos, zeroRot) as GameObject;
		newDef.transform.parent = defenderParent.transform;
	}
	
	Vector2 SnapToGrid(Vector2 rawWorldPos){
		float newX = Mathf.RoundToInt(rawWorldPos.x);
		float newY = Mathf.RoundToInt(rawWorldPos.y);
		return new Vector2(newX,newY);
	}
	
	Vector2 CalaculateWorldPointOfMouseClick(){
		//return new Vector2(0,0);
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		
		float distanceFromCamera = 10f;
		Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
		
		Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);
		
		return worldPos;
	}
}
