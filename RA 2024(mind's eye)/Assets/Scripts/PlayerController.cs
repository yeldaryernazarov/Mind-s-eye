using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    Spawner spawn;
    public float speed = 10;
    public float rotationSpeed = 10;
    public float horizontalInput;
    public float verticalInput;
    public  bool gameOver = false;
    public float trials;
    public float lastTrial; //thus after what trial game ends
    Vector3 originPos;
    void Start()
    {
        spawn = GameObject.FindGameObjectWithTag("spawner").GetComponent<Spawner>();
        originPos = gameObject.transform.position;
        transform.position=originPos;
        trials = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (trials==lastTrial){
            gameOver=true;
        }
        horizontalInput= Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward*Time.deltaTime*speed*verticalInput);
        transform.Rotate(Vector3.up*Time.deltaTime*rotationSpeed*horizontalInput);
    }
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Finish")){
            Destroy(other.gameObject);
            transform.position = originPos;
            transform.rotation = Quaternion.identity;
            scoreAdd.instance.AddPoint();
            spawn.SpawnObject();
            trials += 1;
        }
    }
    public bool GetGameOver(){
        return gameOver;
    }
}
