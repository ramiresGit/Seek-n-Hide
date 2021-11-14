using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        if (allObjects.Count(obj => obj.name == "OblivionDrone") < 50 && i < 50)
        {
            _hunter = Instantiate(hunterPrefab);
            _hunter.transform.position = new Vector3(GetRandomFloat(-110,170), 1, GetRandomFloat(-20, 170));
            float angle = Random.Range(0, 360);
            _hunter.transform.Rotate(0, angle, 0);
            i++;
        }
    }

    private float GetRandomFloat(float start = 0, float end = 200)
    {
        return Random.Range(start, end);
    }
}
