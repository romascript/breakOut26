using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Xml;

public class funciones : MonoBehaviour {

    /*public void testPaddle()
    {

    }*/

    public void pauseGame()
    {
        if (Time.timeScale == 1)
        {  
            Time.timeScale = 0;
            GameObject.Find("btn_pause").GetComponentInChildren<Text>().text = "Play";
            PlaySound.Instance.breakOut.Pause();
        }
        else if (Time.timeScale == 0)
        {   
            Time.timeScale = 1;
            GameObject.Find("btn_pause").GetComponentInChildren<Text>().text = "Pause";
            PlaySound.Instance.breakOut.Play();
        }
    }

    public void pauseAudio()
    {
        if (PlaySound.Instance.breakOut.mute == true)
        {
            GameObject.Find("btn_audio").GetComponentInChildren<Text>().text = "Music On";
            PlaySound.Instance.breakOut.mute = false;
        }
        else if (PlaySound.Instance.breakOut.mute == false)
        {
            GameObject.Find("btn_audio").GetComponentInChildren<Text>().text = "Music Off";
            PlaySound.Instance.breakOut.mute = true;
        }
    }

    public void soundOff()
    {
        if (PlaySound.Instance.brickBall.mute == true)
        {
            GameObject.Find("btn_soundEffect").GetComponentInChildren<Text>().text = "Sound On";
            PlaySound.Instance.brickBall.mute = false;
            PlaySound.Instance.paddleBall.mute = false;
            PlaySound.Instance.wallBall.mute = false;
        }
        else if (PlaySound.Instance.brickBall.mute == false)
        {
            GameObject.Find("btn_soundEffect").GetComponentInChildren<Text>().text = "Sound Off";
            PlaySound.Instance.brickBall.mute = true;
            PlaySound.Instance.paddleBall.mute = true;
            PlaySound.Instance.wallBall.mute = true;
        }
    }

    public void state1()
    {
        CalibScript.state = 1;
        Debug.Log("State set to:"+CalibScript.state.ToString());
    }

    public void saveParameters()
    {
        var pathxml = Datos.PathXmlGlobal + "\\webcam_config.xml";

        XmlDocument doc = new XmlDocument();

        //(1) the xml declaration is recommended, but not mandatory
        XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
        XmlElement root = doc.DocumentElement;
        doc.InsertBefore(xmlDeclaration, root);

        XmlElement element1 = doc.CreateElement(string.Empty, "parameters", string.Empty);
        doc.AppendChild(element1);

        XmlElement element3 = doc.CreateElement(string.Empty, "hueHigh", string.Empty);
        XmlText text1 = doc.CreateTextNode(Datos2._HueHigh.ToString());
        element3.AppendChild(text1);
        element1.AppendChild(element3);

        XmlElement element4 = doc.CreateElement(string.Empty, "hueLow", string.Empty);
        XmlText text2 = doc.CreateTextNode(Datos2._HueLow.ToString());
        element4.AppendChild(text2);
        element1.AppendChild(element4);

        XmlElement element5 = doc.CreateElement(string.Empty, "satHigh", string.Empty);
        XmlText text3 = doc.CreateTextNode(Datos2._SatHigh.ToString());
        element5.AppendChild(text3);
        element1.AppendChild(element5);

        XmlElement element6 = doc.CreateElement(string.Empty, "satLow", string.Empty);
        XmlText text4 = doc.CreateTextNode(Datos2._SatLow.ToString());
        element6.AppendChild(text4);
        element1.AppendChild(element6);

        doc.Save(pathxml);
    }

}
