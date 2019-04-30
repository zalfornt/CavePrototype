using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Vector3 oriPos;

    public float speed;
    private Rigidbody2D rb;
    private bool isMoving;
    private Vector3 dir;

    private float range = 10f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

	// Use this for initialization
	void Start () {
        speed = 15f;
	}
	
	// Update is called once per frame
	void Update () {
        if (isMoving)
        {
            transform.Translate(dir * speed * Time.deltaTime);
        }
        CheckDestroy();
	}

    public void MoveYouBullet(Vector2 direction)
    {
        oriPos = transform.position;
        dir = direction;
        isMoving = true;
        //Debug.Log(dir);
    }

    private void CheckDestroy()
    {
        if(Vector3.Distance(oriPos,transform.position) >= range)
        {
            Destroy(gameObject);
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().health -= 10f;
        }
        Destroy(gameObject);
    }
}
