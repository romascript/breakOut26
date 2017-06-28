using UnityEngine;
using System.Collections;

public class ScriptBolita : MonoBehaviour {
		
	// Movement Speed
	public float speed = 100.0f;
	float hitFactor(Vector2 ballPos, Vector2 racketPos,
	                float racketWidth) {
		return (ballPos.x - racketPos.x) / racketWidth;
	}

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
	}

	void OnCollisionEnter2D(Collision2D col) {

		if (col.gameObject.name == "Paddle") {

			PlaySound.Instance.paddleBall.Play ();
			float x=hitFactor(transform.position,
			                  col.transform.position,
			                  0.33f);
			
			Vector2 dir = new Vector2(x, 1).normalized;

			GetComponent<Rigidbody2D>().velocity = dir * speed;
		}
	}
				
}
