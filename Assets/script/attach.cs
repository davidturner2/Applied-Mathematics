using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attach : MonoBehaviour
{
    // Start is called before the first frame update


   private void OnTriggerEnter (Collider other){
            other.transform.SetParent(gameObject.transform);
            //other.transform.rotation = gameObject.transform.rotation;
            //other.gameObject.GetComponent<movement>().stopdetecting = true;

   }

   //once object is on here then disable all movement and move to the objects vector 3 rotate towards?

      private void OnTriggerExit (Collider other){
            other.transform.SetParent(null);
           // other.gameObject.GetComponent<movement>().stopdetecting = false;
           // other.transform.rotation = l;


   }
}
