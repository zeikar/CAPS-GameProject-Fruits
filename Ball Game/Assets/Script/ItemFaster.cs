using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFaster : item {
    
    public override void Action(Collider obj)
    {
        Fruits.instance.Faster();
    }
}
