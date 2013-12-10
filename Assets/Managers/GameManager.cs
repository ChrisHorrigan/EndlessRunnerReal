using UnityEngine;
using System.Collections;

public class GameManager{
	public delegate void GameEvent();
	public static event GameEvent gameStarter, gameEnder;
	public static void triggerGameStart(){
		if(gameStarter!=null){
			gameStarter();
		}
	}
	public static void triggerGameEnd(){
		if(gameEnder!=null){
			gameEnder();
		}
	}
	
	
	
	
}

