using UnityEngine;
using System.Collections;

public class changeScene : MonoBehaviour {


	

	public void Scenechanger (string sceneToChange) {
		Application.LoadLevel (sceneToChange);
	
	}
}
