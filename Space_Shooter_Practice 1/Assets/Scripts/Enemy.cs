using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _speed = 3.2f;
    [SerializeField] int _health = 15;
    [SerializeField] public int _damage = 5;


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
        Debug.Log("Hit: " + collision.transform.name);
        if (collision.transform.tag == "Player")
        {
            //damage player
            DamagePlayer();
            Destroy(gameObject);
        }
        if (collision.transform.tag == "Shot")
        {
            int damageValue = collision.GetComponent<PlayerShot>()._damage;         
            TakeDamage(damageValue);
        }

    }

    void TakeDamage(int damageValue)
    {
        _health -= damageValue;

        int countEnemiesDead = GameObject.Find("Spawn Manager").GetComponent<EnemySpawnController>().enemiesDestroyed;

        if (_health <= 0)
        {
            GameObject.Find("Spawn Manager").GetComponent<EnemySpawnController>().enemiesDestroyed += 1;
            Debug.Log("Enemies Destroyed: " + countEnemiesDead);
            Destroy(gameObject);
        }
    }

    void DamagePlayer()
    {
        GameObject.FindWithTag("Player").GetComponent<Player>()._lives -= 1;
        Debug.Log("Player Lives: " + GameObject.FindWithTag("Player").GetComponent<Player>()._lives);
    }






}
