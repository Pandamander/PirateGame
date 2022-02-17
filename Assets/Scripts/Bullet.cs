using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public float speed = 10f;
    public Rigidbody2D rb;
    [SerializeField] public float timeAlive = 3f;
    private float timeUntilDeath;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void Update()
    {
        timeUntilDeath += Time.deltaTime;
        if (timeUntilDeath > timeAlive)
        {
            DestroyBullet();
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
