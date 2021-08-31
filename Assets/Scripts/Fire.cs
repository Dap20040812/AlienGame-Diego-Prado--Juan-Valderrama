using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] float speed;
    private int power;

    // Start is called before the first frame update
    void Start()
    {
        power = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (this.gameObject.CompareTag("NanoBullet"))
        {
             
           if (power == 0)
           {
                    Destroy(this.gameObject);
           }
             power--;
           
            
        }
        else if (!collision.gameObject.CompareTag("Fire"))
        {
            Destroy(this.gameObject);
        }
       
        

    }
}
