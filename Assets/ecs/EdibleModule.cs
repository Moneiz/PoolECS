﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdibleModule : MonoBehaviour
{

    public bool edible;
    
    void Start()
    {
        edible = true;
        Accessor<EdibleModule>.Instance().AddModule(this);
    }
    
    
    
    public void Run()
    {
        
    }
}
