using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    // Rigidbody & 표적의 Transform 변수 선언
    Rigidbody m_rigid = null;
    Transform m_tfTarget = null;

    // 미사일 최고속도 & 현재 속도 선언
    [SerializeField] float m_speed = 0f;
    float m_currentSpeed = 0f;

    [SerializeField] LayerMask m_layerMask = 0;
    [SerializeField] ParticleSystem m_psEffect1 = null;
    [SerializeField] ParticleSystem m_psEffect2 = null;

    void SearchEnemy()
    {
        // 반경 100m 내의 특정 레이어 콜라이더들 검출
        Collider[] t_cols = Physics.OverlapSphere(transform.position, 100f, m_layerMask);

        // 검출된 것들 중 하나를 랜덤으로 표적 설정
        if(t_cols.Length > 0)
        {
            m_tfTarget = t_cols[Random.Range(0, t_cols.Length)].transform;
        }
    }

    IEnumerator LaunchDelay()
    {
        // velocity의 y값이 0이하가 될 때까지 대기
        yield return new WaitUntil(() => m_rigid.velocity.y < 0f);
        yield return new WaitForSeconds(0.1f); 

        SearchEnemy();
        m_psEffect1.Play();
        m_psEffect2.Play();

        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        m_rigid = GetComponent<Rigidbody>();
        StartCoroutine(LaunchDelay());
    }

    // Update is called once per frame
    void Update()
    {
        // 표적이 있으면!!
        if(m_tfTarget != null)
        {
            if (m_currentSpeed <= m_speed)
                m_currentSpeed += m_speed * Time.deltaTime;

            transform.position += transform.up * m_currentSpeed * Time.deltaTime;

            // 표적 위치 - 미사일 위치 = 방향과 거리 산출
            Vector3 t_dir = (m_tfTarget.position - transform.position).normalized;
            // y축을 부드럽게 꺾기
            transform.up = Vector3.Lerp(transform.up, t_dir, 0.25f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
