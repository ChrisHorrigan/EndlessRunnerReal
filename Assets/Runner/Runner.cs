using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {//extending MonoBehavior
	Vector3 newPos=new Vector3(0f, 0f, 0f);
	public static float distanceRun=0f;
	public float speed = 5f;
	public float accel= .01f;
	public float jumpHeight=15f;
	public float gravity=-15f;
	public float terminalVelocity=-3f;//check this out
	private CharacterController controller;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		GameManager.gameStarter+=gameStart;
		GameManager.gameEnder+=gameEnd;
		//gameObject.SetActive (false); never mind this
		enabled=false;
	}
	
	// Update is called once per frame
	void Update () {
		newPos.z=speed*Time.deltaTime;
		newPos.x=Input.GetAxis("Horizontal")*Time.deltaTime*5f;
			
		if(Input.GetButtonUp ("Jump")){
			
			if(controller.isGrounded){
				newPos.y =jumpHeight;
				GuiManager.jumped++;
				}}
		if(newPos.y>terminalVelocity)
			newPos.y+=gravity*Time.deltaTime;
		controller.Move (newPos);
		/*newPos.z+=speed * Time.deltaTime;
		transform.localPosition=newPos;*/
		distanceRun=transform.localPosition.z;
		if(transform.localPosition.y<-5f){//THE END IS HERE
			GameManager.triggerGameEnd();
		}
	}
	public void gameStart(){
		enabled=true;
		newPos.x=0;
		newPos.y=0;
		newPos.z=0;
		distanceRun=0;
		transform.localPosition=newPos;
	}
	public void gameEnd(){
		
		enabled=false;
	}
}

