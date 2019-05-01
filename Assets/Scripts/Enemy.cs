using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


    public Transform player;
    public GameObject rangedWeapon;
    public GameObject enemyBullet;

    public float speed = 2;
    public float health = 50f;
    public float cooldownTime = 2f;
    public float cooldownTimer = 0f;
    public float attackDistance;

    public int enemyType; // 1 = melle, 2 = ranged

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector2.Distance(player.position, transform.position) >= attackDistance)
        {
            Move();
        }
        else
        {
            Attack();
        }
        cooldownTimer -= Time.deltaTime;
        CheckDeath();
	}

    public void Move()
    {
       transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    public void Attack()
    {
        if (cooldownTimer <= 0)
        {
            Debug.Log("attack");
            switch (enemyType)
            {
                case 1:
                    break;
                case 2:
                    var newBullet = Instantiate(enemyBullet, transform.position, Quaternion.identity);
                    break;
            }
            cooldownTimer = cooldownTime;
        }
    }

    private void CheckDeath()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
