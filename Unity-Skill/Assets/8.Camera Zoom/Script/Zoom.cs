using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    // 줌 속도 변수 선언
    [SerializeField] float m_zoomSpeed = 0f;

    // 줌 한계 위치값 변수 선언
    [SerializeField] float m_zoomMax = 0f;
    [SerializeField] float m_zoomMin = 0f;

    // 카메라 줌 함수
    void CameraZoom()
    {
        // mac >> 앞으로 굴리면 -1, 뒤로 굴리면 1
        float t_zoomDirection = Input.GetAxis("Mouse ScrollWheel");

        // 휠을 앞으로 굴릴때
        if (transform.position.y <= m_zoomMax && t_zoomDirection > 0)
            return;
        // 휠을 뒤로 굴릴때
        if (transform.position.y >= m_zoomMin && t_zoomDirection < 0)
            return;

        // 카메라 위치 = 카메라 위치 + 정면벡터 * 방향 * 스피드
        transform.position += transform.forward * t_zoomDirection * m_zoomSpeed;
    }

    // 카메라 이동 함수
    void CameraMove()
    {
        // 커서를 오른쪽으로 움직이면 1, 왼쪽으로 움직이면 -1이 리턴됨!!
        if(Input.GetMouseButton(2))
        {
            // 마우스는 상하좌우 y,z
            // 3D 공간은 전후좌우 z,x
            float t_posX = Input.GetAxis("Mouse X");
            float t_posZ = Input.GetAxis("Mouse Y");
            transform.position += new Vector3(t_posX, 0, t_posZ);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CameraZoom();
        CameraMove();
    }
}
