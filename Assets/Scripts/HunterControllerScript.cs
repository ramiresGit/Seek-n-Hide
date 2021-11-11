using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterControllerScript : MonoBehaviour
{
    [SerializeField] private GameObject hunterPrefab;
    private GameObject _hunter;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Object[] allObjects = FindObjectsOfType(typeof(GameObject));
        foreach (Object obj in allObjects)
        {   
            
            if (obj.name == "Hunter")
            {
                i++;
               
            }
                
        }
        if (i < 10)
        {
            _hunter = Instantiate(hunterPrefab);
            _hunter.transform.position = new Vector3(0, 1, 0);
            float angle = Random.Range(0, 360);
            _hunter.transform.Rotate(0, angle, 0);
        }

    }
}
