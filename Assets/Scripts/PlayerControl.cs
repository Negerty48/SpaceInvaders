using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject PlayerBullet;
    [SerializeField] Transform Bullet01;
    [SerializeField] Transform Bullet02;
    [SerializeField] GameObject Explosion;
    [SerializeField] float speed = 5f; // Velocidad de movimiento
    private Rigidbody2D rb;
    private Vector2 movementInput;
    private Vector2 minBounds, maxBounds;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;

        // Definir límites de pantalla en unidades del mundo
        minBounds = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // Ajustes de margen para que la nave no salga de la pantalla
        float spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;
        float spriteHeight = GetComponent<SpriteRenderer>().bounds.size.y / 2;

        minBounds.x += spriteWidth;
        maxBounds.x -= spriteWidth;
        minBounds.y += spriteHeight;
        maxBounds.y -= spriteHeight;
    }

    void Update()
    {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

        if(Input.GetKeyDown("space")) {
            Shoot();
        }        
    }

    void FixedUpdate() {
        Move();
    }

    void Move()
    {
        Vector2 newPosition = rb.position + movementInput.normalized * speed * Time.fixedDeltaTime;
        newPosition.x = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minBounds.y, maxBounds.y);
        rb.MovePosition(newPosition);
    }

    void Shoot() {
        Instantiate(PlayerBullet, Bullet01.position, Quaternion.identity);
        Instantiate(PlayerBullet, Bullet02.position, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if((col.tag == "EnemyShipTag") || (col.tag == "EnemyBulletTag")) {
            PlayExplosion();
            Destroy(gameObject);
        }
    }

    void PlayExplosion() {
        GameObject explosion = Instantiate(Explosion, (Vector2)transform.position, Quaternion.identity);
    }
}