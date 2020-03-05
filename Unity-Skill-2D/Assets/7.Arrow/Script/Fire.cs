using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    // 화살 프리펩 , 활 트랜스폼 변수
    [SerializeField] GameObject m_goPrefab = null;
    [SerializeField] Transform m_tfArrow = null;

    Camera m_cam = null;

    // Start is called before the first frame update
    void Start()
    {
        m_cam = Camera.main;
    }

    // 화살이 마우스 보는 함수
    void LookAtMouse()
    {
        // 스크린상의 마우스 좌표 -> 게임상의 2D좌표로 치환
        Vector2 t_mousePos = m_cam.ScreenToWorldPoint(Input.mousePosition);
        // 활 좌표 - 월드 상의 마우스 좌표 = 바라볼 방향
        Vector2 t_direction = new Vector2(t_mousePos.x - m_tfArrow.position.x, t_mousePos.y - m_tfArrow.position.y);

        // 활의 빤간색 x축(Right)을 바라볼 방향으로 설정 >> 월드 공간에서 트랜스폼의 빨간색 축을 바뀐 방향으로 설정하기!!
        m_tfArrow.right = t_direction;
    }

    // 발사 함수
    void TryFire()
    {
        if(Input.GetMouseButtonDown(0))
        {
            // 활 위치에서 화살 프리펩 생성
            GameObject t_arrow = Instantiate(m_goPrefab, m_tfArrow.position, m_tfArrow.rotation);
            // 날아가는 속력을 강제로 Right(X축) * 10으로!!
            t_arrow.GetComponent<Rigidbody2D>().velocity = t_arrow.transform.right * 10f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        LookAtMouse();
        TryFire();
    }
}