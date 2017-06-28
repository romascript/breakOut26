using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {

	//Delaracion de los archivos de sonidos.
	public static PlaySound Instance;
    public AudioSource paddleBall;
	public AudioSource brickBall;
	public AudioSource wallBall;
    public AudioSource breakOut;

    void Start()
    {
        //Inicia el backsound.
       // PlaySound.Instance.breakOut.Play();
        //PlaySound.Instance.breakOut.loop = true;
    }

    void Awake()
	{
		Instance = this;
	}
   
}

//Donde se quierea agregar un efecto de sonido se lo llamara "PlaySound.Instance.(nombre de la variable).Play ();"