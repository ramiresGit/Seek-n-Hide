using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAIScript : MonoBehaviour
{
    public float speed = 3.0f;
    public float obstacleRange = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            if (hit.collider.name.Contains(Global.MainHeroName) && hit.distance < 10)
            {
                Debug.Log("Main hero was killed");
            }
            if (hit.distance < obstacleRange)
            {
                if(hit.collider.name == Global.MainHeroName)
                    Debug.Log($"Barycentric coordinate: {hit.barycentricCoordinate}");  
                
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("KABOOOOM");
    }
    
}
