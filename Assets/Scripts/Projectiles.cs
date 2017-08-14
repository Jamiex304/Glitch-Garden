using UnityEngine;
using System.Collections;

public class Projectiles : MonoBehaviour {

	public float speed, damage;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.right * speed * Time.deltaTime);
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		Attackers attackers = collider.gameObject.GetComponent<Attackers>();
		HealthSystem healthsystem = collider.gameObject.GetComponent<HealthSystem>();
		
		if(attackers && healthsystem){
			healthsystem.DealDamage(damage);
			Destroy(gameObject);
		}
	}
	
}
