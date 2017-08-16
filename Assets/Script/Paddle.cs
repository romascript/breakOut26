using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Xml;
using System.IO;


public class Paddle : MonoBehaviour {

    int cantBricksNow;
    public Scene scene;

    void Start()
    {   
        //Obtengo el nombre de la escena.
        Datos.Cantidad = 0;
        scene = SceneManager.GetActiveScene();
        Debug.Log(scene.name);
    }

    void Update()
    {
        cantBricksNow = Datos.Cantidad;

        Debug.Log(cantBricksNow);

        if (scene.name == "scene1")
        {
            if (cantBricksNow == 42)
            {
                saveScore();
                Debug.Log("Next Level");
                SceneManager.LoadScene("winScreen");
                //SceneManager.LoadScene("level2");
            }
        }

        /*El nivel 2 queda desactivado por falta de testeo. 
         * Ademas el juego seria muy largo y esa no seria la idea.*/
        /*if (scene.name == "level2")
        {
            if (cantBricksNow == 63)
            {   
                Debug.Log("Winner!");
                saveScore();
                SceneManager.LoadScene("winScene");
            }
        }*/
    }

    public float speed = 1;
    void FixedUpdate () {
		float h = Input.GetAxisRaw("Horizontal");
		GetComponent<Rigidbody2D>().velocity = Vector2.right * h * speed;
		int a;
		
		bool isNum = int.TryParse(OpenCVDevelop.posX.ToString (), out a); 
        if (OpenCVDevelop.posX > 2 && OpenCVDevelop.posX<608) {
            float postemp =float.Parse(((OpenCVDevelop.posX*0.0122)-3.75).ToString());
            transform.position = new Vector3(postemp, -4.5f/*-4*/, 0);
        }
    }

    //genero el archivo xml para guardar los datos del usuario.
    public static void saveScore()
    {
        var pathxml = Datos.PathXmlGlobal+"\\scores.xml";

        if (File.Exists(pathxml))
        {

            Debug.Log("Exist!");

            XmlDocument doc = new XmlDocument();
            doc.Load(pathxml);

            XmlNode nodePagina = doc.CreateElement("players");

            XmlNode nodeXml = doc.CreateElement("userName");
            nodeXml.InnerText = Datos.UserName;

            XmlNode nodeScore = doc.CreateElement("score");
            nodeScore.InnerText = Datos.Score.ToString();

            nodePagina.AppendChild(nodeXml);
            nodePagina.AppendChild(nodeScore);

            doc.SelectSingleNode("breakOut26").AppendChild(nodePagina);

            doc.Save(pathxml);

        }

        else
        {

            Debug.Log("Not Exist!");

            XmlDocument doc = new XmlDocument();

            //(1) the xml declaration is recommended, but not mandatory
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            XmlElement element1 = doc.CreateElement(string.Empty, "breakOut26", string.Empty);
            doc.AppendChild(element1);

            XmlElement element2 = doc.CreateElement(string.Empty, "players", string.Empty);
            element1.AppendChild(element2);

            XmlElement element3 = doc.CreateElement(string.Empty, "userName", string.Empty);
            XmlText text1 = doc.CreateTextNode(Datos.UserName);
            element3.AppendChild(text1);
            element2.AppendChild(element3);

            XmlElement element4 = doc.CreateElement(string.Empty, "score", string.Empty);
            XmlText text2 = doc.CreateTextNode(Datos.Score.ToString());
            element4.AppendChild(text2);
            element2.AppendChild(element4);

            doc.Save(pathxml);
        }
    }
}
