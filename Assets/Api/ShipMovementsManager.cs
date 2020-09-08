using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovementsManager : MonoBehaviour
{

    Rigidbody _rb;
    Vector3 _networkPosition;
    Quaternion _networkRotation;

    public float AmbientSpeed = 100.0f;
    public float RotationSpeed = 100.0f;


    void Update()
    {
        Quaternion AddRot = Quaternion.identity;
        float roll = 0;
        float pitch = 0;
        float yaw = 0;
        roll = Input.GetAxis("Roll") * (Time.fixedDeltaTime * RotationSpeed);
        pitch = Input.GetAxis("Pitch") * (Time.fixedDeltaTime * RotationSpeed);
        yaw = Input.GetAxis("Yaw") * (Time.fixedDeltaTime * RotationSpeed);
        AddRot.eulerAngles = new Vector3(-pitch, yaw, -roll);
        _rb.rotation *= AddRot;
        Vector3 AddPos = Vector3.forward;
        AddPos = _rb.rotation * AddPos;
        _rb.velocity = AddPos * (Time.fixedDeltaTime * AmbientSpeed);
    }


    void Start()
    {      
        _rb = GetComponent<Rigidbody>();
    }


}
