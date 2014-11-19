using UnityEngine;
using System.Collections;

public class MoveCityPieces : MonoBehaviour {
	public Transform piece1;
	public Transform piece2;
	
	public float switchThreshhold = 10;
	
	
	
	public static Transform activePiece;
	public static Transform hiddenPiece;
	

	// Use this for initialization
	void Start () {
		updateActive();
			
	
	}
	
	// Update is called once per frame
	void Update () {
		updateActive();
		if (this.transform.position.x > activePiece.transform.position.x + switchThreshhold){
			hiddenPiece.transform.position = activePiece.transform.position + (activePiece.collider.bounds.extents.x + hiddenPiece.collider.bounds.extents.x) * Vector3.right;
			
		}
		else if (this.transform.position.x < activePiece.transform.position.x - switchThreshhold){
			hiddenPiece.transform.position = activePiece.transform.position - (activePiece.collider.bounds.extents.x + hiddenPiece.collider.bounds.extents.x) * Vector3.right;
			
		}
		
	
	}

	
	void updateActive(){
		if (Vector3.Distance(piece1.position, this.transform.position) < Vector3.Distance(piece2.position, this.transform.position)){
			activePiece = piece1;
			hiddenPiece = piece2;
		}
		else {
			hiddenPiece = piece1;
			activePiece = piece2;
		}
	}
}
