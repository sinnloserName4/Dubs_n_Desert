using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour
{
	private float offset;
	public float speed = 29.0f;
	public GUIStyle style;
	public Rect viewArea;
	
	private void Start()
	{
		if (this.viewArea.width == 0.0f)
		{
			this.viewArea = new Rect(0.0f, 0.0f, Screen.width, Screen.height);
		}
		this.offset = this.viewArea.height;
	}
	
	private void Update()
	{
		this.offset -= Time.deltaTime * this.speed;
	}
	
	private void OnGUI()
	{
		GUI.BeginGroup(this.viewArea);
		
		var position = new Rect(0, this.offset, this.viewArea.width, this.viewArea.height);
		var text = @"Dubs 'n' Desert

CREDITS



TEAM Dubs 'n' Desert

Nils Pöcking
Lennart von der Lühe
Alexander Wilhelm
Martin Weise

Art/Design/Animation
Selfmade


Music


Oskar Hill & Meizong 
The Sound Of Summer by Oskar Hill

Darude
Sandstorm (Bass Kleph Bootleg Remix) by Bass Kleph

Vengaboys 
Boom Boom Boom Boom!! (LSDJ Remix) by RoccoW

The Prodigy
Omen (DMNDZ Remix) by DMNDZ

Oh Wee (Immortal Beats) / CC BY-SA 3.0


All tracks are licensed under Creative Commons Licence.



Geiles Spiel, nicht wahr? ;)
";
		
		GUI.Label(position, text, this.style);
		
		GUI.EndGroup();
	}
}