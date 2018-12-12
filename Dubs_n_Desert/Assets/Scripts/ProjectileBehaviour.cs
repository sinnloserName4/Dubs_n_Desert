using UnityEngine;
using System.Collections;

public class ProjectileBehaviour : MonoBehaviour {

	public float velocity = 4f;

	private Vector2 player;
	private Rigidbody2D rb2D;
    private float StartTime;
	
	// Use this for initialization
	void Start () 
	{
		GameObject playerC = (GameObject.Find("Player"));
		player = playerC.GetComponent<Rigidbody2D>().position;
		rb2D = GetComponent<Rigidbody2D> ();
        Vector2 direction = (player - rb2D.position).normalized;
		rb2D.velocity =  (direction * velocity);
        StartTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate()
	{
       if (Time.time - StartTime > 5f) Destroy(gameObject);
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.CompareTag("Player"))
        {
            other.SendMessage("gotHit", PlayerController.WeaponType.Projectile);
            Destroy(gameObject);
        }
        if ((!other.CompareTag("Ignore"))) { }//Destroy(gameObject);
		
	}
}
