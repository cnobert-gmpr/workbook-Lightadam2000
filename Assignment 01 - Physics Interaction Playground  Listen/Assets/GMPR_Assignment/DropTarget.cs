namespace GMPR_Assignment.assignment1
{
    using System.Collections;
    using UnityEditor.SceneManagement;
    using UnityEngine;

    public class DropTarget : MonoBehaviour
    {
        private SpriteRenderer _sprite;
        private Collider2D _collider;

        private void Awake()
        {
            _sprite = GetComponent<SpriteRenderer>();
            _collider = GetComponent<Collider2D>();
        }
        void OnCollisionEnter2D(Collision2D collision)
        {
            StartCoroutine(Respawn());
            
        }
        IEnumerator Respawn()
        {
            _sprite.enabled = false;
            _collider.enabled = false;

            yield return new WaitForSeconds(3);

            _sprite.enabled = true;
            _collider.enabled = true;
        }
    }
}