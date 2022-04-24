using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherDiskRange : MonoBehaviour
{
    [SerializeField]
    private Collider rangeDamageTrigger;

    // Start is called before the first frame update
    void Start()
    {
        rangeDamageTrigger.enabled = true;
        Object.Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<HealthController>()) {
            other.GetComponent<HealthController>().GetDamage(10);
        }
    }
}
