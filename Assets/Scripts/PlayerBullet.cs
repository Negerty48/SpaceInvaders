using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float speed = 8f; // Velocidad ajustable desde el Inspector
    private float maxY;

    void Start() {
        maxY = Camera.main.ViewportToWorldPoint(Vector2.up).y;
    }

    void Update()
    {
        // Mover la bala hacia arriba usando Vector2
        Vector2 position = (Vector2)transform.position;
        position += Vector2.up * speed * Time.deltaTime;
        transform.position = position;

        // Si la bala sale de la pantalla, destruirla
        if (position.y > maxY) {            
            Destroy(gameObject);
        }
    }
}