using UnityEngine;
using System.Collections;

public class LaserBehaviour : MonoBehaviour {

	public int way = 0;
	private float StartTime;


	// Use this for initialization
	void Start () 
	{
	
		StartTime = Time.time;

	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void FixedUpdate()
	{
		if (Time.time - StartTime > 1.3f)
			Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player"))
			other.SendMessage ("gotHit", PlayerController.WeaponType.Laser);
	}
}
