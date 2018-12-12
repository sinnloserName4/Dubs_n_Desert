using UnityEngine;
using System.Collections;

public class MissileControl : MonoBehaviour {


	public float velocity = 4f;


	private Vector3 player;
	private Rigidbody2D rb2D;

	// Use this for initialization
	void Start () 
	{
		GameObject playerC = (GameObject.Find("Player"));
		player = playerC.gameObject.GetComponent<Rigidbody2D>().position;
		rb2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{
		Vector3 direction = (player - new Vector3(rb2D.position.x,rb2D.position.y,1)).normalized;
		rb2D.AddForce (direction * velocity);


	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player"))
			other.SendMessage ("gotHit", PlayerController.WeaponType.Missile);
		if (!other.CompareTag("Ignore"))Destroy(gameObject);
	}
}
