using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBigger : item {
    
    public override void Action(Collider obj)
    {
        Fruits.instance.Bigger();
    }
}
