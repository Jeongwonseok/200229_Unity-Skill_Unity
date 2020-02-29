using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour
{
    public static ObjectPoolingManager instance;

    public GameObject m_goPrefab = null;

    // 객체 저장시킬 큐 생성
    public Queue<GameObject> m_queue = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        for(int i=0; i<500; i++)
        {
            // 객체 생성한 뒤,  풀(큐)에 저장
            GameObject t_object = Instantiate(m_goPrefab, Vector3.zero, Quaternion.identity);
            m_queue.Enqueue(t_object);
            t_object.SetActive(false);
        }
    }

    // 사용한 객체를 풀(큐)에 반납시키는 함수
    public void InsertQueue(GameObject p_object)
    {
        m_queue.Enqueue(p_object);
        p_object.SetActive(false);
    }

    // 풀에서 객체를 빌려오는 함수
    public GameObject GetQueue()
    {
        GameObject t_object = m_queue.Dequeue();
        t_object.SetActive(true);
        return t_object;
    }
}
