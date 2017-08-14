using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun;
	private GameObject projectileParent;
	
	private Animator animator;
	private Spawner myLanwSpawner;
	
	void Start(){
		animator = GameObject.FindObjectOfType<Animator>();
		
		projectileParent = GameObject.Find ("Projectiles");
		
		if(!projectileParent){
			projectileParent = new GameObject("Projectiles");
		}
		
		//Checks if spawner exists
		SetMyLaneSpawner();
		print(myLanwSpawner);
	}
	
	void Update () {
			if(IsAttackerAheadInLane()){
				animator.SetBool("isAttacking", true);
			}else{
				animator.SetBool("isAttacking", false);
			}
	}
	
	void SetMyLaneSpawner(){
		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();
		
		foreach(Spawner spawner in spawnerArray){
			if(spawner.transform.position.y == transform.position.y){
				myLanwSpawner = spawner;
				return;
			}
		}
		
		Debug.LogError(name + " can't find spawner in lane");
	}
	
	bool IsAttackerAheadInLane(){
		//Exit if No Attackers in Lane
		if(myLanwSpawner.transform.childCount <= 0){
			return false;
		}
		
		//If we find an attacker are they ahead ? 
		foreach(Transform attacker in myLanwSpawner.transform){
			if(attacker.transform.position.x > transform.position.x){
				return true;
			}
		}
		
		//Attackers in Lane but behind the Defender Line
		return false;
	}
	
	private void Fire(){
		GameObject newProjectile = Instantiate(projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
}
