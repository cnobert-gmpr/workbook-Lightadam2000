using System.Collections;
using UnityEngine;

namespace Assignment_2
{


    public class CollisionDiabled : MonoBehaviour
    {
        private SpriteRenderer _sprite;
        private BoxCollider2D _collider2D;
    

    private void Awake()
    {
            _collider2D = GetComponent<BoxCollider2D>();
            _sprite = GetComponent<SpriteRenderer>();
            _sprite.color = Color.red;
    }//End of Awake

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _sprite.color = Color.white;
            _collider2D.enabled = false;

            StartCoroutine(ReActivate());
        }

        IEnumerator ReActivate()
        {
            yield return new WaitForSeconds(5);
            _sprite.color = Color.red; 
            _collider2D.enabled = true;
        }

    }//End of collision
}//End of Namespace