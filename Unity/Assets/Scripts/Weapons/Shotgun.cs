using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{

    public Shotgun(string name) : base(name)
    {
    }

    protected override void OnEnemyHit(Enemy enemy)
    {
        PaintPlane(enemy);
    }
}
