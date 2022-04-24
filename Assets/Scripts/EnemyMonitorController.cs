using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMonitorController : MonoBehaviour
{
    public int totalEnemy;
    public static EnemyMonitorController instance;
    private bool runEndEvent = false;

    [SerializeField]
    private EndGameFlade m_EndGameFlade;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (totalEnemy <= 0) {
            if (!runEndEvent)
            {
                runEndEvent = true;
                m_EndGameFlade.SetEndGameType(1);
            }
        }
    }

    internal void DieOneEnemy()
    {
        totalEnemy--;
    }
}
