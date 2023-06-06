using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Control.AI
{
    public class Path : MonoBehaviour
    {
        const float waypointGizmoRadius = 0.3f;
    
        
        private void OnDrawGizmos() 
        {
           for (int i = 0; i < transform.childCount; i++)
            {
                int j = GetNextIndex(i);
                Gizmos.DrawSphere(GetWaypoint(i), waypointGizmoRadius);
                Gizmos.DrawLine(GetWaypoint(i), GetWaypoint(j));
            }
        }

        public Vector3[] GetPath()
        {
            Vector3[] path = new Vector3[transform.childCount];
            for (int i = 0; i < path.Length; i++)
            {
                path[i] = GetWaypoint(i);
            }
            return path;
        }

        public int GetNextIndex(int i)
        {
            if(i + 1 == transform.childCount)
            {
                return i;
            } 
            return i + 1;
        }

        public Vector3 GetWaypoint(int i)
        {
            return transform.GetChild(i).position;
        }

        public string Name
        {
            get { return Name; }
            set { Name = value;}
        }
    }
}
