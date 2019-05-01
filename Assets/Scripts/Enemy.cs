using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


    public Transform player;

    public GameObject rangedWeapon;
    public GameObject enemyBullet;
    public GameObject gameController;

    private Vector3 difference;
    private Vector3 oriPosAttack;

    public float speed = 2;
    public float health = 50f;
    public float cooldownTime = 2f;
    public float cooldownTimer = 0f;
    public float attackDistance;

    public int enemyType; // 1 = melle, 2 = ranged

    public bool isAttacking;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gameController = GameObject.FindWithTag("GameController");
        isAttacking = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (isAttacking)
        {
            MeleeAttackMovement();
        }
        else
        {
            if (Vector2.Distance(player.position, transform.position) >= attackDistance)
            {
                Move();
            }
            else
            {
                Attack();
            }
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
            //Debug.Log("attack");
            switch (enemyType)
            {
                case 1:
                    MeleeAttack();
                    break;
                case 2:
                    var newBullet = Instantiate(enemyBullet, transform.position, Quaternion.identity);
                    cooldownTimer = cooldownTime;
                    break;
            }
        }
    }

    private void MeleeAttack()
    {
        Debug.Log("melee attack start");
        oriPosAttack = transform.position;
        difference = oriPosAttack - player.position;
        isAttacking = true;
    }

    private void MeleeAttackMovement()
    {
        Debug.Log("melee attack move");
        Vector2.MoveTowards(transform.position, player.position, speed*2);
        isAttacking = false;
        cooldownTimer = cooldownTime;
    }

    private void CheckDeath()
    {
        if(health <= 0)
        {
            player.GetComponent<Player>().killCount += 1;
            gameController.GetComponent<GameController>().enemyNum--;
            Destroy(gameObject);
        }
    }

    public void ChangeColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.magenta;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && isAttacking)
        {
            Debug.Log("melee attack hit");
            player.GetComponent<Player>().health -= 5;
            Vector2.MoveTowards(transform.position, oriPosAttack, speed*2);
        }
    }
}
