using UnityEngine;
using System.Collections;

public class botonSalir : MonoBehaviour {

	public void salir ()
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit ();
		#endif
	}

}