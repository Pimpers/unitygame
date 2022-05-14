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
        //타겟 위치에 도착했는지 체크
        if (Vector3.Distance(tr.position, targetPos) < posTolerance)
        {
            //다음 타켓 포인트를 받아옴
            if (WayPoints.instance.TryGetNextWaypoint(currentPointIndex,out nextWaypoint))
                {
                currentPointIndex++;
                tr.LookAt(nextWaypoint);
            }                   
            //종점도착
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

