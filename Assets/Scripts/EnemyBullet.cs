using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Transform player;
    public Vector2 CurrDir { get; set; }
    private Vector2 latestPlayerPos; 
    private Vector3 oriPos;
    public float speed;
    private float range = 5f;

    private void Start()
    {
        oriPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        latestPlayerPos = new Vector2(player.position.x, player.position.y);
    }
    // Update is called once per frame
    void Update()
    {
        CheckDestroy();
        Move();
    }
    public void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, latestPlayerPos, speed * Time.deltaTime);       
    }
    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Player"))
        {
            c.gameObject.GetComponent<Player>().health -= 10;
            Destroy(gameObject);
        }
    }
    private void CheckDestroy()
    {
        if (Vector3.Distance(oriPos, transform.position) != range)
        {
            Debug.Log("gae");
            Destroy(gameObject,2f);
        }
    }
}