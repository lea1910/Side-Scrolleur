using UnityEngine;

public class EnemyPtrol : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;// point a->b

    private Transform target;
    private int desPoint = 0;


    // Start is called before the first frame update
    void Start()
    {
        target = waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        // si l'ennemie est quasiment arrive à sa destination
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            desPoint = (desPoint + 1) % waypoints.Length; //% recupere le rest d'une division et renvoie le prochain point 
            target = waypoints[desPoint];
        }
    }
}