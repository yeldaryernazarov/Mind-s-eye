using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject plane;
    public bool spawnIng=true;
    public float spawnTime;
    public float spawnDelay;
    public float angle;
    public float rotation = -1;
    public float speed = 1;
    public AudioSource src;
    public AudioClip sfx;
    void Update()
    {
        if (spawnIng == true){
            SpawnObject();
            spawnIng = false;
        }
    }
    
    // Update is called once per frame
    public void SpawnObject()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(450,550), 0.1f, Random.Range(504,550));
        Instantiate(plane, randomSpawnPosition, Quaternion.identity);
        src.clip = sfx;
        src.Play();
        angle = Random.Range(20, 160);
        speed = Random.Range(100, 300);
        speed = speed/1000;
        if( Random.Range(0, 2) == 0 )
            rotation= -1;
        else 
            rotation = 1;

    }
    public float AngleGen(){
        return angle;
    }
    public float RotGen(){
        return rotation;
    }
    public float SpeGen(){
        return speed;
    }

}
