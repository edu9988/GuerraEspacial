using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Spaceship spaceship;
    private float timer;
    private float next;
    private Bounds _cameraBounds;
    private float height;
    private float width;
    private float interval;
    private float multiplier;

    private int wave;
    private int waveTotalEnemies;
    private int enemyCount;
    private int kills;
    private int score;

    int posX = 10;
	float posY = Screen.height - 25;

    public GUIStyle HUDSkin;

    private SpriteRenderer _enemySpriteRenderer;

    public Enemy enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        height = Camera.main.orthographicSize;
        width = height * Camera.main.aspect;
        timer = 0F;
        interval = 5F;
        next = 4F;
	    _enemySpriteRenderer = enemyPrefab.GetComponent<SpriteRenderer>();
        wave = 1;
        waveTotalEnemies = 10;
        enemyCount = 0;
        kills = 0;
        multiplier = 1F;


        HUDSkin.normal.textColor = Color.yellow;
        HUDSkin.fontStyle = FontStyle.BoldAndItalic;
        HUDSkin.fontSize = 16;
        
    }

    // Update is called once per frame
    public void Update()
    {
        
        timer += Time.deltaTime;
        if( enemyCount < waveTotalEnemies ){
            if( timer >= next ){
                SpawnEnemy();
                enemyCount++;
                timer = 0F;
                next = multiplier*Random.Range(0.6F,1.2F);
            }
        }
        else if( kills == waveTotalEnemies ){

            if( timer >= interval ){
                NextWave();
            }
        }
    }

    void OnGUI(){
        GUI.Label(new Rect(posX , 10, 100, 50), "Wave " + wave.ToString(), HUDSkin);
    }

    void NextWave(){
        spaceship.Heal();
        wave++;
        enemyCount = 0;
        waveTotalEnemies += 10;
        kills = 0;
        multiplier -= 0.05f;
        if( multiplier <= 0.2f )
            multiplier = 0.2f;
    }

    void SpawnEnemy(){
        var spriteHeight = _enemySpriteRenderer.sprite.bounds.extents.y;
	    var spriteWidth = _enemySpriteRenderer.sprite.bounds.extents.x;
        Instantiate(enemyPrefab, new Vector3(Random.Range(-width+spriteWidth,width-spriteWidth),height-spriteHeight/2f), Quaternion.identity);
    }

    public void CountKill(){
        kills++;
        score+=10*wave;
        if( kills >= waveTotalEnemies )
            timer = 0F;
    }

    public int GetScore(){
        return score;
    }
}
