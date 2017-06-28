using UnityEngine;
using UnityEngine.UI;
using System.Collections;


namespace Assets
{
    public class destruitBricksNaranjas : MonoBehaviour
    {
        int cantDestroy = Datos.Cantidad;
        int point = 0;
        int life = 2;
        public Text score;

        void OnCollisionEnter2D(Collision2D col)
        {
            //Iniciamos el efecto de sonido cuando la pelota coliciona con un ladrillo.
            PlaySound.Instance.brickBall.Play();

            life--;
            updateCount();

           gameObject.GetComponent<Renderer>().material.color =Color.grey;

            if (life == 0)
            {
                //updateCount();
                Destroy(gameObject);
                //Cuenta la cantidad de bloques destruidos.
                cantDestroy = Datos.Cantidad + 1;
                Datos.Cantidad = cantDestroy;
            }
        }

        void updateCount()
        {
            point = point + 10;
            Datos.Score = Datos.Score + point;
            //Debug.Log("Points:"+Datos.Score);
            score.text = "Score: " + Datos.Score.ToString();
        }
    }
}
