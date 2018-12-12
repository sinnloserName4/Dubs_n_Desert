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

        if (nearby(22)) EmitLaser();

        if(inWindow(22,27680)) 
        {
            if (isOnBeat(468)) EmitProjectile();
        }
        if (inWindow(725, 28149))
        {
            if (isOnBeat(936)) EmitMissile();
        }
        if (nearby(15023)) EmitLaser();
        if (nearby(28149)) EmitWave();
        if (nearby(29087)) EmitWave();
        if (nearby(30024)) EmitLaser();
        if (inWindow(30024, 60027))
        {
            if (isOnBeat(468)) EmitProjectile();
        }
        if (inWindow(30727, 60027))
        {
            if (isOnBeat(936)) EmitMissile();
        }
        if (nearby(37525)) EmitLaser();
        if (nearby(45025)) EmitLaser();
        if (nearby(48776)) EmitLaser();//105
        if (nearby(52526)) EmitLaser();
        if (nearby(56276)) EmitLaser();
        if (nearby(60027)) EmitWave();
        if (inWindow(30024, 60027))
        
        //145
        if (inWindow(67527, 125188))
        {
             if (isOnBeat(468)) EmitProjectile(); 
        }
        if (nearby(74559)) EmitLaser();
        if (nearby(75028)) EmitWave();

        if (nearby(78309)) EmitLaser();
        if (nearby(78778)) EmitWave();

        if (nearby(82059)) EmitLaser();
        if (nearby(82528)) EmitWave();

        if (nearby(85810)) EmitLaser();
        if (nearby(86279)) EmitWave();

        if (nearby(89560)) EmitLaser();

        if (inWindow(90029, 105030))
        {
            if (isOnBeat(936)) EmitWave();
        }
        if (nearby(105030)) EmitLaser();
        if (inWindow(105030, 125188))
        {
            if (isOnBeat(468)) EmitMissile();
        }

        //273
        if (inWindow(127532, 157065))
        {
            if (isOnBeat(468)) EmitProjectile();
        }
        if (inWindow(127532, 153784))
        {
            if (isOnBeat(3744)) EmitLaser();
        }
        if (nearby(142064)) EmitWave();
        if (nearby(142298)) EmitWave();
        if (inWindow(135735, 157065))
        {
            if (isOnBeat(936)) EmitMissile();
        }
        if (inWindow(157534, 164566))
        {
            if (isOnBeat(468)) EmitProjectile();
        }
        if (inWindow(157534, 164566))
        {
            if (isOnBeat(936)) EmitWave();
        }

        //353
        if (inWindow(165035, 195037))
        {
            if (isOnBeat(468)) EmitProjectile();
        }
        if (inWindow(165035, 195037))
        {
            if (isOnBeat(3744)) EmitLaser();
        }

        if (inWindow(173004, 195037))
        {
            if (isOnBeat(936)) EmitMissile();
        }
        if (nearby(179567)) EmitWave();
        if (nearby(187067)) EmitWave();
        if (nearby(194099)) EmitWave();
        if (nearby(194568)) EmitWave();
        if (nearby(195037)) EmitWave(); 

        //424
        if (inWindow(198318, 225000))
        {
            if (isOnBeat(3744)) EmitWave();
        }
        if (inWindow(198787, 225000))
        {
            if (isOnBeat(3744)) EmitLaser();
        }
        if (inWindow(198787, 253000))
        {
            if (isOnBeat(468)) EmitProjectile();
        }
        if (inWindow(198787, 253000))
        {
            if (isOnBeat(468)) EmitMissile();
        }
        if (inWindow(532540, 260000))
        {
            if (isOnBeat(7488)) EmitLaser();
        }
        if (inWindow(253166, 255041))
        {
            if (isOnBeat(468)) EmitWave();
        }


		
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
