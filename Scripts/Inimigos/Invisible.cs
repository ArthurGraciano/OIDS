using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisible : Enemy {

    public Renderer rend;
    public float startTime;

	// Use this for initialization
	void Start ()
    {
        Speed = 0.5f;
        points = 40;
        LifePoints = 3;
        rend = GetComponent<Renderer>();
        Sprite.color = Color.blue;
        rend.enabled = true;
        startTime = Time.time;

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        bool oddeven = Mathf.FloorToInt(startTime - Time.time)% 2 == 0;
        rend.enabled = oddeven;
       
    }

    
}
