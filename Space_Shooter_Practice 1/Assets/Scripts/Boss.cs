using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] float _speed = 3.2f;
    [SerializeField] int _health = 150;
    [SerializeField] public int _damage = 5;
    int damageValue;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(-2.0f, 2.0f), 4.7f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        TranslatePosition();
    }

    void TranslatePosition()
    {
        //float travelDown = -1 * Time.deltaTime * _speed;
        //transform.Translate(new Vector3(0, travelDown, 0));

        transform.Translate(Vector3.down * Time.deltaTime * _speed);

        if (transform.position.y < -5.0)
        {
            transform.position = new Vector3(Random.Range(-2.0f, 2.0f), 4.7f, 0);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            //damage player
            DamagePlayer();
        }
        if (collision.transform.tag == "Shot")
        {
            damageValue = collision.GetComponent<PlayerShot>()._damage;
            DespawnShot();
            TakeDamage(damageValue);
        }

    }

    void TakeDamage(int damageValue)
    {
        _health -= damageValue;
        Debug.Log("Health: " + _health);

        int countEnemiesDead = GameObject.Find("Spawn Manager").GetComponent<EnemySpawnController>().enemiesDestroyed;

        if (_health <= 0)
        {
            GameObject.Find("Spawn Manager").GetComponent<EnemySpawnController>().enemiesDestroyed++;
            Debug.Log("Enemies Destroyed: " + countEnemiesDead);
            Destroy(gameObject);
        }
    }

    void DamagePlayer()
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<Player>()._lives -= 1;
        Debug.Log("Player Lives: " + player.GetComponent<Player>()._lives);
        if (player.GetComponent<Player>()._lives <= 0)
        {
            Destroy(player);
        }
    }

    void DespawnShot()
    {
        Destroy(GameObject.FindWithTag("Shot"));
    }

}