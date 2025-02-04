using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Vector2 _direction;
    private bool isReady = false;

    public void SetDirection(Vector2 direction) 
    {
        _direction = direction.normalized;
        isReady = true;
    }

    void Update()
    {
        if (isReady)
        {
            Vector2 position = (Vector2)transform.position;
            position += _direction * speed * Time.deltaTime;
            transform.position = position;

            Vector2 min = Camera.main.ViewportToWorldPoint(Vector2.zero);
            Vector2 max = Camera.main.ViewportToWorldPoint(Vector2.one);

            if (position.x < min.x || position.x > max.x || position.y < min.y || position.y > max.y)
            {
                Destroy(gameObject);
            }
        }
    }
}