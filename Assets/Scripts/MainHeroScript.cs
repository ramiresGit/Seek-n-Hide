using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class MainHeroScript : MonoBehaviour
{
    #region Приватные поля

    /// <summary>
    /// Поле компонента контроллера
    /// </summary>
    private CharacterController controller;

    /// <summary>
    /// Префаб питомца
    /// </summary>
    [SerializeField]
    private GameObject petPrefab;

    /// <summary>
    /// Скорость перемещения игрока
    /// </summary>
    public float speed = 6.0f;

    /// <summary>
    /// Сила гравитации
    /// </summary>
    public float gravity = -9.8f;

    /// <summary>
    /// Флаг того, что питомец выпущен
    /// </summary>
    private bool isPetInUse = false;

    /// <summary>
    /// Аниматор питомца
    /// </summary>
    private Animator petAnimator;

    #endregion

    private void Start()
    {
        //получаем компонент CharacterController
        controller = gameObject.GetComponent<CharacterController>();
        petAnimator = petPrefab.GetComponent<Animator>();
    }

    void Update()
    {
        //Горизонтальная (A-D) и вертикальная (W-S) ось 
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
