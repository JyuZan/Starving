using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Base2 : MonoBehaviour {
	private int count;
    public Text countText2;
    public Text winText;
	public Transform nextMenu;
	public Transform pauseMenu;
	private List<GameObject> insideFood; 

	void Update(){
		if (count <= 0) {
			if (insideFood.Count > 0) {

				for (int i = 0; i < insideFood.Count; i++) {
					GameObject x =insideFood.ElementAt (i);
					Destroy (x);
				}
			}
		}
	}
	
	public void buttonShowUp(bool done){
		if(done){
			nextMenu.gameObject.SetActive(true);
			}
	}
	
	public void hidePause(bool done){
		if(done){
			pauseMenu.gameObject.SetActive(false);
		}
	}
	
    void Start () {
		count = 0;
        countText2.text = "BLUE: " + count.ToString()+ "/5";
        winText.text = "";
		insideFood = new List<GameObject>();
    }
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Food")) {
			insideFood.Add (other.gameObject);
			count += 1;
			other.enabled = false;
            countText2.text = "BLUE: " + count.ToString()+ "/5";
        }

		if (other.gameObject.CompareTag ("Bomb")) {
			count = count -2;
			/*if (count <= 0) {
				if (insideFood.Count > 0) {

					for (int i = 0; i < insideFood.Count; i++) {
						GameObject x =insideFood.ElementAt (i);
						Destroy (x);
					}
				}
			}*/
			if (insideFood.Count >= 2) {
				GameObject a = insideFood.ElementAt (insideFood.Count - 1);
				GameObject b = insideFood.ElementAt (insideFood.Count - 2);
				Destroy (a);
				Destroy (b);
			} else if (insideFood.Count == 1) {
				GameObject a = insideFood.ElementAt (insideFood.Count - 1);
				Destroy (a);
			}
			other.enabled = false;
			countText2.text = "Blue: " + count.ToString() + "/5" + " BOMB!";
		}
        if (count >= 5)
        {
            winText.text = "Blue Wins!";
			if(Time.timeScale == 1){
				Time.timeScale = 0;
				buttonShowUp(true);
				hidePause(true);
			}
        }
    }
}
