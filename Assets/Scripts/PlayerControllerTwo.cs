using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerTwo : MonoBehaviour
{

    // Use this for initialization
    public float maxSpeed = 5f;
    public float speed = 200f;
    public bool grounded;
    private Rigidbody2D rb2d;
    private Animator anim;
    public float jumpPower = 6.5f;
    private bool jump;
    public bool sAttack = false;
    public bool lAttack = false;
    public GameObject aim;
    //public GameObject ins_bullet;
    public float bulletSpeed = 0f;
    //private Rigidbody2D rb_ins_bullet;
    //public bool bullet_available = true;
    public int countPower1 = 3;
    public bool health = false;
   /* public Text HealthPowerText;
    public Text BulletCounterText;
    public Text life;*/
    public int lifeP;
    //public int bullet_counter = 20;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
       //rb_ins_bullet = ins_bullet.GetComponent<Rigidbody2D>();
        /*HealthPowerText.text = "Health Power: 2";
        BulletCounterText.text = "Bullets Available: 10";
        life.text = "Health: " + lifeP.ToString() + "%";*/
    }

    // Update is called once per frame
    void Update()
    {
        //ins_bullet.transform.localScale = transform.localScale;
        anim.SetFloat("Speed_X_abs", Mathf.Abs(rb2d.velocity.x));
        anim.SetFloat("Speed_Y", rb2d.velocity.y);
        anim.SetBool("Grounded", grounded);
        anim.SetBool("SAttack", sAttack);
        anim.SetBool("LAttack", lAttack);
        anim.SetBool("HealthFlag", health);
        anim.SetInteger("CountPower1", countPower1);

        if (Input.GetButtonDown("PS4_X_2") && grounded)
        {
            jump = true;
        }
        sAttack = false;
        if (Input.GetButtonDown("PS4_L2_2"))
        {
            sAttack = true;
        }
        lAttack = false;
        /*if (Input.GetButtonDown("PS4_R2_2") && grounded && bullet_available && bullet_counter > 0)
        {
            lAttack = true;
            bullet_available = false;
        }*/
        health = false;
        if (Input.GetButtonDown("PS4_triangle_2") && countPower1 > 0)
        {
            health = true;
            countPower1--;
           /* if (countPower1 > 0) HealthPowerText.text = "Health Power: " + (countPower1 - 1).ToString();*/
        }
        //if (bullet_counter >= 0 && bullet_counter % 2 == 0) BulletCounterText.text = "Bullets Available: " + (bullet_counter / 2).ToString();
        /*life.text = "Health: " + lifeP.ToString() + "%";*/
    }

    void FixedUpdate()
    {
        Vector3 fixedVelocity = rb2d.velocity;
        fixedVelocity.x *= .55f;
        if (grounded) rb2d.velocity = fixedVelocity;
        float h = Input.GetAxis("Horizontal_2");
        if (h > 0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (h < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        rb2d.AddForce(Vector2.right * speed * h);

        float limitSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitSpeed, rb2d.velocity.y);

        if (jump)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0f);
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }
        if (lAttack)
        {
            //Invoke("CreateBullet", 0.45f);
        }

    }
    /*void CreateBullet()
    {
        if (bullet_available)
        {
            rb_ins_bullet.velocity = new Vector2(0f, rb_ins_bullet.velocity.y);   //implementar bullet available
            ins_bullet.transform.position = aim.transform.position;
            float direction = transform.localScale.x;
            rb_ins_bullet.AddForce(Vector2.right * bulletSpeed * direction, ForceMode2D.Impulse);
            lAttack = false;
        }
    }*/
}