using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public SphereCollider sZone;
    public GameObject[] orbits;
    public GameObject orbitPoint;
    GameObject orbitClone;

	// Use this for initialization
	void Start ()
    {
        orbits = new GameObject[10];
        for (int i = 0; i < 10; i++)
        {
            sZone.radius = 100;
            orbitClone = Instantiate(orbitPoint, transform.position, Quaternion.identity);
            float range = Random.Range(sZone.radius - 70, sZone.radius);
            Vector3 orbita = Random.onUnitSphere*range;
            /*orbita.x = Random.Range(-100, 100);
            orbita.y = Random.Range(-100, 100);
            orbita.z = Random.Range(-100, 100);*/
            orbitClone.transform.position = orbita;
            GameObject wayPoint = orbitClone;
            orbits[i] = wayPoint;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
