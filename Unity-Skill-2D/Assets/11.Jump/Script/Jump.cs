using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    // 점프 세기 변수 , 점프 가능 횟수 변수
    [SerializeField] float m_jumpForce = 0f;
    [SerializeField] int m_maxJumpCount = 0;
    int m_jumpCount = 0;

    Rigidbody2D m_rigid = null;

    float m_distance = 0f;
    [SerializeField] LayerMask m_layerMask = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_rigid = GetComponent<Rigidbody2D>();

        // Collider y축 절반 크기 = 플레이어 발밑
        m_distance = GetComponent<BoxCollider2D>().bounds.extents.y + 0.05f;
    }

    // 점프 시도 함수
    void TryJump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(m_jumpCount < m_maxJumpCount)
            {
                m_jumpCount++;
                m_rigid.velocity = Vector2.up * m_jumpForce;
            }
        }
    }

    // 땅 체크 함수 >> 낙하할 때만 체크(서있을 때는 체크 불필요!!)
    void CheckGround()
    {
        // y축 속도가 0 미만 >> 발 밑에 땅이 있다는 의미 >> 점프 초기화하기
        if(m_rigid.velocity.y < 0)
        {
            RaycastHit2D t_hit = Physics2D.Raycast(transform.position, Vector2.down, m_distance, m_layerMask);

            if(t_hit)
            {
                if(t_hit.transform.CompareTag("Ground"))
                {
                    m_jumpCount = 0;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        TryJump();
        CheckGround();
    }
}
