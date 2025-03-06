
using System.Security.Principal;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform RightDownPoint;
    public Transform LeftUpPoint;

    public bool canMove = true;
    public float moveSpeed = 1f;
    public float zoomSpeed = 5f;
    public float minZoom = 20f;
    public float maxZoom = 80f;
    public float zoomSmoothTime = 0.1f;
    public Camera cam;

    private Vector3 touchStartPos;
    private float targetZoom;
    private float currentZoomVelocity;

    void Start()
    {
        targetZoom = cam.fieldOfView;
    }

    void Update()
    {
        if (UnitActionsControllerSO.Instance.IsMove) HandleMovement();
        HandleZoom();
        SmoothZoom();
    }

    void HandleMovement()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = GetWorldPosition(touch.position); //��������� �������
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector3 direction = touchStartPos - GetWorldPosition(touch.position); // ����������� ��������
                Vector3 targetPosition = cam.transform.position + direction * moveSpeed; //����� ������� 
                cam.transform.position = Vector3.Lerp(cam.transform.position, targetPosition, Time.deltaTime * 5f); // ������� �����������

                ClampCameraPosition();
            }
        }
    }

    /// <summary>
    /// ������������ ���������� ������ � ������� ����������
    /// </summary>
    /// <param name="screenPosition"></param>
    /// <returns></returns>
    Vector3 GetWorldPosition(Vector2 screenPosition)
    {
        Ray ray = cam.ScreenPointToRay(screenPosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero); // ��������� XZ

        if (groundPlane.Raycast(ray, out float distance))
        {
            return ray.GetPoint(distance);// ���������� ����� �����������
        }

        return Vector3.zero;
    }

    /// <summary>
    /// ����������� �������� ������
    /// </summary>
    void ClampCameraPosition()
    {
        float clampedX = Mathf.Clamp(cam.transform.position.x, RightDownPoint.position.x, LeftUpPoint.position.x);
        float clampedZ = Mathf.Clamp(cam.transform.position.z, RightDownPoint.position.z, LeftUpPoint.position.z);

        cam.transform.position = new Vector3(clampedX, cam.transform.position.y, clampedZ);
    }

    void HandleZoom()
    {
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // ���������� ������� �������
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // ��������� ���������� ����� ��������
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            //�������
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            // ��������� ��������� � ���� � ������������ ��� ��������
            targetZoom = Mathf.Clamp(cam.fieldOfView + deltaMagnitudeDiff * zoomSpeed, minZoom, maxZoom);
        }
    }

    //������� �������� ����
    void SmoothZoom()
    {
        cam.fieldOfView = Mathf.SmoothDamp(cam.fieldOfView, targetZoom, ref currentZoomVelocity, zoomSmoothTime);
    }
}

