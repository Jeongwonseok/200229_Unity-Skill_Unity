using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube2 : MonoBehaviour
{
    // 파편 프리펩을 담을 변수 선언
    [SerializeField] GameObject m_goPrefab = null;

    // 파편이 날아갈 세기를 결정해줄 변수 선언
    [SerializeField] float m_force = 0f;

    // 파편이 날아갈 위치에 영향을 줄 변수 선언
    [SerializeField] Vector3 m_offset = Vector3.zero;

    public void Explosion()
    {
        // 파편 프리펩 생성 -> 자신의 위치로
        GameObject t_clone = Instantiate(m_goPrefab, transform.position, Quaternion.identity);

        // 자식 객체 큐브들의 RigidBody를 배열에 넣음
        Rigidbody[] t_rigids = t_clone.GetComponentsInChildren<Rigidbody>();

        // 모든 큐브들을 날려버림
        for (int i=0; i<t_rigids.Length; i++)
        {
            t_rigids[i].AddExplosionForce(m_force, transform.position + m_offset, 10f);
        }
        gameObject.SetActive(false); // 자기 자신은 비활성화
    }
}
