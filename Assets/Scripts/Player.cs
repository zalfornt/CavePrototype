using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private float speed = 10f;
    public GameObject bullet;
    private Rigidbody2D rb;

    private Vector2 latestDir;

    public float health = 100f;
    

    // Use this for initialization
    void Start () {
        latestDir = Vector2.up;
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        Shoot();
    }

    public void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            var newBullet = Instantiate(bullet, transform.position,Quaternion.identity);
            newBullet.GetComponent<Bullet>().MoveYouBullet(latestDir);
        }
    }
    public void Move()
    {
        float yMove = Input.GetAxisRaw("Vertical");
        float xMove = Input.GetAxisRaw("Horizontal");
        var movement = new Vector2(xMove, yMove);

        if(movement != Vector2.zero)
        {
            latestDir = movement;
        }

        transform.Translate(movement * speed * Time.deltaTime);

    }
}
