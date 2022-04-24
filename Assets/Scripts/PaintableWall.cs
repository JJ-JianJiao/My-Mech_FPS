using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintableWall : MonoBehaviour
{
    [SerializeField]
    private GameObject destructWallPrefab;
    [SerializeField]
    private HealthController m_health;
    private bool runDieEvent = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_health.IsDie() && !runDieEvent)
        {
            runDieEvent = true;
            GenerateDestructWall();
        }
    }

    private void GenerateDestructWall() {

        GameObject destructWall = Instantiate(destructWallPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    
    }
}
