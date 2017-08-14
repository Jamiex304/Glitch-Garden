using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attackers))]
public class Fox : MonoBehaviour {

	private Animator anim;
	private Attackers attackers;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		attackers = GetComponent<Attackers>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		
		GameObject obj = collider.gameObject;
		//Leave the method if not a defender
		if(!obj.GetComponent<Defenders>()){
			return;
		}
		
		if(obj.GetComponent<GraveStone>()){
			Debug.Log("Fox Collided with " + collider);
			anim.SetTrigger("JumpTrigger");
		}else{
			anim.SetBool("isAttacking",true);
			attackers.Attack(obj);
		}
		
	}
}
