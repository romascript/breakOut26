using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleTest : MonoBehaviour {

    public GameObject ball;
    Vector3 temp = new Vector3(0.0f, -4.5f, 0.0f);

    void Start()
    {
        ball.SetActive(true);
    }

    public void restart()
    {
        if (ball.activeInHierarchy)
        {
            ball.SetActive(false);
        }
        else
        {
            ball.SetActive(true);
            StartCoroutine(CRout());
        }
    }

    IEnumerator CRout()
    {
        temp.y = 200.0f;
        ball.transform.position = temp;
        //vidas = vidas - 1; //Temporalmente desactivadas por testings.
        temp.y = -4.45f;
        yield return new WaitForSeconds(1);
        ball.transform.position = temp;
        Vector2 temp2 = new Vector2(1, 8);
        ball.GetComponent<Rigidbody2D>().velocity = temp2;
    }


}
