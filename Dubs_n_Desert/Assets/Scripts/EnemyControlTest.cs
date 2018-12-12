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
        // if(SongTimeInMilliseconds > 3000  && SongTimeInMilliseconds <=3005)
        //  do anything
            
        //
        //  Commands:   EmitProjectile();
        //              EmitMissile();
        //              EmitWave();
        //              EmitLaser();
        //              
        // Optional param: source (int from 0 to NrOfSources)

        if (SongTimeInMilliseconds > 301 && SongTimeInMilliseconds <= 306)
            EmitProjectile();
        if (SongTimeInMilliseconds > 482 && SongTimeInMilliseconds <= 487)
            EmitProjectile();
        if (SongTimeInMilliseconds > 668 && SongTimeInMilliseconds <= 673)
            EmitProjectile();
        if (SongTimeInMilliseconds > 872 && SongTimeInMilliseconds <= 877)
            EmitProjectile();
        if (SongTimeInMilliseconds > 1231 && SongTimeInMilliseconds <= 1236)
            EmitProjectile();
        if (SongTimeInMilliseconds > 1370 && SongTimeInMilliseconds <= 1375)
            EmitProjectile();
        if (SongTimeInMilliseconds > 1451 && SongTimeInMilliseconds <= 1456)
            EmitProjectile();
        if (SongTimeInMilliseconds > 1565 && SongTimeInMilliseconds <= 1570)
            EmitProjectile();
        if (SongTimeInMilliseconds > 1745 && SongTimeInMilliseconds <= 1750)
            EmitProjectile();
        if (SongTimeInMilliseconds > 1892 && SongTimeInMilliseconds <= 1897)
            EmitProjectile();
        if (SongTimeInMilliseconds > 2072 && SongTimeInMilliseconds <= 2077)
            EmitProjectile();
        if (SongTimeInMilliseconds > 2268 && SongTimeInMilliseconds <= 2273)
            EmitProjectile();
        if (SongTimeInMilliseconds > 2423 && SongTimeInMilliseconds <= 2428)
            EmitProjectile();
        if (SongTimeInMilliseconds > 2627 && SongTimeInMilliseconds <= 2632)
            EmitProjectile();
        if (SongTimeInMilliseconds > 2790 && SongTimeInMilliseconds <= 2795)
            EmitProjectile();
        if (SongTimeInMilliseconds > 2978 && SongTimeInMilliseconds <= 2983)
            EmitProjectile();
        if (SongTimeInMilliseconds > 3059 && SongTimeInMilliseconds <= 3064)
            EmitProjectile();
        if (SongTimeInMilliseconds > 3157 && SongTimeInMilliseconds <= 3162)
            EmitProjectile();






 

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
}
