using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunckGenerator : MonoBehaviour
{
    public Camera mainCamera;
    public Transform sphere;
    public List<Chunck> chunckPrefabList = new List<Chunck>(3);
    [SerializeField]private List<Chunck> spawnChunckList= new List<Chunck>(); 
    public Chunck curChunck;
    public Vector3 offestInstance = new Vector3(0.5f,0,0);
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        spawnChunckList.Add(curChunck);

    }

    // Update is called once per frame
    void Update()
    {
        if (sphere.position.x > spawnChunckList[spawnChunckList.Count - 1].transform.position.x)
        {
            ChunckInstance();
        }
        if (spawnChunckList[0]==null)
        {
            spawnChunckList.RemoveAt(0);
        }
    }

     public void ChunckInstance()
    {
        Debug.Log("Chunck instance");
        Chunck  newChunck = Instantiate(chunckPrefabList[Random.Range(0,chunckPrefabList.Count-1)],transform.position,transform.rotation);
        newChunck.transform.position = curChunck.endChunck.transform.position+offestInstance;
        newChunck.downGroup.transform.position = new Vector3(newChunck.transform.position.x, mainCamera.ViewportToWorldPoint(new Vector2(0.5f,0)).y, 0);
        newChunck.upGroup.transform.position = new Vector3(newChunck.transform.position.x, mainCamera.ViewportToWorldPoint(new Vector2(0.5f, 1)).y, 0);
        newChunck.destroyDistance+= mainCamera.ViewportToWorldPoint(new Vector2(0, 0.5f));
        spawnChunckList.Add(newChunck);
        curChunck = newChunck;
    }


}
