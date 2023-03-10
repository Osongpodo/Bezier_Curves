using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject m_missilePrefab;
    public GameObject m_target;

    [Header("미사일 기능 관련")]
    public float m_speed = 2; 
    [Space(10f)]
    public float m_distanceFromStart = 6.0f; // 시작점을 기준으로 얼마나 꺾일지
    public float m_distanceFromEnd = 3.0f; // 도착점을 기준으로 얼마나 꺾일지
    [Space(10f)]
    public int m_shotCount = 12; // 총 몇 개 발사할지
    [Range(0, 1)]
    public float m_interval = 0.15f;
    public int m_shotCountEveryInterval = 2; // 한번에 몇 개씩 발사할지

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(CreateMissile());
        }
    }

    IEnumerator CreateMissile()
    {
        int _shotCount = m_shotCount;
        while(_shotCount > 0)
        {
            for(int i = 0; i<m_shotCountEveryInterval; i++)
            {
                if(_shotCount > 0)
                {
                    GameObject missile = Instantiate(m_missilePrefab);
                    missile.GetComponent<BezierMissile>().Init(this.gameObject.transform, m_target.transform, m_speed, m_distanceFromStart, m_distanceFromEnd);

                    _shotCount--;

                }
            }
            yield return new WaitForSeconds(m_interval);
        }
        yield return null;
    }
}
