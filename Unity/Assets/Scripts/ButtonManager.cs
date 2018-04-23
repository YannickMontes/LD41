using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {


    private float coeff = 1.2f;

	public void newGameButton(string newGameLevel){
		SceneManager.LoadScene (newGameLevel);
	}
		
	public void exitGameButton(){
		Application.Quit ();
	}

}
