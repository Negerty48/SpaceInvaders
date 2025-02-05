using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    [SerializeField] private GameObject EnemyBullet;

    void Start()
    {
        Invoke(nameof(FireEnemyBullet), 1f);
    }

    void FireEnemyBullet() 
    {
        GameObject playerShip = GameObject.Find("Player");

        if (playerShip != null)
        {
            GameObject bullet = Instantiate(EnemyBullet, transform.position, Quaternion.identity);
            Vector2 direction = playerShip.transform.position - bullet.transform.position;
            bullet.GetComponent<EnemyBullet>().SetDirection(direction);
        }
    }
}