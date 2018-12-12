using UnityEngine;
using System.Collections;

public class EnemyControlLevel1 : MonoBehaviour {


	public GameObject LaserPrefab;
	public GameObject ProjectilePrefab;
	public GameObject WavePrefab;
	public GameObject MissilePrefab;
    public GameObject CollectablePrefab;
	public Transform spawn0;
	public Transform spawn1;
	public Transform spawn2;
	public Transform spawn3;
	public Transform spawn4;
	public Transform spawn5;
    public int Level;


	// DARUDE SANDSTORM
	public int NumberOfSources;
	public ulong BeatGap;       // = 460;
	public ulong BeatOffset;    // = 24;
    



	private float TimeOffset = 3f;
	private float SongTime;
	private ulong SongTimeInMilliseconds = 127;
    private ulong lazyTime = 0;
    public bool stopped = false;
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
        updateLevelbar();
        StaticSingleton.instance.setLevel(Level);
	}

    void updateLevelbar()
    {
        float SongLength = aud.clip.length;
        GameObject.Find("levelbar").transform.localScale = new Vector3(SongTime / SongLength, 1);
    }
	void FixedUpdate()
	{	if(SongTime == 0f) anim.SetTrigger ("BeatStarted");
		SongTime = Time.timeSinceLevelLoad - TimeOffset - lazyTime;
		if (SongTime >= 0f)	SongTimeInMilliseconds = (ulong)(SongTime * 1000);
        if (stopped) { lazyTime += (ulong)(Time.fixedDeltaTime*1000); }

        if (!aud.isPlaying && SongTime > 100) GameObject.Find("Player").SendMessage("win");
        if ((SongTimeInMilliseconds % 10057) < 5) EmitCollectable();

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
        if (Level == 1) 
        {

            StaticSingleton.instance.delCollected();
            if (nearby(22)) EmitLaser();

            if (inWindow(22, 27680))
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
        if (Level == 2) {

            if (nearby(6092)) EmitWave();
            if (nearby(9110)) EmitWave();

            if (inWindow(12193, 46506))
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

        if (Level == 3) {
            if (nearby(3487)) EmitWave();
            if (nearby(10344)) EmitWave();
            if (nearby(13773)) EmitWave();

            //till 184
            if (inWindow(3487, 81914))
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
            if (inWindow(51701, 57915))
            {
                if (isOnBeat(429)) EmitProjectile();
            }
            if (nearby(54486)) EmitWave();//120 
            //B
            if (nearby(57915)) EmitWave();//128
            //missiles from 129 to 184
            if (inWindow(58343, 81914))
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
            if (inWindow(82343, 84486))
            {
                if (isOnBeat(429)) EmitWave();
            }
            //offbeat
            if (inWindow(84272, 84914))
            {
                if (isOnBeat(429)) EmitWave();
            }
            if (nearby(84914)) EmitLaser();




            //till 312
            if (inWindow(85771, 136770))
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
            if (inWindow(106557, 112771))
            {
                if (isOnBeat(429)) EmitProjectile();
            }

            if (nearby(109342)) EmitLaser();//248

            if (nearby(112771)) EmitLaser();//256
            //missiles from 257 to 312
            if (inWindow(113199, 136770))
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
            if (inWindow(137199, 139342))
            {
                if (isOnBeat(429)) EmitWave();
            }
            //offbeat
            if (inWindow(139128, 139770))
            {
                if (isOnBeat(429)) EmitWave();
            }
            if (nearby(139770)) EmitLaser();//319

            if (inWindow(140627, 167198))
            {
                if (isOnBeat(429)) EmitProjectile();
            }
            if (inWindow(141056, 167198))
            {
                if (isOnBeat(858)) EmitMissile();
            }
            if (nearby(153484)) EmitLaser();
            if (nearby(153484)) EmitWave();

            if (nearby(167198)) EmitLaser();
            if (nearby(167198)) EmitWave();

        }

	}
    void stop()
    {
        stopped = true;
        aud.Pause();
        anim.enabled = false;
    }

    void resume()
    {
        stopped = false;
        anim.enabled = true;
        aud.UnPause();
    }

    void EmitCollectable()
    {
        Instantiate(CollectablePrefab, new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), 0), Quaternion.identity);
    }
    void EmitProjectile()
    {
        EmitProjectile(Random.Range(0, NumberOfSources - 1));
    }

    void EmitProjectile(int source)
    {
        if (StaticSingleton.instance.getDifficulty() != 0) 
            Instantiate(ProjectilePrefab, spawn[source].position, Quaternion.identity);
    }

    void EmitLaser()
    {
        if (StaticSingleton.instance.getLevel() == 2) { EmitLaser(1); }
        else { EmitLaser(2); }
    }

    void EmitLaser(int source)
    {

        GameObject laser = (GameObject)Instantiate(LaserPrefab, spawn[source].position, Quaternion.identity);
        if (GameObject.Find("Player").transform.position.x < 0)
        {
            laser.GetComponent<Animator>().SetBool("Left",true);
        }
        else 
            laser.GetComponent<Animator>().SetBool("Left", false);

    }

    void EmitWave()
    {
        EmitWave(Random.Range(0, NumberOfSources - 1));
    }

    void EmitWave(int source)
    {
        Instantiate(WavePrefab, spawn[source].position, Quaternion.identity);
    }

    void EmitMissile()
    {
        EmitMissile(Random.Range(0, NumberOfSources - 1));
    }

    void EmitMissile(int source)
    {
        Instantiate(MissilePrefab, spawn[source].position, Quaternion.identity);
    }
    bool isMainBeat(ulong time)
    {
        //return (((time - BeatOffset) % BeatGap) < (ulong)(Time.fixedDeltaTime * 1000)); 
        return false;
    }

    bool nearby(ulong time)
    {
        return (SongTimeInMilliseconds > time - (Time.fixedDeltaTime * 500) && SongTimeInMilliseconds <= time + (Time.fixedDeltaTime * 500));
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
