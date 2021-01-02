using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _playerSpeed = 5.0f;
    [SerializeField] GameObject _laserPrefab;
    [SerializeField] float _shotOffset = 0.25f;
    [SerializeField] float _fireRate = 0.5f;
    [SerializeField] public int _lives = 3;
    [SerializeField] GameObject playerShots;


    int shotCount;
    int shotLimit = 3;
    float _canFire = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
       // _laserPrefab = GameObject.FindWithTag("Shot");
    }

    // Update is called once per frame
    void Update()
    {
        shotCount = playerShots.transform.childCount;
        PlayerMove();

        //if (Input.GetKeyDown(KeyCode.Space) && (Time.time > _canFire))
        if (Input.GetKeyDown(KeyCode.Space) && (shotCount < shotLimit))
        {
            FireLaser();
        }

        if (_lives <= 0)
        {
            Destroy(gameObject);
        }
    }

    void PlayerMove()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * _playerSpeed);

        // wraps player movement horizontally
        if (transform.position.x >= 2.5f)
        {
            transform.position = new Vector3(-2.5f, transform.position.y, 0);
        } else if (transform.position.x <= -2.5f)
        {
            transform.position = new Vector3(2.5f, transform.position.y, 0);
        }

        // clamp player movement vertically

        //if (transform.position.y >= 3.0f)
        //{
        //    transform.position = new Vector3(transform.position.x, 3.0f, 0);
        //}
        //else if (transform.position.y <= -4.5f)
        //{
        //    transform.position = new Vector3(transform.position.x, -4.5f, 0);
        //}

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.5f, 3.0f), 0);
    }

    void FireLaser()
    {
        Vector3 _positionOffset = new Vector3(transform.position.x, transform.position.y + _shotOffset , 0) ;
        
        //_canFire = Time.time + _fireRate;
        GameObject newShot = Instantiate(_laserPrefab, _positionOffset, Quaternion.identity);
        newShot.transform.parent = playerShots.transform;
    }
}
