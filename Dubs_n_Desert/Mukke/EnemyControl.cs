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

        // if nearby(Time) EmitAnything();

        // if(inWindow(start,end)) 
        // {
        //      if (isOnBeat(Beatgap)) EmitBla();
        // }
        
        if (nearby(3487)) EmitWave();
        if (nearby(10344)) EmitWave();
        if (nearby(13773)) EmitWave();
        
        //till 184
        if(inWindow(3487,81914))
        {
            if (isOnBeat(429)) EmitProjectile();
        }
        if (inWindow(4344, 12915))
        {
            if (isOnBeat(1714)) EmitMissile();
        }

        //A
        if (nearby(30915)) EmitLaser();//65 now...
        if (nearby(34344)) EmitLaser();//73
        if (nearby(36058)) EmitLaser();//77
        if (nearby(37772)) EmitLaser();//81
        if (nearby(41201)) EmitLaser();//89
        if (nearby(42915)) EmitLaser();//93
        if (nearby(44629)) EmitLaser();//97
        if (nearby(48058)) EmitLaser();//105
        if (nearby(49772)) EmitLaser();//109
        if (nearby(51486)) EmitLaser();//113        
        //offbeat
        if(inWindow(51701,57915))
        {
            if (isOnBeat(429)) EmitProjectile();
        }
        if ((nearby(54486)) EmitWave();//120 
        //B
        if (nearby(57915)) EmitWave();//128
        //missiles from 129 to 184
        if(inWindow(58343,81914))
        {
            if (isOnBeat(429)) EmitMissile();
        }
        if (nearby(58772)) EmitLaser();//130
        if (nearby(61772)) EmitLaser();//137
        if (nearby(65629)) EmitLaser();//146
        if (nearby(68629)) EmitLaser();//153
        if (nearby(72486)) EmitLaser();//162
        if (nearby(75486)) EmitLaser();//169
        if (nearby(79343)) EmitLaser();//178        
        //185 - 190
        if(inWindow(82343,84486))
        {
            if (isOnBeat(429)) EmitWave();
        }
        //offbeat
        if(inWindow(84272,84914))
        {
            if (isOnBeat(429)) EmitWave();
        }
        if (nearby(84914)) EmitLaser();




        //till 312
        if(inWindow(85771,136770))
        {
            if (isOnBeat(429)) EmitProjectile();
        }

        //A
        if (nearby(85771)) EmitLaser();//193 now...
        if (nearby(89200)) EmitLaser();//201
        if (nearby(90914)) EmitLaser();//205
        if (nearby(92628)) EmitLaser();//209
        if (nearby(96057)) EmitLaser();//217
        if (nearby(97771)) EmitLaser();//221
        if (nearby(99485)) EmitLaser();//225
        if (nearby(102914)) EmitLaser();//233
        if (nearby(104628)) EmitLaser();//237
        if (nearby(106342)) EmitLaser();//241

        //offbeat
        if(inWindow(106557,112771))
        {
            if (isOnBeat(429)) EmitProjectile();
        }

        if (nearby(109342)) EmitLaser();//248
         
        if (nearby(112771)) EmitLaser();//256
        //missiles from 257 to 312
        if(inWindow(113199,136770))
        {
            if (isOnBeat(429)) EmitMissile();
        }
        
        if (nearby(113628)) EmitLaser();//258
        if (nearby(116628)) EmitLaser();//265
        if (nearby(120485)) EmitLaser();//274
        if (nearby(123485)) EmitLaser();//281
        if (nearby(127342)) EmitLaser();//290
        if (nearby(130342)) EmitLaser();//297
        if (nearby(234199)) EmitLaser();//306

        //313 - 318
        if(inWindow(137199,139342))
        {
            if (isOnBeat(429)) EmitWave();
        }
        //offbeat
        if(inWindow(139128,139770))
        {
            if (isOnBeat(429)) EmitWave();
        }
        if (nearby(139770)) EmitLaser();//319

        if(inWindow(140627,167198))
        {
            if (isOnBeat(429)) EmitProjectile();
        }
        if(inWindow(141056,167198))
        {
            if (isOnBeat(858)) EmitMissile();
        }
        if (nearby(153484)) EmitLaser();
        if (nearby(153484)) EmitWave();

        if (nearby(167198)) EmitLaser();
        if (nearby(167198)) EmitWave();
 

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
