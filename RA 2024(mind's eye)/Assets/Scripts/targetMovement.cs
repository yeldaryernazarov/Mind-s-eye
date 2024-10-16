using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    [SerializeField] Spawner a;
    public float speed;
    public float radius;
    public float visibleDelay = 2;

    private float angle;
    private float direction;
    
    void Awake()
    {
        a = GameObject.FindGameObjectWithTag("spawner").GetComponent<Spawner>();
    }

    // Update is called once per frame
    void Start(){
        angle = a.AngleGen();
        direction = a.RotGen();
        speed = a.SpeGen();
        StartCoroutine(TargetDisappear());
    }
    
    void Update()
    {
        radius = Mathf.Sqrt(Mathf.Pow((target.transform.position.x - 500),2)+Mathf.Pow((target.transform.position.z - 490),2));
        angle+=direction*speed*Time.deltaTime;
        float x = 500 + Mathf.Cos(angle) * radius;
        float y = target.position.y;
        float z = 490 + Mathf.Sin(angle) * radius;
        transform.position = new Vector3(x,y,z);
        
    }
    private IEnumerator TargetDisappear(){
        yield return new WaitForSeconds(visibleDelay);
        target.GetComponent<Renderer>().enabled = false;
    }
}
