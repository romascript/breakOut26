using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class DestruirCuandoEsGolpeado : MonoBehaviour {

    int point;
    int cantDestroy = Datos.Cantidad;

    public Scene scene;

    public Text score;
    

    void Start()
    {
        scene = SceneManager.GetActiveScene();

        if (scene.name == "level2")
        {
            point = Datos.Score;
        }
        else
        {
            point = 0;
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Iniciamos el efecto de sonido cuando la pelota coliciona con un ladrillo.
        PlaySound.Instance.brickBall.Play ();
        Destroy(gameObject);
        updateCount();
        //Cuenta la cantidad de bloques destruidos.
        cantDestroy = Datos.Cantidad + 1;
        Datos.Cantidad = cantDestroy;
    }

    void updateCount()
    {
        point = point + 5;
        Datos.Score = Datos.Score + point;
        Debug.Log("Points:" + Datos.Score);
        score.text = "Score: " + Datos.Score.ToString();
    }
}
