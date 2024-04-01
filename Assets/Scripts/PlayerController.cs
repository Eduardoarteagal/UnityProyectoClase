using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float playerJumpForce = 20f;
    public float playerSpeed = 5f;
    public Sprite[] mySprites;
    private int index = 0;

    private Rigidbody2D myrigidbody2D;
    private SpriteRenderer mySpriteRenderer;
    public GameObject Laser;
    public GameManager myGameManager;

    public int Health = 5;
    
    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(WalkCoRutine());
        myGameManager = FindObjectOfType<GameManager>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myrigidbody2D.velocity = new Vector2(myrigidbody2D.velocity.x, playerJumpForce);
        }
        myrigidbody2D.velocity = new Vector2(playerSpeed, myrigidbody2D.velocity.y);
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(Laser, transform.position, Quaternion.identity);
        }
    }

    IEnumerator WalkCoRutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            if (index < mySprites.Length)
            {
                mySpriteRenderer.sprite = mySprites[index];
                index++;
            }else{
                index = 0;            
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ItemGood"))
        {
            Destroy(collision.gameObject);
            myGameManager.AddScore();
        }
        else if (collision.CompareTag("ItemBad"))
        {
            if(Health <= 0)
            {
                Destroy(collision.gameObject);
                PlayerDeath();
            }else
            {
                Health--;
            }
            
        }
        else if (collision.CompareTag("DZone"))
        {
            PlayerDeath();
        }
    }

    void PlayerDeath()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
