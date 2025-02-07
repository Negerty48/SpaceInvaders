using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField] private GameObject Explosion;
    [SerializeField] private float speed = 2f;

    void Update()
    {
        // Movimiento hacia abajo usando Vector2
        Vector2 movement = Vector2.down * speed * Time.deltaTime;
        transform.position = (Vector2)transform.position + movement;

        // Verificación de límites de pantalla
        Vector2 min = Camera.main.ViewportToWorldPoint(Vector2.zero);
        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if((col.tag == "PlayerShipTag") || (col.tag == "PlayerBulletTag")) {
            PlayExplosion();
            Destroy(gameObject);
        }
    }

    void PlayExplosion() {
        GameObject explosion = Instantiate(Explosion, (Vector2)transform.position, Quaternion.identity);
    }
}