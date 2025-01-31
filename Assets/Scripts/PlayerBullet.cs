using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float speed = 8f; // Velocidad ajustable desde el Inspector
    private float maxY;

    void Start() {
        maxY = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    }

    void Update()
    {
        // Mover la bala hacia arriba
        transform.position += Vector3.up * speed * Time.deltaTime;

        // Si la bala sale de la pantalla, destruirla
        if (transform.position.y > maxY){
            Debug.Log("Bala destruida en Y: " + transform.position.y); // Depuración
            Destroy(gameObject);
        }
    }
}