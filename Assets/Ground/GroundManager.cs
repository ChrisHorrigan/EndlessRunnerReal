using UnityEngine;
using System.Collections;

public class GroundManager : MonoBehaviour {
	public Transform prefab;
	public Transform gemPrefab;
	public Vector3 startPos;
	public Vector3 gemPos;
	public int numGround;
	Vector3 nextPos;
	ArrayList groundList=new ArrayList();
	public ArrayList gemList=new ArrayList();
	public float offset=5f;
	
	// Use this for initialization
	void Start () {
		GameManager.gameStarter+=gameStart;
		GameManager.gameEnder+=gameEnd;
		enabled = false;
		/*nextPos=startPos;
		Transform firstGround=(Transform)Instantiate(prefab);
	
		firstGround.localPosition=startPos;
		gemList.Add(firstGround);
		for(int i=1;i<numGround;i++){
			MoreGround ();
		}*/
		
	}//CAPS MATTER ON VARIABLES
	
	// Update is called once per frame
	void Update () {
		Transform tempground=(Transform)groundList[0];
		
		if(Runner.distanceRun - tempground.localPosition.z > offset){
			
			groundList.RemoveAt (0);
			if(gemList.Count>0){
				Transform tempgem=(Transform)gemList[0];
				if(Runner.distanceRun-tempgem.localPosition.z>offset){
				gemList.RemoveAt (0);
				GameObject.Destroy(tempgem.gameObject);}}
			GameObject.Destroy (tempground.gameObject);
			MoreGround();
		}
		
		
		
	}
	void MoreGround(){
		float putGem=Random.Range (1,2);
		Transform tempGround=(Transform)Instantiate (prefab);//potentially shift to the side
		float shift=Random.Range (-7f,7f);
		float makeAGem=Random.Range (-1f,1f);
		if(makeAGem<0f){
			Transform newGem=(Transform)Instantiate (gemPrefab);
			gemPos.x=nextPos.x;
			gemPos.z=nextPos.z;
			
			float gemShift=Random.Range (-3f,3f);
			gemPos.x+=gemShift;
			newGem.localPosition=gemPos;//y height can be 11
			gemList.Add(newGem);
		}
		nextPos.x+=shift;
		tempGround.localPosition=nextPos;
		groundList.Add (tempGround);
		nextPos.z+=tempGround.localScale.z;
		nextPos.x-=shift;
	}
	public void gameStart(){
		enabled=true;
		nextPos=startPos;
		Transform firstGround=(Transform)Instantiate(prefab);
	
		firstGround.localPosition=startPos;
		groundList.Add(firstGround);
		for(int i=1;i<numGround;i++){
			MoreGround ();
		}
	}
	public void gameEnd(){
		for(int i=groundList.Count-1;i >= 0; i--){
			//if(groundList[i]!=null){
			Transform tempground=(Transform)groundList[i];
			groundList.RemoveAt(i);
			GameObject.Destroy (tempground.gameObject);}
		//}
		for(int i=gemList.Count-1;i>=0;i--){
			
			Transform tempGem=(Transform)gemList[i];
			gemList.RemoveAt(i);
			GameObject.Destroy (tempGem.gameObject);
		}
		
		
		enabled=false;
	}
}

