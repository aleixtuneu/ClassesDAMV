using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _rb.linearVelocity = new Vector2(0, 5);
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
