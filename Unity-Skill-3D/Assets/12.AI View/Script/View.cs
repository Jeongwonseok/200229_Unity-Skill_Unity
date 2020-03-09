using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour
{
    // AI 시야각 , 시야 거리 , 플레이어 레이어 마스크 선언
    [SerializeField] float m_angle = 0f;
    [SerializeField] float m_distance = 0f;
    [SerializeField] LayerMask m_layerMask = 0;

    // 시야 체크 함수
    void Sight()
    {
        // 주변에 있는 플레이어 콜라이더 검출
        Collider[] t_cols = Physics.OverlapSphere(transform.position, m_distance, m_layerMask);

        if(t_cols.Length > 0)
        {
            Transform t_tfPlayer = t_cols[0].transform;

            // 플레이어가 어느 방향에 있는지 구함
            Vector3 t_direction = (t_tfPlayer.position - transform.position).normalized;

            // AI의 방향 & 플레이어 방향의 각도차이가 시야각보다 작은지 확인
            float t_angle = Vector3.Angle(t_direction, transform.forward);

            // 시야각 * 0.5f인 이유 >> 정면기준 (왼쪽시야 + 오른쪽 시야) = (전체시야) 이므로!!
            if (t_angle < m_angle * 0.5f)
            {
                // 시야각 안에 있다면 Ray를 플레이어에 쏨 >> 적과 플레이어 사이에 뭐가 있는지 검출
                if (Physics.Raycast(transform.forward, t_direction, out RaycastHit t_hit, m_distance))
                {
                    // 플레이어가 검출되면 장애물이 없는것으로 간주!!
                    if(t_hit.transform.name == "Player")
                    {
                        transform.position = Vector3.Lerp(transform.position, t_hit.transform.position, 0.02f);
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Sight();
    }
}
