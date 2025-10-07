using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    private float timeToWait = 0;
    private float timeBetweenEnemies = 2f;
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform leftLimit, rightLimit;
    public Stack<GameObject> EnemiesStack = new Stack<GameObject>();

    private void Awake()
    {

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timeToWait)
        {
            if (EnemiesStack.Count > 0)
            {
                InstantiateEnemies();
            }
            else
            {
                Pop();
                Debug.Log("Reciclar");
            }
            timeToWait = Time.time + timeBetweenEnemies;
        }            
        
    }

    public void Push(GameObject go)
    {
        EnemiesStack.Push(go);
        go.SetActive(false);
    }

    public GameObject Pop()
    {
        GameObject go = EnemiesStack.Pop();
        go.SetActive(true);
        go.transform.position = transform.position;
        go.GetComponent<RigidBody2D>
        return go;
    }

    public void InstantiateEnemies()
    {
        GameObject enem = Instantiate(enemy, transform.position, Quaternion.identity);
        enem.GetComponent<Enemy>()._enemyLimitPositionsX[0] = leftLimit;
        enem.GetComponent<Enemy>()._enemyLimitPositionsX[1] = rightLimit;
        enem.GetComponent<Enemy>().OnMove();
        enem.GetComponent<Enemy>().spawner(this);
    }
}
