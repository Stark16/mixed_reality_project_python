using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Controller : MonoBehaviour
{
    private FloatingJoystick moveJoystick;
    GameObject objMove_Joystick;

    private FloatingJoystick lookJoystick;
    GameObject objLook_Joystick;
    void Update()
    {
        UpdateMoveJoystick();
        UpdateLookJoystick();
    }

    void UpdateMoveJoystick()
    {
        objMove_Joystick = GameObject.FindGameObjectWithTag("Movement_Stick") as GameObject;
        moveJoystick = objMove_Joystick.GetComponent<FloatingJoystick>();
        float hoz = moveJoystick.Horizontal;
        float ver = moveJoystick.Vertical;
        //Vector2 convertedXY = ConvertWithCamera(Camera.main.transform.position, hoz, ver);
        Vector2 convertedXY = ConvertWithCamera(-Camera.main.transform.forward.normalized, hoz, ver);
        Vector3 direction = new Vector3(convertedXY.x, 0, convertedXY.y).normalized;
        transform.Translate(direction * 0.02f, Space.World);
        Vector3 posCamera = new Vector3(Mathf.Abs(Camera.main.transform.position.normalized.x), 0, Mathf.Abs(Camera.main.transform.position.normalized.z));
        Debug.Log("" + Camera.current.transform.position.normalized);
        Debug.Log("Abs Camera" + posCamera);
    }

    void UpdateLookJoystick()
    {
        objLook_Joystick = GameObject.FindGameObjectWithTag("Look_Stick") as GameObject;
        lookJoystick = objLook_Joystick.GetComponent<FloatingJoystick>();
        float hoz = lookJoystick.Horizontal;
        float ver = lookJoystick.Vertical;
        Vector2 convertedXY = ConvertWithCamera(-Camera.main.transform.forward.normalized, hoz, ver);
        Vector3 direction = new Vector3(convertedXY.x, 0, convertedXY.y).normalized;
        Vector3 lookAtPosition = transform.position + direction;
        transform.LookAt(lookAtPosition);
    }

    private Vector2 ConvertWithCamera(Vector3 cameraPos, float hor, float ver)
    {
        Vector2 joyDirection = new Vector2(hor, ver).normalized;
        Vector2 camera2DPos = new Vector2(cameraPos.x, cameraPos.z);
        Vector2 playerPos = new Vector2(transform.position.x, transform.position.z);
        Vector2 cameraToPlayerDirection = (Vector2.zero - camera2DPos).normalized;
        float angle = Vector2.SignedAngle(cameraToPlayerDirection, new Vector2(0, 1));
        Vector2 finalDirection = RotateVector(joyDirection, -angle);
        return finalDirection;
    }

    public Vector2 RotateVector(Vector2 v, float angle)
    {
        float radian = angle * Mathf.Deg2Rad;
        float _x = v.x * Mathf.Cos(radian) - v.y * Mathf.Sin(radian);
        float _y = v.x * Mathf.Sin(radian) + v.y * Mathf.Cos(radian);
        return new Vector2(_x, _y);
    }
}