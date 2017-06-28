## Sinopsis

Es un proyecto que trata la realidad aumentada. Se llama "BreakOut 26" igual que el nombre del juego. Esta basado en el BreakOut '76 (primera version lanzada por Atari), a 
diferencia del viejo BreakOut '76 que su paddle se movia con las flechitas del teclado, en esta nueva version se mueve a traves de la posicion en donde se encuentre el objeto 
(detecta el color de este) definido, capturado por una webcam, etc.

## Motivacion

Este proyecto surgio a traves de las ideas de un grupo de alumnos de 5to-11, de la E.T N°26. El proyecto fue aprobado por el docente a cargo y desde ahi comenzamos a desarrollarlo,
la mayor motivacion es que es un proyecto que representa a nuestra escuela y a nuestra especialidad.

## Demostracion de codigo

public static void pauseGame()
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

## Instalacion

Para comenzar a contribuir con este proyecto solo es necesario obtener la direccion del repositorio y clonar la carpeta. Anteriormente se necesita tener instalada la ultima version
del Unity y la ultima version del Visual Studio Community 2017 (todo esto deber estar en nuestra PC).


## Colaboradores

Repositorio: https://gitlab.com/17511/breakout26.git
Desarrolladores: @romanrp99 , @Cazadraco, @Sojennlopez .

## License

A short snippet describing the license (MIT, Apache, etc.)