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


        // if (nearby(Time)) EmitAnything();

        // if(inWindow(start,end)) 
        // {
        //      if (isOnBeat(Beatgap)) EmitBla();
        // }

        if (nearby(6092)) EmitWave();
        if (nearby(9110)) EmitWave();

        if(inWindow(12193,46506))
		{
             if (isOnBeat(377)) EmitProjectile();
        }

        if (nearby(24259)) EmitLaser();
        if (nearby(24259)) EmitMissile();

        if (nearby(27176)) EmitLaser();
        if (nearby(27176)) EmitMissile();

        if (nearby(30292)) EmitLaser();
        if (nearby(30292)) EmitMissile();

        if (nearby(33309)) EmitLaser();
        if (nearby(33309)) EmitMissile();

        if (inWindow(47260, 71769))
        {
            if (isOnBeat(377)) EmitProjectile();
        }

        if (nearby(36325)) EmitWave();
        if (nearby(37097)) EmitWave();
        if (nearby(37833)) EmitLaser();
        if (nearby(39341)) EmitWave();
        if (nearby(40096)) EmitWave();

        if (nearby(42358)) EmitWave();
        if (nearby(43112)) EmitWave();
        if (nearby(43866)) EmitLaser();
        if (nearby(45374)) EmitWave();
        if (nearby(46129)) EmitWave();

        if (nearby(47260)) EmitWave();
        if (nearby(47637)) EmitWave();
        if (nearby(48014)) EmitWave();
        if (nearby(48391)) EmitWave();

        if (inWindow(72523, 88737))
        {
            if (isOnBeat(377)) EmitProjectile();
        }
        if (nearby(48391)) EmitLaser();
        if (inWindow(48580, 59326))
        {
            if (isOnBeat(377)) EmitMissile();
        }

        if (nearby(59703)) EmitLaser();
        if (inWindow(60457, 71015))
        {
            if (isOnBeat(1508)) EmitMissile();
        }

        if (nearby(72523)) EmitWave();
        if (nearby(73277)) EmitWave();
        if (nearby(74031)) EmitLaser();
        if (nearby(74785)) EmitLaser();
        if (nearby(75540)) EmitWave();
        if (nearby(78179)) EmitWave();

        if (inWindow(77048, 71015))
        {
            if (isOnBeat(377)) EmitMissile();
        }


        if (nearby(78556)) EmitWave();
        if (nearby(79310)) EmitWave();
        if (nearby(80064)) EmitLaser();
        if (nearby(81572)) EmitWave();
        if (nearby(82327)) EmitWave();

        if (nearby(84589)) EmitWave();
        if (nearby(85343)) EmitWave();
        if (nearby(86097)) EmitLaser();
        if (nearby(87606)) EmitWave();
        if (nearby(88360)) EmitWave();


        if (inWindow(89491, 137001))
        {
            if (isOnBeat(377)) EmitProjectile();
        }

        if (nearby(89491)) EmitWave();
        if (nearby(89868)) EmitWave();
        if (nearby(90245)) EmitWave();
        if (nearby(90622)) EmitWave();
        if (nearby(90622)) EmitLaser();
        if (inWindow(90811, 94377))
        {
            if (isOnBeat(377)) EmitMissile();
        }
        if (nearby(101557)) EmitWave();
        if (nearby(101934)) EmitWave();
        if (nearby(102311)) EmitWave();
        if (nearby(102688)) EmitWave();
        if (nearby(102688)) EmitLaser();

        if (inWindow(120976, 137378))
        {
            if (isOnBeat(377)) EmitMissile();
        }
        if (nearby(126820)) EmitLaser();
        if (nearby(127574)) EmitLaser();
        if (nearby(129837)) EmitLaser();
        if (nearby(130591)) EmitLaser();

        if (inWindow(138996, 173579))
        {
            if (isOnBeat(377)) EmitProjectile();
        }
        if (inWindow(138996, 173579))
        {
            if (isOnBeat(377)) EmitMissile();
        }
        if (inWindow(138996, 149521))
        {
            if (isOnBeat(1508)) EmitWave();
        }
        if (inWindow(149897, 173579))
        {
            if (isOnBeat(1508)) EmitLaser();
        }
        if (inWindow(150649, 173579))
        {
            if (isOnBeat(1508)) EmitLaser();
        }
        if (nearby(173579)) EmitWave();


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
