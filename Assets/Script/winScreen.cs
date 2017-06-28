using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Xml;
using UnityEngine.UI;

public class winScreen : MonoBehaviour 
{
    public Text uiText;

    // Use this for initialization
    void Start()
    {
        Datos.Cantidad = 0;
        parseXmlFile();
    }

    void parseXmlFile()
    {
        string totVal = "";
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(Datos.PathXmlGlobal+"\\scores.xml");

        string xmlPathPattern = "//breakOut26/players";

        XmlNodeList myNodeList = xmlDoc.SelectNodes(xmlPathPattern);
        foreach (XmlNode node in myNodeList)
        {
            XmlNode username = node.FirstChild;
            XmlNode score = username.NextSibling;

            totVal += " userName : " + username.InnerXml + "\n score:" + score.InnerXml + "\n\n";
            uiText.text = totVal;
        }
    }
}
