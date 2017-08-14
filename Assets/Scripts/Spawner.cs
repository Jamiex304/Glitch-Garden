using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] attackerPrefabArray;
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject thisAttacker in attackerPrefabArray){
			if(isTimeToSpawn(thisAttacker)){
				Spawn(thisAttacker);
			}
		}
	}
	
	void Spawn(GameObject myGameObject){
		GameObject myAttacker = Instantiate (myGameObject) as GameObject;
		myAttacker.transform.parent = transform;
		myAttacker.transform.position = transform.position;
	}
	
	bool isTimeToSpawn(GameObject attackerGameObject){
		Attackers attackers = attackerGameObject.GetComponent<Attackers>();
		float meanSpawnDelay = attackers.seenEverySeconds;
		float spawnsPerSecond = 1 / meanSpawnDelay;
		
		if(Time.deltaTime > meanSpawnDelay){
			Debug.LogWarning("Spawn Rate Capped Reached");
		}
		//Divided by 5 because we have 5 lanes
		float threshold = spawnsPerSecond * Time.deltaTime / 5;
		
		if (Random.value < threshold){
			return true;
		}else{
			return false;
		}
	}
}
