using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovemont : MonoBehaviour
{
    public float moveSpedd = 1f;
    public float posTolerance = 0.1f;
    private Transform tr;
    private int currentPointIndex = 0;
    private Transform nextWaypoint;
    private float originPosY;

    private void Awake()
    {
           tr=GetComponent<Transform>();
        originPosY = tr.position.y;
    }
    private void Start()                        
    {
        nextWaypoint = WayPoints.instance.GetFirstWayPoint();
    }
    private void FixedUpdate()
    {
        Vector3 targetPos = new Vector3(nextWaypoint.position.x, originPosY, nextWaypoint.position.z); ;

        Vector3 dir =(targetPos -tr.position).normalized;
        //Ÿ�� ��ġ�� �����ߴ��� üũ
        if (Vector3.Distance(tr.position, targetPos) < posTolerance)
        {
            //���� Ÿ�� ����Ʈ�� �޾ƿ�
            if (WayPoints.instance.TryGetNextWaypoint(currentPointIndex,out nextWaypoint))
                {
                currentPointIndex++;
                tr.LookAt(nextWaypoint);
            }                   
            //��������
            else
            {
                OnreachedToend();
            }
        }
        tr.Translate(dir*moveSpedd*Time.fixedDeltaTime,Space.World);
    }
    private void OnreachedToend()
    {
        gameObject.SetActive(false);
    }
}

