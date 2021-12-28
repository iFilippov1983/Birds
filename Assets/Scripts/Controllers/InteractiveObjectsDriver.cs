using UnityEngine;

namespace Birds
{
    public class InteractiveObjectsDriver
    {
        private float _xPosition;
        private float _yPosition;
        private HitObjectProperties _properties;

        public void DriveHitObject(HitObject hitObject)
        {
            hitObject.gameObject.SetActive(true);

            _properties = hitObject.Properties;
            var maxSpeed = _properties.MaxSpeed;
            var minSpeed = _properties.MinSpeed;

            var speed = Random.Range(minSpeed, maxSpeed);
            bool left = hitObject.gameObject.GetComponent<SpriteRenderer>().flipX;

            //temp
            Debug.Log(left);

            if (left) speed *= -1;

            var rb = hitObject.gameObject.GetComponent<Rigidbody2D>();
            rb.AddForce(hitObject.transform.position * speed);
        }

        public void StopHitObject(HitObject hitObject)
        {
            hitObject.gameObject.SetActive(false);
            hitObject.transform.position = Vector2.zero;
            hitObject.transform.localScale = Vector3.one;
            hitObject.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        public void DriveBonus(Bonus bonus)
        {
            bonus.gameObject.SetActive(true);
            bonus.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        }

        public void StopBonus(Bonus bonus)
        {
            bonus.gameObject.SetActive(false);
            bonus.transform.localScale = Vector3.one;
            var rb = bonus.gameObject.GetComponent<Rigidbody2D>();
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
        }
    }
}
