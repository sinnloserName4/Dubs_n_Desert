using UnityEngine;
using System.Collections;

public class collectablesBehaviour : MonoBehaviour {

    private float StartTime;
	// Use this for initialization
	void Start () {
        StartTime = Time.time;
        GameObject.Find("Player").SendMessage("NewCollectable");
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void FixedUpdate()
    {
        if (Time.time - StartTime > 5f)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.SendMessage("collect"); Destroy(gameObject);
        }
            
    }
}
