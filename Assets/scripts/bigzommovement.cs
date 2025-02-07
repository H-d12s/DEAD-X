using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigzommovement : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField] float rotationspeed;
    private Rigidbody2D rb;
    private playerawareness playerawareness;
    private Vector2 targetdir;
    private float changedircooldown;
    [SerializeField]private float obstaclecheckcircleradius;
    [SerializeField]private float obstacleCheckDistance;
    [SerializeField]private LayerMask obstaclelayermask;
    [SerializeField] private RaycastHit2D [] obstaclecollision;
    private float obstacleAvoidanceCooldown;
    private Vector2 obstacleAvoidanceTargetdir;
       private  void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerawareness = GetComponent<playerawareness>();
        targetdir=transform.up;
        obstaclecollision = new RaycastHit2D[10];
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        UpdateTardir();
        RotateTowardsTarget();
        SetVelocity();
    }
    private void UpdateTardir()
   
    { Handlerandomtargetdir();
        HandlePlayerTargetdir();
        //HandleObstacles();
         KeepBossInBounds();
    
        
    }
    private void Handlerandomtargetdir()
    {
        changedircooldown -= Time.deltaTime;
        if(changedircooldown<=0)
        {
           float anglechange =Random.Range(-90f,90f);
           Quaternion rotation = Quaternion.AngleAxis(anglechange,transform.forward);
              targetdir = rotation * targetdir;
                changedircooldown = Random.Range(1f,2f);
        }
    }

    private void HandlePlayerTargetdir()
    {
        if(playerawareness.AwareOfPlayer)
        {
            targetdir = playerawareness.DirectionToPlayer;
        }
    }
    private void RotateTowardsTarget()
    {
        Quaternion targetrotation = Quaternion.LookRotation(transform.forward,targetdir);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation,targetrotation,rotationspeed*Time.deltaTime);
        rb.SetRotation(rotation);
    }
    private void SetVelocity()
    {
        
        
            rb.velocity = transform.up * speed;
        
    }
    private void HandleObstacles()
    {       obstacleAvoidanceCooldown-=Time.deltaTime;
            var contactfilter = new ContactFilter2D();
            contactfilter.SetLayerMask(obstaclelayermask);
            int nofcollision =Physics2D.CircleCast(transform.position,obstaclecheckcircleradius,transform.up,contactfilter,obstaclecollision,obstacleCheckDistance);
    for(int index =0;index<nofcollision;index++)
    {
        var obstaclecollide=obstaclecollision[index];
        if(obstaclecollide.collider.gameObject==gameObject)
        {
            continue;
        }
        if(obstacleAvoidanceCooldown<=0)
        {
            obstacleAvoidanceTargetdir=obstaclecollide.normal;
            obstacleAvoidanceCooldown=0.5f;
        }
        var targetrotation=Quaternion.LookRotation(transform.forward,obstacleAvoidanceTargetdir);
        var rotation =Quaternion.RotateTowards(transform.rotation,targetrotation,rotationspeed*Time.deltaTime);
        targetdir=rotation * Vector2.up;
        break;
    }    
    }
void KeepBossInBounds()
{
    Vector3 pos = transform.position;
    float screenLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
    float screenRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
    float screenTop = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
    float screenBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;

    // Clamp position within screen bounds
    pos.x = Mathf.Clamp(pos.x, screenLeft + 2f, screenRight - 2f);
    pos.y = Mathf.Clamp(pos.y, screenBottom + 2f, screenTop - 2f);

    transform.position = pos;
}

private void OnTriggerEnter2D(Collider2D collision)
{
    if(collision.CompareTag("player"))
    {
        healthcontroller healthcontroller=collision.GetComponent<healthcontroller>();
        healthcontroller.takeDamage(100f);
    }
}

}


