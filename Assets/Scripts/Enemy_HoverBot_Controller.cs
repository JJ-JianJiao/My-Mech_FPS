using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_HoverBot_Controller : MonoBehaviour
{
    //[SerializeField]
    private NavMeshAgent meshAgent;
    public bool isPatrol = false;
    public Transform[] points;
    public List<Vector3> pointsPositon;
    private int destPoint = 0;
    [SerializeField]
    private HealthController m_health;
    private bool runDieEvent = false;

    [SerializeField]
    private GameObject die_PS;
    [SerializeField]
    private Transform die_Position;

    [SerializeField]
    private GameObject attackTarget;
    public float detectRadius;

    public float attackRange;

    [SerializeField]
    public GameObject projectilePrefab;
    [SerializeField]
    public Transform bulletMuzzle;
    private float attackStamp;
    public float attackRate;
    public float shootSpeed;

    RaycastHit hit;

    [SerializeField]
    private AudioSource attackAS;

    void Start()
    {
        meshAgent = GetComponent<NavMeshAgent>();
        m_health = GetComponent<HealthController>();
        if (isPatrol)
        {
            meshAgent.autoBraking = false;
            GoToNextPoint();
        }

        for (int i = 0; i < points.Length; i++)
        {
            pointsPositon.Add(points[i].position);
            Destroy(points[i].gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (m_health.IsDie())
        {
            if (runDieEvent == false) {
                runDieEvent = true;
                Die();
            }

            return;
        }

        if (m_health.GetHurt()) {
            detectRadius = 1000;
        }

        if (attackTarget == null)
        {
            FindAttackTarget();

            if (isPatrol)
            {
                if (!meshAgent.pathPending && meshAgent.remainingDistance < 0.5f)
                {
                    GoToNextPoint();
                }
            }
        }
        else {
            //Ray ray = new Ray(bulletMuzzle.position, new Vector3(attackTarget.transform.position.x,bulletMuzzle.position.y, attackTarget.transform.position.z));

            Vector3 attackTargetPostion = new Vector3(attackTarget.transform.position.x, bulletMuzzle.position.y, attackTarget.transform.position.z);
            Vector3 direction = attackTargetPostion - bulletMuzzle.position;
            float rayDistance = Vector3.Distance(attackTargetPostion, bulletMuzzle.position);
            Ray ray = new Ray(bulletMuzzle.position, direction.normalized);
            transform.LookAt(attackTarget.transform);
            meshAgent.destination = attackTarget.transform.position;

            //meshAgent.destination = transform.position;
            //if (!attackTarget.GetComponent<HealthController>().IsDie())
            //{
            //    MakeAttackAction();
            //}

            if (Vector3.Distance(transform.position, attackTarget.transform.position) <= attackRange)
            {
                if (!Physics.Raycast(ray, out hit, rayDistance))
                {

                    meshAgent.destination = transform.position;
                    if (!attackTarget.GetComponent<HealthController>().IsDie())
                    {
                        MakeAttackAction();
                    }

                }
                else {
                    //Debug.Log(hit.transform.name);
                }

            }
        }


    }

    internal bool HasAttackTarget()
    {
        return attackTarget != null;
    }

    private void MakeAttackAction()
    {
        if (Time.time > attackStamp + attackRate) {
            attackAS.Play();
            GameObject bullet = Instantiate(projectilePrefab, bulletMuzzle.position, bulletMuzzle.rotation);
            Rigidbody rb =  bullet.AddComponent<Rigidbody>();
            rb.useGravity = false;
            rb.velocity = transform.forward * shootSpeed;
            attackStamp = Time.time;
        }
    }

    private void FindAttackTarget()
    {
        Collider[] colliders =  Physics.OverlapSphere(die_Position.position, detectRadius);

        foreach (Collider c in colliders)
        {
            if (c.CompareTag("Player")) {
                attackTarget = c.gameObject;
            }
        }
    }

    private void Die()
    {
        ParticleSystem explosionPs = Instantiate(die_PS, die_Position.position, Quaternion.identity).GetComponent<ParticleSystem>();
        
        Destroy(gameObject);
        EnemyMonitorController.instance.DieOneEnemy();
    }

    private void GoToNextPoint()
    {
        if (pointsPositon.Count == 0)
        {
            return;
        }

        meshAgent.destination = pointsPositon[destPoint];

        destPoint = (++destPoint) % pointsPositon.Count;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0, 0, 0.5f);
        Gizmos.DrawSphere(die_Position.position, detectRadius);
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        if(attackTarget != null)
            Gizmos.DrawLine(bulletMuzzle.position, new Vector3(attackTarget.transform.position.x, bulletMuzzle.position.y, attackTarget.transform.position.z));

    }
}
