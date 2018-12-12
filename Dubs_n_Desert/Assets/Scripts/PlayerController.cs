using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public enum WeaponType { Laser, Wave, Projectile, Missile };


	public float MaximumVelocity = 3;

    private float MaxHealth = 100;
    private float Health;
	private Rigidbody2D rb2d;
    private Animator anim;
    private byte view = 0;
    private byte oldView;
    private bool controllable;
    private uint[] collectables;
    


	public Rigidbody2D getRB2D()
	{
		return rb2d;
	}
	// Use this for initialization
	
    void LoadMenu()
    {
        
    }

    void Start () 
	{
        collectables = new uint[2];
		rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        controllable = true;
        MaxHealth = StaticSingleton.instance.GetMaxHealth();
        Health = MaxHealth;
    }
	
	// Update is called once per frame
	void Update () 
	{
        oldView = view;
        if (controllable)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");



            float AxisVelocity = Mathf.Sqrt(horizontal * horizontal + vertical * vertical);
            anim.SetFloat("Velocity", AxisVelocity);

            if (horizontal > 0.2f) view = 1;
            if (horizontal < -0.2f) view = 3;
            if (vertical < -0.2f) view = 2;
            if (vertical > 0.2f) view = 0;

            if (view != oldView)
            {
                if (view == 0) anim.SetTrigger("Back");
                if (view == 1) anim.SetTrigger("Right");
                if (view == 2) anim.SetTrigger("Front");
                if (view == 3) anim.SetTrigger("Left");
            }

            rb2d.velocity = new Vector2(horizontal * MaximumVelocity, vertical * MaximumVelocity);
        }
	}

	void FixedUpdate()
	{
        updateHealthBar();
        if (Time.time % 200 < 2) heal();
	    if (isDead())
        {
            //irgendwas cooles zum Spiel beenden
            loose();

        }
	}

    public void win()
    {
        print("win");
        if (StaticSingleton.instance.getLevel() == 1) Application.LoadLevel("Story4");
        if (StaticSingleton.instance.getLevel() == 2) Application.LoadLevel("Story5");
        if (StaticSingleton.instance.getLevel() == 3) Application.LoadLevel("StoryFinish2");
        
    }

    public void loose()
    {

        if (StaticSingleton.instance.getLevel() == 1) Application.LoadLevel("Testlevel");
        if (StaticSingleton.instance.getLevel() == 2) Application.LoadLevel("Ice");
        if (StaticSingleton.instance.getLevel() == 3) Application.LoadLevel("Space");
        /*
        controllable = false;
        GameObject e = GameObject.Find("Enemy");
        e.SendMessage("stop");
        GameObject le = GameObject.FindWithTag("loose");
        le.GetComponent<SpriteRenderer>().enabled = true;
        GameObject.FindWithTag("win").GetComponent<SpriteRenderer>().enabled = false;
        */
    }
    void collect()
    {
        collectables[0]++;
        StaticSingleton.instance.incCollected();
    }
    void NewCollectable()
    {
        collectables[1]++;
        StaticSingleton.instance.incNumberOfCollectables();
    }
    void resume()
    {
        controllable = true;
        GameObject.Find("loose").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("Enemy").SendMessage("resume");
    }

    void updateHealthBar()
    {
        GameObject.Find("healthbar").transform.localScale = new Vector3(Health / MaxHealth, 1);
    }

    void heal()
    {
        Health += (MaxHealth - Health) / 40;
    }
	bool isDead()
	{
		if (Health <= 0)
			return true;
		return false;
	}

	public void gotHit(WeaponType rhs)
	{
        anim.SetTrigger("Hit");
        GameObject.Find("bloody").GetComponent<Animator>().SetTrigger("hit");
        switch (rhs) 
		{
		case WeaponType.Laser:
			Health -= 5;
			break;
		case WeaponType.Wave:
			Health -= 5;
			break;
		case WeaponType.Projectile:
			Health -= 5;
			break;
		case WeaponType.Missile:
			Health -= 5;
			break;
		}
	}

}
