using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    // 배경을 담을 변수 선언
    [SerializeField] Transform[] m_tfBackgrounds = null;

    // 스크롤 속도 변수 선언
    [SerializeField] float m_speed = 0f;

    // 카메라 왼쪽 너머의 X 좌표 선언
    float m_leftPosX = 0f;

    // 다시 등장시킬 X 좌표 선언
    float m_rightPosX = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // 배경의 이미지 가로 사이즈 저장 변수
        float t_length = m_tfBackgrounds[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        // (마이너스) 이미지 길이만큼 벗어나면 사라지게!
        m_leftPosX = -t_length;
        // 이미지 길이 * 갯수 = 총 배경의 길이
        m_rightPosX = t_length * m_tfBackgrounds.Length;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<m_tfBackgrounds.Length; i++)
        {
            m_tfBackgrounds[i].position += new Vector3(m_speed, 0, 0) * Time.deltaTime;

            // 배경이 왼쪽 너머로 사라지면 오른쪽 너머로 다시 등장시킴
            if(m_tfBackgrounds[i].position.x < m_leftPosX)
            {
                Vector3 t_selfPos = m_tfBackgrounds[i].position;
                t_selfPos.Set(t_selfPos.x + m_rightPosX, t_selfPos.y, t_selfPos.z);
                m_tfBackgrounds[i].position = t_selfPos;
            }
        }
    }
}
