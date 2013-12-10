using UnityEngine;
using System.Collections;

public class GemManager : MonoBehaviour {
	public Transform gemPrefab;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(){
		print ("You hit a gem");
		GuiManager.totalDistance+=100;
		
		GameObject.Destroy(this);
		
	}
}
