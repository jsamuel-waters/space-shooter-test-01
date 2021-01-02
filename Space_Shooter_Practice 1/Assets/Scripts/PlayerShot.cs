using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    [SerializeField] float _speed = 3.3f;
    [SerializeField] public int _damage = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        //float travelUp = transform.position.y + (Time.deltaTime * _shotSpeed);
        //transform.position = new Vector3(transform.position.x, travelUp, 0);

        transform.Translate(Vector3.up * Time.deltaTime * _speed);


        if (transform.position.y > 5)
        {
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter2D()
    {
        Destroy(gameObject);
    }
}
