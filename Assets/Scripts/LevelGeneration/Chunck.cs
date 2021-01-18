using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunck : MonoBehaviour
{
    public float chunckSpeed;
    public Transform startChunck;
    public Transform endChunck;
    public GameObject downGroup;
    public GameObject upGroup;
    public Vector3 destroyDistance= new Vector3(-30,0,0);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * chunckSpeed * Time.deltaTime);
        if (transform.position.x<destroyDistance.x)
        {
            DestroyChunck();
        }   
    }

    public void DestroyChunck()
    {
        Destroy(gameObject);
    }
}
