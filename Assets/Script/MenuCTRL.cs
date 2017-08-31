using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using OpenCvSharp;

public class MenuCTRL : MonoBehaviour 
{
    string pathNow = Directory.GetCurrentDirectory() + "\\xml";
    string path;

    void Start()
    {

        if (File.Exists(pathNow))
        {
            Debug.Log("Exist!");
            Datos.PathXmlGlobal = pathNow;
        }

        else
        {
            Debug.Log("Not exist!");
            path = Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\xml").ToString();
            Datos.PathXmlGlobal = path;

        }
        
    }

    public void loadUserName(string sceneName)
    {
        SceneManager.LoadScene("userName");
    }

    public void loadScene ( string sceneName) 
	{
        SceneManager.LoadScene("scene1");
    }
    
    public void loadSceneCalibtoMenu ( string sceneName) 
    {
        CalibScript._webcamTexture.Stop();
        SceneManager.LoadScene("menu");
      
    }

    public void loadScenereplay(string sceneName)
    {   
        OpenCVDevelop._webcamTexture.Stop();
        SceneManager.LoadScene("scene1");
        
    }

    public void loadMenu(string sceneName)
    {
        OpenCVDevelop._webcamTexture.Stop();
        SceneManager.LoadScene("menu");
        Time.timeScale = 1;
    }

    public void loadConfig(string sceneName)
    {
        SceneManager.LoadScene("OpenCVCalib");
    }

    public void openManual(string sceneName)
    {
        Application.OpenURL(@"breakOut26_manual.html");
    }
}

