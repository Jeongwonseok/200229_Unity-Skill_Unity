using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] Transform m_tfGunBody = null;
    [SerializeField] float m_range = 0f; // 사정거리
    [SerializeField] LayerMask m_layerMask = 0; // 특정 레이어를 가진 대상 검출
    [SerializeField] float m_spinSpeed = 0f; // 적 발견시 회전 속도
    [SerializeField] float m_fireRate = 0f; // 연사속도 변수
    float m_currentFireRate; // 실제 연산에 쓸 연사속도 변수

    [SerializeField] Transform m_fire1 = null;
    [SerializeField] Transform m_fire2 = null;

    [SerializeField] GameObject prefab_Bullet = null;


    // 공격할 적의 트랜스폼
    Transform m_tfTarget = null;

    void SearchEnemy()
    {
        // OverlapSphere -> 객체 주변의 Collider 검출
        Collider[] t_cols = Physics.OverlapSphere(transform.position, m_range, m_layerMask);
        Transform t_shortestTarget = null; // 가장 사정거리 짧은 대상

        if(t_cols.Length > 0)
        {
            // 짧은값을 비교 검출하기위해 가장 긴 길이가 기준!!
            float t_shortestDistance = Mathf.Infinity;

            // SqrMagnitude-> 제곱 반환
            foreach (Collider t_colTarget in t_cols)
            {
                float t_distance = Vector3.SqrMagnitude(transform.position - t_colTarget.transform.position);

                // 거리가 짧으면 짧은 거리값 저장 후 >> 대상 변경
                if (t_shortestDistance > t_distance)
                {
                    t_shortestDistance = t_distance;
                    t_shortestTarget = t_colTarget.transform;
                }
            }
        }

        m_tfTarget = t_shortestTarget; // 여기서 결국 가장 거리 짧은 대상을 집어 넣는다. 
    }
    // Start is called before the first frame update
    void Start()
    {
        m_currentFireRate = m_fireRate;
        // 시작과 동시에 0.5초마다 반복하게하는 함수
        InvokeRepeating("SearchEnemy", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_tfTarget == null)
            m_tfGunBody.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);
        else
        {
            // LookRotation() -> 특정 좌표를 바라보게 만드는 회전값을 리턴
            Quaternion t_lookRotation = Quaternion.LookRotation(m_tfTarget.position);
            // RotateTowards() -> a지점에서 b지점까지 c의 스피드로 회전
            Vector3 t_euler = Quaternion.RotateTowards(m_tfGunBody.rotation, t_lookRotation, m_spinSpeed * Time.deltaTime).eulerAngles;
            // 오일러값에서 y축만 반영되게 수정한뒤 쿼터니온으로 변환
            m_tfGunBody.rotation = Quaternion.Euler(0, t_euler.y, 0);

            // 터렛이 조준해야 될 최종 방향
            Quaternion t_fireRotation = Quaternion.Euler(0, t_lookRotation.eulerAngles.y, 0);
            // 터렛의 방향과 비교
            if (Quaternion.Angle(m_tfGunBody.rotation, t_fireRotation) < 5f)
            {
                // 실제 연사속도가 1씩 작아짐
                m_currentFireRate -= Time.deltaTime;
                if(m_currentFireRate <= 0)
                {
                    m_currentFireRate = m_fireRate; // 리셋

                    Debug.Log("발사!!");

                    Instantiate(prefab_Bullet, m_fire1.position, t_fireRotation);
                    Instantiate(prefab_Bullet, m_fire2.position, t_fireRotation);
                }
            }
        }
    }
}
