using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.SocialPlatforms;

public class CameraController : MonoBehaviour
{
    public Transform RightDownPoint;
    public Transform LeftUpPoint;
    // TRANSFORM
    private float _minSwipeDistation = 35f;
    private float _minSwipeAngel = 15f;
    private float _maxSpeed = 6f;
    private float _distation = 5f;

    public Rigidbody Rigidbody;

    private Vector3 _startPosition;
    private Vector3 _currentVelocity = Vector3.zero;

    //  SCALE CAMERA
    public Camera Camera;
    private float _zoomSpeed = 1f;
    private float _minZoom = 30f;
    private float _maxZoom = 80f;




    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _startPosition = touch.position;
                _currentVelocity = Rigidbody.velocity;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector3 endPos = touch.position;
                Vector3 swipe = endPos - _startPosition;



                float dir = Mathf.Atan2(swipe.y, swipe.x) * Mathf.Rad2Deg;
                Vector3 test;
                if (dir > -_minSwipeAngel && dir <= _minSwipeAngel)
                {
                    test = (gameObject.transform.position.z < LeftUpPoint.position.z)? Vector3.forward : Vector3.zero;
                    //{ test = Vector3.forward; }
                    //else { test = Vector3.zero; }
                }
                else if (dir > _minSwipeAngel && dir <= 180 - _minSwipeAngel)
                {
                    test = (gameObject.transform.position.x > RightDownPoint.position.x)? Vector3.left : Vector3.zero;
                }
                else if (dir > -180 + _minSwipeAngel && dir <= -_minSwipeDistation)
                {
                    test = (gameObject.transform.position.x < LeftUpPoint.position.x)? Vector3.right : Vector3.zero;
                }
                else
                {
                    test = (gameObject.transform.position.z > RightDownPoint.position.z)? Vector3.back : Vector3.zero;
                }
                

                Rigidbody.AddForce(test * _maxSpeed, ForceMode.Impulse);

            }




        }

        else if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            Vector3 touchZero = touch0.position - touch0.deltaPosition;
            Vector3 touchOne = touch1.position - touch1.deltaPosition;

            float magn = (touchZero - touchOne).magnitude;
            float current = (touch0.position - touch1.position).magnitude;

            float diff = magn - current;

            Camera.fieldOfView += diff * _zoomSpeed;
            Camera.fieldOfView = Mathf.Clamp(Camera.fieldOfView, _minZoom, _maxZoom);
        }
        _currentVelocity = Rigidbody.velocity;
        _currentVelocity *= 1f - _distation * Time.deltaTime;
        Rigidbody.velocity = _currentVelocity;
    }
}
