using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class GhostAI : MonoBehaviour
{

    //for patrolling
    public Transform[] waypoints;
    public float StandingHere = 0f;//I already stand here for how long?
    public float speed = 2f;
    public bool patrolling = true;
    public float standForAwhile = 5f;//how long should I lazy here?
    public PlayerHealth playerHP;
    int currentPatrolpointIndex = 0;



    //for path-finding
    private Path path;
    private int currentWaypoint = 0;//number of points on the path
    private bool reachedEndOfPath = false;
    //public bool finding = false;//whether to start finding
    public float nextWaypointDistance = 0.1f;
    public Transform target;
    private Seeker seeker;

    //detection range
    public PolygonCollider2D LeftDetect;
    public SpriteRenderer leftS;
    public SpriteRenderer rightS;
    public PolygonCollider2D RightDetect;
    PolygonCollider2D faceAt;





    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        RightDetect.enabled =  false;
        faceAt = LeftDetect;
        InvokeRepeating("UpdatePath", 0f, 0.7f);//actually shuold be done in different way
    }

    // Update is called once per frame
    void Update()
    {
        if(patrolling){
            Patrol();
        }else{
            FollowPath();
        }
    }

    void Patrol(){
        if (Vector2.Distance(waypoints[currentPatrolpointIndex].transform.position, transform.position) < .1f)
            {
                currentPatrolpointIndex++;
                if (currentPatrolpointIndex >= waypoints.Length)
                {
                    currentPatrolpointIndex = 0;
                }
            }
            direction(waypoints[currentPatrolpointIndex].transform.position,transform.position);
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentPatrolpointIndex].transform.position, Time.deltaTime * speed);

    }


    private void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(transform.position, target.position, OnPathComplete);  
        }
    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
            //isPatrolling = false;
        }
    }

    void FollowPath()
    {
        if (path == null)
        {

            return;
        }

        if (currentWaypoint >= path.vectorPath.Count){//we reach the destination
        //aka all points on the path travelled
            reachedEndOfPath = true;
            // last_attack += Time.deltaTime;
            // if(last_attack >= attack_gap){
            //     ninja.damage();
            //     last_attack = 0;
            }else{
            reachedEndOfPath = false;
        
            //direction(path.vectorPath[currentWaypoint],transform.position);
            transform.position = Vector3.MoveTowards(transform.position,path.vectorPath[currentWaypoint], speed * Time.deltaTime);
            //rb.AddForce(force);

            float distance = Vector2.Distance(transform.position, path.vectorPath[currentWaypoint]);
            if (distance < nextWaypointDistance)
            {
                currentWaypoint++;
            }
        }

    }

    void direction(Vector3 PatrollPoint, Vector3 StandingPoint){
        float xDifference = PatrollPoint.x - StandingPoint.x;
        if(xDifference > 0.2 ){
            leftS.enabled = false;
            LeftDetect.enabled = false;
            rightS.enabled = true;
            rightS.enabled = true;           
        }else if(xDifference < -0.2){
            leftS.enabled = true;
            LeftDetect.enabled = true;
            rightS.enabled = false;
            rightS.enabled = false;
        }else{
            return;
        }
        
    }



}
