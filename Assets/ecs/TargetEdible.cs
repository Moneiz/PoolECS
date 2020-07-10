﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TargetEdible : MonoBehaviour
{

    public GameObject player;
    public NavMeshAgent _Navmesh;

    public GameObject ennemy;
    
    public bool isFollow;
    
    public List<GameObject> billes;
    
    public void Start()
    {
        billes.AddRange(GameObject.FindGameObjectsWithTag("bille"));
        isFollow = true;
        Accessor<TargetEdible>.Instance().AddModule(this);

    }

    public void Run(Accessor<EdibleModule> modules)
    {
        _Navmesh.isStopped = false;

        EdibleModule neareast = null;

        if (isFollow)
        {
            foreach (var module in modules.GetAllModules())
            {
                if (!module.edible) continue;
                if (module == null) continue;
                if (neareast == null || Vector3.Distance(transform.position, module.transform.position) <
                    Vector3.Distance(transform.position, neareast.transform.position))
                {
                    neareast = module;
                }
            }

            if (neareast != null)
                _Navmesh.SetDestination(neareast.transform.position);
        }
        else
        {
            _Navmesh.SetDestination(ennemy.transform.position);
        }
    }
}
