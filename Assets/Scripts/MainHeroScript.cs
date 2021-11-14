using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MainHeroScript : MonoBehaviour
{
    #region Приватные поля

    /// <summary>
    /// Поле компонента контроллера
    /// </summary>
    private CharacterController controller;

    /// <summary>
    /// Скорость перемещения игрока
    /// </summary>
    public float speed = 6.0f;

    /// <summary>
    /// Сила гравитации
    /// </summary>
    public float gravity = -9.8f;

    public float visibleRadius = 20f;

    private const string HunterObjName = "OblivionDrone";
    #endregion

    private void Start()
    {
        //получаем компонент CharacterController
        controller = gameObject.GetComponent<CharacterController>();
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

        Collider[] nearby = Physics.OverlapSphere(transform.position, visionRange).Where(collider => collider.name.Contains("testObj")).ToArray();
        List<float> distances = new List<float>();

        if(nearby.Length > 0)
        {
            for (var i = 0; i < nearby.Length; i++)
            {
                float dist = Vector3.Distance(transform.position, nearby[i].transform.position);
                distances.Add(dist);
            };
        }    

        if (distances.Count > 0)
        {
            GameObject.Find("FearStatus").SendMessage("ChangeFearValue", distances.Min()); 
        }
        
            

        /* Ray ray = new Ray(transform.position, transform.forward);
         RaycastHit hit;
         if (Physics.SphereCast(transform.position, 0.95f, transform.forward, out hit))
         {
             Debug.Log(hit.collider.name);
             if (hit.distance < visibleRadius && (hit.collider.name.Contains(HunterObjName) || hit.collider.name.Contains("testObj")))
             {
                 GameObject.Find("FearStatus").SendMessage("ChangeFearValue", hit.distance);
             }
         }*/
    }
}
