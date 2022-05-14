using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public static  WayPoints instance;
   private Transform[] points;

    public  Transform GetFirstWayPoint()
    {
        return points[0];                           
    }
    ///summarry>
    ///���� ����Ʈ �������� �Լ�
    ///</summary>
    ///<param name ="CurrentPointIndex">
    ///<param name ="nextPoint">
    ///<returns> ���� ����Ʈ �������µ� ����: true ���� :false </return>

    public  bool TryGetNextWaypoint(int currentPointIndex, out Transform nextpoint)
    {
        nextpoint = null;

        if (currentPointIndex < points.Length - 1)
            {
            nextpoint=points[currentPointIndex +1];
            return true;
        }       
        return false;
    }    
   
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);                  
        }                                                                                                                                                                                                                                                                                                                   
        instance = this;    
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
            points[i] = transform.GetChild(i);  
    }
}
