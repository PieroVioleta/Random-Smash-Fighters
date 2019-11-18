using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBullet : MonoBehaviour {
    public PlayerController player;

    void OnCollisionStay2D(Collision2D col) {
        if (col.gameObject.CompareTag("Player")) player.lifeP -= 10;
        player.bullet_available = true;
        transform.position = new Vector3(9, 4, transform.position.z);
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
    void OnCollisionExit2D(Collision2D col) {
        player.bullet_available = false;
        player.bullet_counter = player.bullet_counter - 1;
    }

}
