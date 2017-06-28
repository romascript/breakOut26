using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class valueUpdate : MonoBehaviour {

    public Text _hueHigh;
    public Text _hueLow;
    public Text _satHigh;
    public Text _satLow;

    void Start()
    {
        getParameters();
    }
	
	// Update is called once per frame
	void Update () {

        _hueHigh.text = Datos2._HueHigh.ToString();
        _hueLow.text = Datos2._HueLow.ToString();
        _satHigh.text = Datos2._SatHigh.ToString();
        _satLow.text = Datos2._SatLow.ToString();

    }

    void getParameters()
    {

        XmlDocument xml = new XmlDocument();
        xml.Load(Datos.PathXmlGlobal + "\\webcam_config.xml");

        XmlNodeList xnList = xml.SelectNodes("/parameters");

        foreach (XmlNode xn in xnList)
        {
            GameObject.Find("HueLow").GetComponent<Slider>().value = Int32.Parse(xn["hueLow"].InnerText);
            GameObject.Find("HueHigh").GetComponent<Slider>().value = Int32.Parse(xn["hueHigh"].InnerText);
            GameObject.Find("SatLow").GetComponent<Slider>().value = Int32.Parse(xn["satLow"].InnerText);
            GameObject.Find("SatHigh").GetComponent<Slider>().value = Int32.Parse(xn["satHigh"].InnerText);
        }
        
        //Debug.Log(_hueHigh+"\n "+_hueLow + "\n " + _satHigh + "\n " + _satLow);

    }
}
