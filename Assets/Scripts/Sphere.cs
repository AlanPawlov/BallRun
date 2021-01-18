using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class Sphere : MonoBehaviour
{

    public GameManager gameManager;
    private Rigidbody2D myRigidbody;
    [SerializeField] private bool useGravity;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.anyKeyDown)
        {
            myRigidbody.gravityScale *= -1;
        }  
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name=="DeathZone")
        {
            gameManager.EndGame();
        }
    }
}
