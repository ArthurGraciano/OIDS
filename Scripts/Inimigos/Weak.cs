 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weak : Enemy
{
    void Start()
    {
        Speed = 1.3f;
        points = 10;
        LifePoints = 2;
        Sprite.color = Color.green;
        Sprite.sprite= Resources.Load<Sprite>("enemy");
        weaponRandomizer(2);
       
        if(haveWeapon == true)
        {
            Sprite.color = Color.cyan;
        }

    }
    
}