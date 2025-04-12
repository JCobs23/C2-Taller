using Unity.Collections;
using UnityEngine;

public class Grunt2 : MonoBehaviour
{
    public GameObject Player;
    private float LastShoot;
    public GameObject BulletPrefab;
    private void Update()
    {
        Vector3 direction = Player.transform.position - transform.position;
        if (direction.x > 0.0f) transform.localScale = new Vector3(7.0f, 7.0f, 7.0f);
        else transform.localScale = new Vector3(-7.0f, 7.0f, 7.0f);

        float distance = Mathf.Abs(Player.transform.position.x - transform.position.x);

        if (distance < 5.0f && Time.time > LastShoot + 0.5f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }


    private void Shoot()
    {
        Vector2 direction;

        if (transform.localScale.x > 0)
            direction = Vector2.right;
        else
            direction = Vector2.left;

        GameObject bullet = Instantiate(BulletPrefab, transform.position + (Vector3)(direction * 0.5f), Quaternion.identity);
        bullet.GetComponent<BulletScrip>().SetDirection(direction);
        bullet.GetComponent<BulletScrip>().SetShooterTag("Enemy");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Dañar al jugador al contacto 
        if (collision.CompareTag("Player"))
        {
            MovemPlayer player = collision.GetComponent<MovemPlayer>();
            if (player != null)
            {
                player.RecibirDaño(1);
            }
        }
    }
}