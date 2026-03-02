using UnityEngine;
using System.Collections;
using System.Diagnostics.Tracing;

namespace Assignment_2
{
    public class DropTargetGroup : MonoBehaviour
    {
        public bool DropTarget = true;
        private SpriteRenderer _sprite;
        private Collider2D _collider;
        private void Awake()
        {
            _sprite = GetComponent<SpriteRenderer>();
            _collider = GetComponent<Collider2D>();
        }
        
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (DropTarget)
            {
                Deactivate();
                TargetManager.Instance.ObjectsHit();
            }
            
           
        }
        public void Deactivate()
        {
            DropTarget = false;
            _sprite.enabled=false;
            _collider.enabled = false;

        }

        public void Activate()
        {
            DropTarget=true;
            _sprite.enabled=true;
            _collider.enabled=true;
        }
    }//End of Class

}//End of namespace