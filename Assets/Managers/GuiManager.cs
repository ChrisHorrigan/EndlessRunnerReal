using UnityEngine;
using System.Collections;

public class GuiManager : MonoBehaviour {
	private bool isRunning=false;
	public GUIText title;
	public GUIText instructionText;
	public GUIText distance;
	public GUIText jumps;
	public GUIText loser;
	public static float jumped=0f;
	public static float totalDistance=0f;
	public static int fullScore=0;
	// Use this for initialization
	void Start () {
	jumps.enabled=false;
	distance.enabled=false;
		loser.enabled=false;
		GameManager.gameEnder+=gameEnd;
		GameManager.gameStarter+=gameStart;
		instructionText.material.color=Color.blue;
		title.font.material.color=Color.blue;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp ("space")&&!isRunning){
			GameManager.triggerGameStart ();
			isRunning=true;
		}
		if(isRunning){
			float temp=totalDistance;
			title.enabled=false;
			instructionText.enabled=false;
			distance.enabled=true;
			jumps.enabled=true;
			int printout=(int)Runner.distanceRun;
			printout+=(int)totalDistance;
			fullScore=printout;
			distance.text="Score: "+printout.ToString ();
			jumps.text="Jumps: "+jumped.ToString();
		}
		
	}
	public void gameEnd(){
		loser.font.material.color=Color.blue;
		loser.text="YOU DIED; SCORE: "+fullScore.ToString();
		loser.enabled=true;
		instructionText.enabled=true;//replace this with YOU LOSE text later
		jumped=0;
		totalDistance=0;
		isRunning=false;
	}
	public void gameStart(){
		loser.enabled=false;
		//implement next time
	}
}
