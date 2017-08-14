using UnityEngine;
using System.Collections;

public class HealthSystem : MonoBehaviour {

	//Health Variable
	public float health;
		
	public void DealDamage(float damage){
		health -= damage;
		if(health <0){
			//Optionally Trigger Animation
			DestoryObject();
		}
	}
	
	public void DestoryObject(){
		Destroy(gameObject);
	}
}
