using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCvSharp;   // OpenCVSharp 2.4.9
using Uk.Org.Adcock.Parallel;
using System.Xml;
using System.IO;
using System;

public class OpenCVDevelop : MonoBehaviour {
    public static WebCamTexture _webcamTexture;
    private WebCamTexture _webcamTexture2;  //Texture retrieved from the webcam
    private string deviceName;  // input video devicename
    private int imWidth;  // Input devices image width
    private int imHeight;  // Input devices image height 
    private int imColorChannels = 3; // Number of color channels (red, blue, green (or HSV))
    private MatrixType MonoColorMatrix = MatrixType.U8C1;  // Unsigned 8-bit one channel color (0-255)
    private MatrixType TriColorMatrix = MatrixType.U8C3; // Unsigned 8-bit three channel color (0-255)
    CvMat videoSourceImagex;  // Image from the video source (webcam)
    private bool DrawThresholdImageFlag = true;
    public bool FlipUpDownAxis = false, FlipLeftRightAxis = true;
    public int _hueLow = 0;
    public int _hueHigh = 0;
    public int _satLow = 0;
    public int _satHigh = 0;
    public static double posX;
    double posY;
    IplImage erode;
    IplImage dilate;
    IplImage erode2;
    IplImage erode1;
    IplImage dilate2;
    IplImage dilate1;
    double tempX;
    public static bool first=true;
    // Use this for initialization
    void Start () {

        XmlDocument xml = new XmlDocument();
        xml.Load(Datos.PathXmlGlobal+"\\webcam_config.xml"); 

        XmlNodeList xnList = xml.SelectNodes("/parameters");

        foreach (XmlNode xn in xnList)
        {
            _hueLow = Int32.Parse(xn["hueLow"].InnerText);
            _hueHigh = Int32.Parse(xn["hueHigh"].InnerText);
            _satLow = Int32.Parse(xn["satLow"].InnerText);
            _satHigh = Int32.Parse(xn["satHigh"].InnerText);
        }

        //Debug.Log(_hueHigh+"\n "+_hueLow + "\n " + _satHigh + "\n " + _satLow);

        WebCamDevice[] devices = WebCamTexture.devices;
        Cv.UseOptimized(true);

        //Debug.Log ("Number of video devices = " + devices.Length);

        Cv.DestroyWindow("Erode");
        Cv.DestroyWindow("Dilate");
        Cv.DestroyWindow("HSV Thresholded Image");
        Cv.DestroyAllWindows();
        if (devices.Length > 0)
        {   // If there is at least one camera

            _webcamTexture = new WebCamTexture(devices[0].name);  // Grab first camera
                                                                  // _webcamTexture2 = _webcamTexture;                                                  //Debug.Log ("Device name = " + devices [0].name);

            // Attach camera to texture of the gameObject
            gameObject.GetComponent<Renderer>().material.mainTexture = _webcamTexture;

            // Un-mirror the webcam image
            if (FlipLeftRightAxis)
            {
                transform.localScale = new Vector3(-transform.localScale.x,
                               transform.localScale.y, transform.localScale.z);
                GameObject.Find("Quad").transform.localScale = new Vector3(-transform.localScale.x,
                               transform.localScale.y, transform.localScale.z);
            }

            if (FlipUpDownAxis)
            {
                transform.localScale = new Vector3(transform.localScale.x,
                                    -transform.localScale.y, transform.localScale.z);
                GameObject.Find("Quad").transform.localScale = new Vector3(transform.localScale.x,
                                    -transform.localScale.y, transform.localScale.z);
            }


            _webcamTexture.Play();  // Play the video source

            // Get the vieo source image width and height
            imWidth = _webcamTexture.width;
            imHeight = _webcamTexture.height;
        
            // Create standard CvMat image based on web camera video input
            // 3 channels for color images with unsigned 8-bit depth of color values
            videoSourceImagex = new CvMat(imHeight, imWidth, TriColorMatrix);
            
            if (DrawThresholdImageFlag)
                DrawThresholdSliderBars();

        }

    }

