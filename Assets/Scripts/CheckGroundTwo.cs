using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGroundTwo : MonoBehaviour {

    private PlayerControllerTwo player; 
	// Use this for initialization
	void Start () {
        player = GetComponentInParent<PlayerControllerTwo>();
	}
	   
    void OnCollisionStay2D(Collision2D col) {
        if(col.gameObject.CompareTag("Ground")) player.grounded = true;
    }
    void OnCollisionExit2D(Collision2D col) {
        if(col.gameObject.CompareTag("Ground")) player.grounded = false;
    }
}
