using System.Collections;
using System.Collections.Generic;
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

    }
}