    // Update is called once per frame
    void Update () {


       // _webcamTexture2=  GetThresholdedImage(videoSourceImagex, new CvScalar(_hueLow, _satLow, 0), new CvScalar(_hueLow, _satLow, 0));

   

        if (DrawThresholdImageFlag)
            DrawThresholdImage(videoSourceImagex);
        if (_webcamTexture.isPlaying)
        {

            if (_webcamTexture.didUpdateThisFrame)
            {
                //convert Unity 2D texture from webcam to CvMat
                Texture2DToCvMat();

                // Do some image processing with OpenCVSharp on this image frame
               // ProcessImage(videoSourceImagex);
            }

        }
        else
        {
            Debug.Log("Can't find camera!");
        }
    }

    void DrawThresholdImage(CvMat _img)
    {


		//Bitmap bitmap = new Bitmap(_img);
		
		// _img = OpenCvSharp.Extensions.BitmapConverter.ToMat(bitmap);
        
        CvScalar _cvScalarFrom = new CvScalar(_hueLow, _satLow, 0),
        _cvScalarTo = new CvScalar(_hueHigh, _satHigh, 255);
        CvMat ImgThresholded = GetThresholdedImage(_img, _cvScalarFrom, _cvScalarTo);
        if (first) {
           // Cv.ShowImage("HSV Thresholded Image", ImgThresholded);
        }
        


        //Moments();

        erode = Cv.CreateImage(Cv.GetSize(ImgThresholded), BitDepth.U8, 1);
        erode1= Cv.CreateImage(Cv.GetSize(ImgThresholded), BitDepth.U8, 1);
        erode2 = Cv.CreateImage(Cv.GetSize(ImgThresholded), BitDepth.U8, 1);
        dilate = Cv.CreateImage(Cv.GetSize(ImgThresholded), BitDepth.U8, 1);
        dilate1= Cv.CreateImage(Cv.GetSize(ImgThresholded), BitDepth.U8, 1);
        dilate2 = Cv.CreateImage(Cv.GetSize(ImgThresholded), BitDepth.U8, 1);
        
 
        CvMoments moments;
        //Si es necesario se pueden realizar mas "pasadas" de Erode y Dilate añadiendo un int con la cantidad requerida como 3er parametro.
        //Borra los bordes, si el objeto es muy pequeño será borrado completamente por el pincel de borrado usado (5px si mal no recuerdo). Posterior a esto se agrandan los bordes de los objetos que restan, para asi
        //Recuperar la forma del obj que se esta buscando definir. De esta forma se elimina el ruido de imagen que puede llegar a producir la cámara. 
        // Si se necesita una supresion de ruido mayor lo mejor es usar un blur gausseano antes de Erode y Dilate.
        Cv.Erode(ImgThresholded, erode);
        Cv.Erode(erode, erode1);
        Cv.Erode(erode1, erode2); 
        Cv.Erode(erode2, erode);
        Cv.Erode(erode, erode1);
        Cv.Erode(erode1,erode2);
        Cv.Dilate(erode2, dilate2);
        Cv.Dilate(dilate2, dilate1);
        Cv.Dilate(dilate1, dilate);
        //Mostrar imagen
        //   Cv.ShowImage("Erode", erode);
       
      
        //Calculo de Moments
         Cv.Moments(dilate, out moments, true);
        var moment10 = Cv.GetSpatialMoment(moments, 1, 0);
        
        var moment00 = Cv.GetSpatialMoment(moments, 0, 0);


        //Calculo del centro del objeto en Threshold mediante el uso de moments
        posX = moment10 / moment00;

        //Control en consola de X
        Debug.Log("Val X:" + posX);
        //Mientras el valor este en el rango de lo 'correcto' (Positivo) se actualiza la variable TempX que guarda la ult. posicion de X. 
        //En el caso que no sea posible sacar el moments por un error de la camara o del threshold, la posicion de la barra va a ser la ultima que tuvo.
        //Con esto se ahorran mensajes de error en la consola además de comportamientos extraños. Resumido, si no calcula una posicion se toma la ultima posicion bien calculada.
        if (posX>0) { tempX = posX; }
        else { posX = tempX; }


        //posY = moment01 / moment00;



    }
    void DrawThresholdSliderBars()
    {
        if (first)
        {
 /*Cv.NamedWindow("HSV Thresholded Image");
        Cv.CreateTrackbar("Hue Low", "HSV Thresholded Image", _hueLow, 179, onTrackbarHueLow);
        Cv.CreateTrackbar("Hue High", "HSV Thresholded Image", _hueHigh, 179, onTrackbarHueHigh);
        Cv.CreateTrackbar("Sat Low", "HSV Thresholded Image", _satLow, 255, onTrackbarSatLow);
        Cv.CreateTrackbar("Sat High", "HSV Thresholded Image", _satHigh, 255, onTrackbarSatHigh);
        */
        }
       

    }

