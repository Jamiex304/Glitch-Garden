using UnityEngine;
using System.Collections;

public class GraveStone : MonoBehaviour {

	//GraveStone Controller
	private Animator animator;
	
	void Start(){
		animator = GetComponent<Animator>();
	}
	
	void Update(){
		
	}
	
	void OnTriggerStay2D(Collider2D collider){
		Attackers attackers = collider.gameObject.GetComponent<Attackers>();
		
		if(attackers){
			animator.SetTrigger("underAttackTrigger");
		}
	}
}
