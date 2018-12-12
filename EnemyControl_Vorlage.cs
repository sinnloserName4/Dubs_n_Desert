using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour {


	public GameObject LaserPrefab;
	public GameObject ProjectilePrefab;
	public GameObject WavePrefab;
	public GameObject MissilePrefab;
	public Transform spawn0;
	public Transform spawn1;
	public Transform spawn2;
	public Transform spawn3;
	public Transform spawn4;
	public Transform spawn5;


	// DARUDE SANDSTORM
	public int NumberOfSources;
	public ulong BeatGap;       // Gap between 2 Beats in Milliseconds Formula: (1/(BpM*60))
	public ulong BeatOffset;    // Time until first Beat




	private float TimeOffset = 3f;
	private float SongTime;
	private ulong SongTimeInMilliseconds = 127;
	private Transform[] spawn;

	private AudioSource aud;
	private Animator anim;


	// Use this for initialization
	void Start () 
	{
		aud = GetComponent<AudioSource> ();
		aud.PlayDelayed (TimeOffset);
		anim = GetComponent<Animator> ();

		spawn = new Transform[NumberOfSources];
		for (int i=0; i<NumberOfSources; i++) {
			switch (i) {
			case 0:
				spawn [i] = spawn0;
				break;
			case 1:
				spawn [i] = spawn1;
				break;
			case 2:
				spawn [i] = spawn2;
				break;
			case 3:
				spawn [i] = spawn3;
				break;
			case 4:
				spawn [i] = spawn4;
				break;
			case 5:
				spawn [i] = spawn5;
				break;
			}
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void FixedUpdate()
	{	if(SongTime == 0f) anim.SetTrigger ("BeatStarted");
		SongTime = Time.timeSinceLevelLoad - TimeOffset;
		if (SongTime >= 0f)	SongTimeInMilliseconds = (ulong)(SongTime * 1000);


		if (isMainBeat(SongTimeInMilliseconds))
        {
            // FOR MAIN BEAT DO

        }

        // Else 


        //  Example:
        // if(nearby(TimeInMilliSeconds)
        //  do anything
            
        //
        //  Commands:   EmitProjectile();
        //              EmitMissile();
        //              EmitWave();
        //              EmitLaser();
        //              
        // Optional param: source (int from 0 to NrOfSources)


        // if nearby(Time) EmitAnything();

        // if(inWindow(start,end)) 
        // {
        //      if (isOnBeat(Beatgap)) EmitBla();
        // }
		

		
	}


	void EmitProjectile()
	{
        EmitProjectile(Random.Range(0, NumberOfSources - 1));
	}

    void EmitProjectile(int source)
	{
		Instantiate (ProjectilePrefab, spawn[source].position, Quaternion.identity);
	}

	void EmitLaser()
	{
        EmitLaser(2);
	}

    void EmitLaser(int source)
	{
		Instantiate (WavePrefab, spawn[source].position, Quaternion.identity);

	}

	void EmitWave()
	{
		EmitWave (Random.Range (0, NumberOfSources - 1));
	}

	void EmitWave(int source)
	{
		Instantiate (WavePrefab, spawn [source].position, Quaternion.identity);
	}

	void EmitMissile()
	{
        EmitMissile(Random.Range(0, NumberOfSources - 1));
	}

    void EmitMissile(int source)
	{
		Instantiate (MissilePrefab, spawn [source].position, Quaternion.identity);
	}
    bool isMainBeat(ulong time)
    {
        return (((time - BeatOffset) % BeatGap) < (ulong)(Time.fixedDeltaTime * 1000));
    }

    bool Nearby(ulong time)
    {
        return (SongTimeInMilliseconds > time-(Time.fixedDeltaTime * 500)  && SongTimeInMilliseconds <=time+(Time.fixedDeltaTime * 500))
    }

    bool inWindow(ulong from, ulong until)
    {
        return (SongTimeInMilliseconds > from && SongTimeInMilliseconds < until);
    }

    bool isOnBeat(ulong gap)
    {
        return ((SongTimeInMilliseconds % gap) < (ulong)(Time.fixedDeltaTime * 1000));
    }
}
