using System.Collections;
using System.Diagnostics.Tracing;
using UnityEngine;

namespace Assignment_2
{


    public class TargetManager : MonoBehaviour
    {
        public static TargetManager Instance;
        public DropTargetGroup[] allTargets;
        private int counter = 0;
        private void Awake() => Instance = this;

        public void ObjectsHit() 
        {
            counter++;
            if(counter >= 3)
            {
                StartCoroutine(ResetAllTargets());
            }
        }

        IEnumerator ResetAllTargets()
        {
            yield return new WaitForSeconds(3);

            foreach (DropTargetGroup target in allTargets)
            {
                target.Activate();

            }

            counter = 0;
        }
    }  //End of Class
}