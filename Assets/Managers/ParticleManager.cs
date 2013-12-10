using UnityEngine;
using System.Collections;

public class ParticleManager : MonoBehaviour {
	public ParticleSystem globalField;
	// Use this for initialization
	void Start () {
		GameManager.gameStarter+=gameStart;
		GameManager.gameEnder+=gameEnd;
		globalField.enableEmission=false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void gameStart(){
		
		globalField.enableEmission=true;
	}
	public void gameEnd(){
		
		globalField.enableEmission=false;
	}
	
}
