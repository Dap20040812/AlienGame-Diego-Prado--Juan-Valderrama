using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{
    [SerializeField] GameObject[] enemies;
    public int Enemycount;
    // Start is called before the first frame update

    private void Awake()
    {
        int managers = GameObject.FindObjectsOfType<GameManager>().Length;
        if (managers > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(this);
    }
    void Start()
    {
        SceneManager.sceneLoaded += CreateEnemies;
        Enemycount = enemies.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (Enemycount == 0)
        {
            Time.timeScale = 0;
            GameObject.Find("Canvas").SetActive(true);
        }    
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    void CreateEnemies(Scene scene, LoadSceneMode mode)
    {
        GameObject.Find("Canvas").SetActive(false);
        foreach (GameObject enemy in enemies)
        {
            float minx = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
            float maxx = Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).x;

            float X = Random.Range(minx, maxx);
            Instantiate(enemy, new Vector2(X, 1.2f), Quaternion.identity);
        }
    }

}
