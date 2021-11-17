using System.Collections;
using System.Linq;
using UnityEngine;

public class PetScript : MonoBehaviour
{
    public bool IsNeedToMove { get; set; }
    
    [SerializeField]
    private AnimationClip attackingSphereAnim;

    [SerializeField]
    private Material attackingSphereMaterial;

    [SerializeField]
    private GameObject attackingSphereModel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
           
    }
    void FixedUpdate()
    {
        Debug.Log($"Is need to move {IsNeedToMove}");
        if (IsNeedToMove)
        {  
            GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 10f);
        }
           
    }
    public void BeginDropAnim(Vector3 startPosition)
    {
        GetComponent<Animator>().SetTrigger("OnDrop");
        Debug.Log("Begin animation");
    }

    public void BeginAttackingAnim()
    {
        GameObject attackSphere = GameObject.Instantiate(attackingSphereModel);
        attackSphere.gameObject.transform.position = transform.position;
        StartCoroutine(GetNearbyHuntersCourutine(attackSphere));
        
    }

    private IEnumerator GetNearbyHuntersCourutine(GameObject attackSphere)
    {
        yield return new WaitWhile(() => attackSphere.GetComponent<Animation>().IsPlaying("AttackAnimation"));
        Destroy(attackSphere);
    }

}
