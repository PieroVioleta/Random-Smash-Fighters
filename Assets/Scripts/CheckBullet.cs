using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBullet : MonoBehaviour {
    public PlayerController player;
    public PlayerControllerTwo player_damaged; //object who is damaged
    private Rigidbody2D rb2d;
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void OnCollisionStay2D(Collision2D col) {

        if (col.gameObject.CompareTag("Player")) player_damaged.lifeP -= 10;
        rb2d.velocity = new Vector2(0, 0);
        player.bullet_available = true;
        transform.position = new Vector3(9, 4, transform.position.z);
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
    void OnCollisionExit2D(Collision2D col) {
        player.bullet_available = false;
        player.bullet_counter = player.bullet_counter - 1;
    }

}
