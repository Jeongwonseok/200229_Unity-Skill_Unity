using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent m_enemy = null;

    // 정찰 위치들을 담을 배열 선언
    [SerializeField] Transform[] m_tfWayPoints = null;
    int m_count = 0;

    Transform m_target = null;

    // 위험 감지 : 기존 순찰 취소 -> 타겟 지정
    public void SetTarget(Transform p_target)
    {
        CancelInvoke();
        m_target = p_target;
    }

    // 위험 감지 해제 : 타겟 취소 -> 순찰 실행
    public void RemoveTarget()
    {
        m_target = null;
        InvokeRepeating("MoveToNextWayPoint", 0f, 2f);
    }

    // 다음 정찰하기 함수
    void MoveToNextWayPoint()
    {
        if(m_target == null)
        {
            // AI 속도가 0이 되면
            if (m_enemy.velocity == Vector3.zero)
            {
                m_enemy.SetDestination(m_tfWayPoints[m_count++].position);

                if (m_count >= m_tfWayPoints.Length)
                    m_count = 0;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        m_enemy = GetComponent<NavMeshAgent>();
        InvokeRepeating("MoveToNextWayPoint", 0f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if(m_target != null)
        {
            m_enemy.SetDestination(m_target.position);
        }
    }
}
