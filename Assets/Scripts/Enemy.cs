using UnityEngine;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    public Transform[] _enemyLimitPositionsX;
    [SerializeField] private Transform _enemyPositionX;
    private Rigidbody2D _enemyRigidbody;
    public Spawner spawner; 

    private void OnCollisionEnter2D(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            GameOver();
        } 
        else if (collision.gameObject.layer == 8)
        {

        }
    }
    private void Awake()
    {
        _enemyRigidbody = GetComponent<Rigidbody2D>();
        _enemyPositionX = GetComponent<Transform>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        // Moure d'esquerra a dreta
        if (_enemyPositionX.position.x <= _enemyLimitPositionsX[0].position.x)
        {
            _enemyRigidbody.linearVelocity = new Vector2(2, 0);
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.10f, transform.position.z); // Baixar
        }
        // Moure de dreta a esquerra
        if (_enemyPositionX.position.x >= _enemyLimitPositionsX[1].position.x)
        {
            _enemyRigidbody.linearVelocity = new Vector2(-2, 0);
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.10f, transform.position.z); // Baixar
        }
    }

    public void OnMove()
    {
        // Velocitat inicial
        _enemyRigidbody.linearVelocity = new Vector2(2, 0);
    }

    

    public void GameOver()
    {

    }
    /*
    public void OnTriggerEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject, .1f);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject, .1f);
        }
    } */
}
