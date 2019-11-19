using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSwordDamage2 : MonoBehaviour {

    public PlayerController player_damaged;
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            player_damaged.lifeP -= 20;
            gameObject.SetActive(false);
        }
    }

}
