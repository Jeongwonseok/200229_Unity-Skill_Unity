using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // velocity 벡터에는 속도와 그 방향 정보가 담겨져있다!! >> 따라서 날아가는 빨간축은 계속 그 정보를 업데이트하면서 영향을 받게된다!!
        transform.right = GetComponent<Rigidbody2D>().velocity;
    }
}
