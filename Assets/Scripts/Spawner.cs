using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float timer;
    private float next;
    private Bounds _cameraBounds;
    private float height;
    private float width;
    private float interval;

    private int wave;
    private int waveTotalEnemies;
    private int enemyCount;
    private int kills;

    private SpriteRenderer _enemySpriteRenderer;

    public Enemy enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        height = Camera.main.orthographicSize;
        width = height * Camera.main.aspect;
        timer = 0F;
        interval = 5F;
        next = 2F;
	_enemySpriteRenderer = enemyPrefab.GetComponent<SpriteRenderer>();
        wave = 1;
        waveTotalEnemies = 2;
        enemyCount = 0;
        kills = 0;
        
    }

    // Update is called once per frame
    public void Update()
    {
        // Debug.Log("morte:" + kills);
        timer += Time.deltaTime;
        if( enemyCount < waveTotalEnemies ){
            if( timer >= next ){
                SpawnEnemy();
                enemyCount++;
                timer = 0F;
                next = Random.Range(0.6F,1.2F);
            }
            Debug.Log("First if");
        }
        else if( kills == waveTotalEnemies ){

            if( timer >= interval ){
                NextWave();
                Debug.Log("Yes");
            }

            else
                Debug.Log("Not");
        }
        Debug.Log($"kills:{kills}");
    }

    void NextWave(){
        wave++;
        enemyCount = 0;
        waveTotalEnemies += 10;
        // kills = 0;
    }

    void SpawnEnemy(){
        var spriteHeight = _enemySpriteRenderer.sprite.bounds.extents.y;
	    var spriteWidth = _enemySpriteRenderer.sprite.bounds.extents.x;
        Instantiate(enemyPrefab, new Vector3(Random.Range(-width+spriteWidth,width-spriteWidth),height-spriteHeight/2f), Quaternion.identity);
    }

    public void CountKill(){
        kills++;
        Debug.Log("CountKIll:"+kills);
        if( kills >= waveTotalEnemies )
            timer = 0F;
    }
}
