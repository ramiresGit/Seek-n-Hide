using UnityEngine;

public class PetScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginDropAnim(Vector3 startPosition)
    {
        transform.position = startPosition;
        GetComponent<Animator>().SetTrigger("OnDrop");

        Debug.Log("Begin animation");
    }

}
