using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bots : MonoBehaviour 
{
    [SerializeField] float speed;
    [SerializeField] bool direction;
    [SerializeField] int hearts;
    [SerializeField] GameObject corCompleto;
    [SerializeField] Sprite vacio;
    private GameObject[] corazones1;
    private GameObject objectToFind;
    private float space;
    private int vidas;
    private SpriteRenderer spriteRenderer;


    float minX, maxX;
        // Start is called before the first frame update
        void Start()        
        {
            space = (hearts/2)-hearts;
            vidas = hearts;
            corazones1 = new GameObject[hearts];
            

           objectToFind = gameObject;
          
            float tamX = GetComponent<SpriteRenderer>().bounds.size.x;

            Vector2 esquinaSupDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
            maxX = esquinaSupDer.x - tamX;

            Vector2 esquinaInfIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            minX = esquinaInfIzq.x + tamX;

        for (int i = 0; i < hearts; i++) {

            if (hearts % 2 == 0)
            {
                corazones1[i] = Instantiate(corCompleto, transform.position - new Vector3(-space - (0.5f), -1, 0), Quaternion.identity);

            }
            else
            {
                corazones1[i] = Instantiate(corCompleto, transform.position - new Vector3(-space - 1, -1, 0), Quaternion.identity);

            }
            corazones1[i].transform.parent = objectToFind.transform;
            space += 1;
            
        }

        

        }

        // Update is called once per frame
        void Update()
        {
            if (direction)
                transform.Translate(new Vector2(speed * Time.deltaTime, 0));
            else
                transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
            if (transform.position.x >= maxX)
                direction = false;
            else if (transform.position.x <= minX)
                direction = true;
           


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fire"))
        {
            spriteRenderer = corazones1[vidas - 1].GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = vacio;
            vidas--;

            if (vidas == 0)
            {
                Destroy(this.gameObject);

            }


        }
        else if(collision.gameObject.CompareTag("NanoBullet"))
        {
            for (int i = 0; i < 2; i++)
            {
                if (vidas == 0)
                {
                    Destroy(this.gameObject);
                    break;
                }
                spriteRenderer = corazones1[vidas - 1].GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = vacio;
                vidas--;
                if (vidas == 0)
                {
                    Destroy(this.gameObject);
                    break;
                }

            } 
           

            
        }

    }
}
