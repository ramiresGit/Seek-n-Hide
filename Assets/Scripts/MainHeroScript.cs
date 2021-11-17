using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class MainHeroScript : MonoBehaviour
{
    #region ��������� ����

    /// <summary>
    /// ���� ���������� �����������
    /// </summary>
    private CharacterController controller;

    /// <summary>
    /// ������ �������
    /// </summary>
    [SerializeField]
    private GameObject petPrefab;

    /// <summary>
    /// �������� ����������� ������
    /// </summary>
    public float speed = 6.0f;

    /// <summary>
    /// ���� ����������
    /// </summary>
    public float gravity = -9.8f;

    /// <summary>
    /// ���� ����, ��� ������� �������
    /// </summary>
    private bool isPetInUse = false;

    /// <summary>
    /// �������� �������
    /// </summary>
    private Animator petAnimator;

    #endregion

    private void Start()
    {
        //�������� ��������� CharacterController
        controller = gameObject.GetComponent<CharacterController>();
        petAnimator = petPrefab.GetComponent<Animator>();
    }

    void Update()
    {
        //�������������� (A-D) � ������������ (W-S) ��� 
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        controller.Move(movement);


        float visionRange = 10;

        Collider[] nearby = Physics.OverlapSphere(transform.position, visionRange).Where(collider => collider.name.Contains(Global.HunterObjName)).ToArray();
        List<float> distances = new List<float>();

        if(nearby.Length > 0)
        {
            for (var i = 0; i < nearby.Length; i++)
            {
                float dist = Vector3.Distance(transform.position, nearby[i].transform.position);
                distances.Add(dist);
            };
        }    
        GameObject.Find("FearStatus").SendMessage("ChangeFearValue", distances.MinOrDefault()); 

        if (Input.GetKeyDown(KeyCode.E) && !isPetInUse)
        {
            StartCoroutine(DropPet());
            //petPrefab.GetComponent<PetScript>().beginDropAnim?.Invoke(transform.position);
        }

    }

   private IEnumerator DropPet()
    {
        GameObject pet = Instantiate(petPrefab, transform.position, transform.rotation );
        
        pet.GetComponent<PetScript>().BeginDropAnim(transform.position);
        yield return new WaitForSeconds(3f);

       

    }

}
