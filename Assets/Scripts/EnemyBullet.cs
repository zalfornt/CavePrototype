using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Transform player;
    public Vector2 CurrDir { get; set; }
    private Vector3 latestPlayerPos; 
    private Vector3 oriPos;
    public float speed;
    private float range = 5f;

    private void Start()
    {
        oriPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        latestPlayerPos = new Vector3(player.position.x, player.position.y, player.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        CheckDestroy();
        Move();
    }
    public void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, latestPlayerPos, speed * Time.deltaTime);       
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
        Debug.Log(transform.position);
        Debug.Log(latestPlayerPos);
        if (transform.position == latestPlayerPos)
        {
            Debug.Log("gae");
            Destroy(gameObject);
        }
    }
}