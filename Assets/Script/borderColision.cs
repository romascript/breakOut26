using UnityEngine;
using System.Collections;

public class borderColision : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col)
	{	
		//Iniciamos el efecto de sonido cuando la pelota coliciona con un ladrillo.
		PlaySound.Instance.wallBall.Play();
	}
}
