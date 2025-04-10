using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gruentscrip : MonoBehaviour
{
    public GameObject Player;
    public GameObject BulletPrefab;
    private float LastShoot;
    private Vector3 originalScale;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    private void Update()
    {
        Vector3 direction = Player.transform.position - transform.position;


        if (direction.x >= 0.0f)
            transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        else
            transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);

        float distance = Mathf.Abs(Player.transform.position.x - transform.position.x);

        if (distance < 1.0f && Time.time > LastShoot + 1.0f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }
    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);    
    }

}
