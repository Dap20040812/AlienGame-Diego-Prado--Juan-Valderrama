using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject[] bulletArray;
    [SerializeField] float nextFire;

    float minX, maxX, minY, maxY, tamX,tamY,canFire;
    bool fireType;
    // Start is called before the first frame update
    void Start()
    {

        tamX = (GetComponent<SpriteRenderer>()).bounds.size.x;
        tamY = (GetComponent<SpriteRenderer>()).bounds.size.y;

        Vector2 esquinaSupDer = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
        maxX = esquinaSupDer.x - tamX / 2;
        maxY = esquinaSupDer.y - tamY / 2;

        Vector2 esquinaInfIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        minX = esquinaInfIzq.x + tamX / 2;
        minY = esquinaInfIzq.y + 5;

   

    }

    // Update is called once per frame
    void Update()
    {

        Movement();
        Fire();

    }
    void Movement()
    {
        float movH = Input.GetAxis("Horizontal");
        float movV = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(movH * Time.deltaTime * speed, movV * Time.deltaTime * speed));

        float newX = Mathf.Clamp(transform.position.x, minX, maxX);
        float newY = Mathf.Clamp(transform.position.y, minY, maxY);

        transform.position = new Vector2(newX, newY);
    }
     
    void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= canFire)
        {
            Instantiate(bullet, transform.position - new Vector3(0, tamY / 2, 0), transform.rotation);

            if (fireType == false)
            {
                canFire = Time.time + nextFire;
            }
            else
            {
                canFire = Time.time + nextFire + 5;
            }
        }

        if (Input.GetKeyDown(KeyCode.Z) && fireType == true)
        {
            fireType = false;
            bullet = bulletArray[0];

        }
        else if (Input.GetKeyDown(KeyCode.Z) && fireType == false)
        {
            fireType = true;
            bullet = bulletArray[1];
        }

    }

}
