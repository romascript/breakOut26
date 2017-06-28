using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LlamarFuncionRestarVida : MonoBehaviour {

    //Poniendo 5 vidas nos ahorramos un bug :P
    int vidas = 5;
    Vector3 temp = new Vector3(0.0f, -4.5f, 0.0f);
	
    void OnCollisionEnter2D(Collision2D col)
    {
        StartCoroutine(CRout());
       
    }
    IEnumerator CRout()
    {
        Destroy(GameObject.Find("Corazon" + vidas));
        temp.y = 200.0f;
        GameObject.Find("bolitacrota").transform.position = temp;
        vidas = vidas - 1;
        temp.y = -4.45f;
        yield return new WaitForSeconds(1);
        GameObject.Find("Paddle").transform.position = temp;
        GameObject.Find("bolitacrota").transform.position = temp;
        Vector2 temp2 = new Vector2(1, 8);
        GameObject.Find("bolitacrota").GetComponent<Rigidbody2D>().velocity = temp2;

        if (vidas == 0)
        {
            Datos.Cantidad = 0;
            Paddle.saveScore();
            SceneManager.LoadScene("gameOver");
        }
        
    }
}
