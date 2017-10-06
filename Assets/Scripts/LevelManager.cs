using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	public Transform mainMenu, instructionMenu, stageMenu;
	
	public void LoadScene(string name){
		SceneManager.LoadScene(name);
	}
	
	public void QuitGame(){
		Application.Quit();
	}
	
	public void Instruction(bool clicked){
		if(clicked){
			instructionMenu.gameObject.SetActive(clicked);	
			mainMenu.gameObject.SetActive(false);
		}
		else{
			instructionMenu.gameObject.SetActive(clicked);	
			mainMenu.gameObject.SetActive(true);
		}
	}
	
	public void StageSelect(bool clicked){
		if(clicked){
			stageMenu.gameObject.SetActive(clicked);	
			mainMenu.gameObject.SetActive(false);
		}
		else{
			stageMenu.gameObject.SetActive(clicked);	
			mainMenu.gameObject.SetActive(true);
		}
	}
}