    void Texture2DToCvMat()
    {

        //float startTime = Time.realtimeSinceStartup;

        Color[] pixels = _webcamTexture.GetPixels();

        // Parallel for loop
        Parallel.For(0, imHeight, i =>
        {
            for (var j = 0; j < imWidth; j++)
            {

                var pixel = pixels[j + i * imWidth];
                var col = new CvScalar
                {
                    Val0 = (double)pixel.b * 255,
                    Val1 = (double)pixel.g * 255,
                    Val2 = (double)pixel.r * 255
                };

                videoSourceImagex.Set2D(i, j, col);
            }
        });



        //				CvScalar col;
        //				Color pixel;
        //				int i, j;
        //
        //				// Non-parallelized code
        //				for (i = 0; i < imHeight; i++) {
        //						for (j = 0; j < imWidth; j++) {
        //								pixel = pixels [j + i * imWidth];
        //						
        //								col = new CvScalar
        //								{
        //									Val0 = (double)pixel.b * 255,
        //									Val1 = (double)pixel.g * 255,
        //									Val2 = (double)pixel.r * 255
        //								};
        //				
        //								videoSourceImage.Set2D (i, j, col);
        //						}
        //
        //				}

        // Flip up/down dimension and right/left dimension
        if (!FlipUpDownAxis && FlipLeftRightAxis)
            Cv.Flip(videoSourceImagex, videoSourceImagex, FlipMode.XY);
        else if (!FlipUpDownAxis)
            Cv.Flip(videoSourceImagex, videoSourceImagex, FlipMode.X);
        else if (FlipLeftRightAxis)
            Cv.Flip(videoSourceImagex, videoSourceImagex, FlipMode.Y);

        // Test difference in time between parallel and non-parallel code
        //Debug.Log (Time.realtimeSinceStartup - startTime);

    }
    CvMat GetThresholdedImage(CvMat img, CvScalar from, CvScalar to)
    {

        // Hue, Saturation, Value or HSV is a color model that describes colors (hue or tint) 
        // in terms of their shade (saturation or amount of gray) 
        //	and their brightness (value or luminance).

        // Hue is expressed as a number from 0 to 360 degrees representing hues of red (starts at 0), 
        // yellow (starts at 60), green (starts at 120), cyan (starts at 180), 
        // blue (starts at 240), and magenta (starts at 300).
        // Saturation is the amount of gray (0% to 100%) in the color.
        // Value (or Brightness) works in conjunction with saturation and 
        // describes the brightness or intensity of the color from 0% to 100%.

        CvMat imgHsv = ConvertToHSV(img);

        CvMat imgThreshed = new CvMat(img.Rows, img.Cols, MonoColorMatrix);

        imgHsv.InRangeS(from, to, imgThreshed);

        return imgThreshed;

    }

    void onTrackbarHueLow(int position)
    {
        if (position < _hueHigh)
            _hueLow = position;
        else
        {
            Cv.SetTrackbarPos("Hue Low", "HSV image", _hueHigh);
            _hueLow = _hueHigh;
        }
    }

    void onTrackbarHueHigh(int position)
    {
        if (position > _hueLow)
            _hueHigh = position;
        else
        {
            Cv.SetTrackbarPos("Hue High", "HSV image", _hueLow);
            _hueHigh = _hueLow;
        }
    }

    void onTrackbarSatLow(int position)
    {
        if (position < _satHigh)
            _satLow = position;
        else
        {
            Cv.SetTrackbarPos("Sat Low", "HSV image", _satHigh);
            _satLow = _satHigh;
        }
    }

    void onTrackbarSatHigh(int position)
    {
        if (position > _satLow)
            _satHigh = position;
        else
        {
            Cv.SetTrackbarPos("Sat High", "HSV image", _satLow);
            _satHigh = _satLow;
        }
    }

    CvMat ConvertToHSV(CvMat img)
    {

        CvMat imgHSV = img.EmptyClone();  // Assign destination matrix of same size and type

        Cv.CvtColor(img, imgHSV, ColorConversion.BgrToHsv);

        return (imgHSV);

    }

 
}


