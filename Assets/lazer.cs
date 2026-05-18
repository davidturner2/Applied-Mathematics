using UnityEngine;

public class lazer : MonoBehaviour
{
    public float zxf= 999f;
    void OnDrawGizmos()
    {
        Vector3 laserStart = transform.position;
        Vector3 laserDir = transform.forward;

        if(Physics.Raycast(laserStart, laserDir, out RaycastHit hitInfo))
        {
            Vector3 hi = hae(laserStart,laserDir,hitInfo.point,hitInfo.normal);
            if(Physics.Raycast(hitInfo.point, hi, out RaycastHit z))
            {
                // set the distance of lazer to the other hitpoint
                zxf = Vector3.Distance(hitInfo.point,z.point);
                            hae(hitInfo.point,hi,z.point,z.normal);

            }
            else
            {
                // go far otherwise if no hit point
                zxf=999f;
            }
            {
                
            }
            

        }
        else
        {
            //laser when it doesn't hit
            Gizmos.color = Color.white;
            Gizmos.DrawRay(laserStart, laserDir);
        }

    }
    Vector3 hae(Vector3 laserStart, Vector3 laserDir,Vector3 hitPos,Vector3 normmal)
    {
        // draw lazer from start to hitposition
         Gizmos.color=Color.cyan;
            Gizmos.DrawRay(laserStart,laserDir*Vector3.Distance(laserStart,hitPos));
   
            //Gizmos.color=Color.green;
            //Gizmos.DrawRay(hitPos,hitInfo.normal*999f);
   
           // Gizmos.color=Color.magenta;
            //Gizmos.DrawRay(hitPos,Vector3.Cross(normmal,laserDir));
            //Gizmos.color = Color.white;
          //  Gizmos.DrawRay(hitPos,-Vector3.Cross(normmal,Vector3.Cross(normmal,laserDir)));
            // create an orthogonal basis using the normal vector and the cross product
            Vector3 r = Vector3.Normalize(Vector3.Cross(normmal,laserDir));
            Vector3 u = normmal;
            Vector3 f = Vector3.Normalize(-Vector3.Cross(normmal,Vector3.Cross(normmal,laserDir)));
            Gizmos.color = Color.cyan;
            // add the projections of the lazer along the basis but reflect over the normal vector
            // this is the same as multiplying the reflextion matrix by x y z but using a different basis
            Gizmos.DrawRay(hitPos,zxf*(Vector3.Dot(laserDir,r)*r
            -Vector3.Dot(laserDir,u)*u+
            Vector3.Dot(laserDir,f)*f));
           // return the new direction
            return (Vector3.Dot(laserDir,r)*r
            -Vector3.Dot(laserDir,u)*u+
            Vector3.Dot(laserDir,f)*f);

            
    }
}

