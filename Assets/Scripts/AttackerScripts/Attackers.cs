using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class Attackers : MonoBehaviour {

	//Note: Damage is set in the Animation Attacking Scenes on the Attacking Animations
	//Variables
	private float currentSpeed;
	private GameObject currentTarget;
	private HealthSystem healthSystem;
	private Animator anim;
	
	[Tooltip("Average number of seconds between appearances")]
	public float seenEverySeconds;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		//Vector 3.left will move the character Negative X (Hence Left)
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
		if(!currentTarget){
			anim.SetBool("isAttacking",false);
		}
	}
	
	//Animation Events
	public void SetSpeed(float speed){
		currentSpeed = speed;
	}
	
	public void StrikeCurrentTarget(float damage){
		Debug.Log (name + " caused damage : " + damage);
		if(currentTarget){
			HealthSystem health = currentTarget.GetComponent<HealthSystem>();
			if(health){
				health.DealDamage(damage);
			}
		}
	}
	
	public void Attack(GameObject obj){
		currentTarget = obj;
	}
}
