using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    DestroyerE abeja;
    public Manager manager;
    
    public Transform target;
    const float limite = 10f;
    public bool engage = true;
    private int j;

    /*IEnumerator DirChange()
    {
        yield return new WaitForSeconds(5);
        engage = true;
    }*/
	// Use this for initialization
	void Start ()
    {
        manager = FindObjectOfType<Manager>();
        target = Camera.main.transform;
        abeja.DestHealth = 2; 
        abeja.DestSpeed = 0.5f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if((transform.position - target.transform.position).magnitude <= 30 & engage)
        {
            engage = false;
            
            j = Random.Range(0, 9);
            //StartCoroutine(DirChange());
        }
        Trayect();
        LocateTarget();
        MoveForward();
        
    }

    public void Trayect()
    {
        if (engage)
        {
           
            target = Camera.main.transform;
            
        }
        else
        {
            target = manager.orbits[j].transform;
           
            //transform.RotateAround(manager.orbits[j].transform.position, Vector3.forward, swarm.DestSpeed * Time.deltaTime);
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "towBullet")
        {
            abeja.DestHealth--;
            if(abeja.DestHealth == 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void MoveForward()
    {
        transform.Translate(0.0f,0.0f, abeja.DestSpeed * 1);
        if ((transform.position - target.transform.position).magnitude <= 10)
        {
            target = Camera.main.transform;
            engage = true;
        }
    }
   
    private void LocateTarget()
    {
        Vector3 targetPoint = target.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(targetPoint, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5.0f);
    }
    
        
    
}
