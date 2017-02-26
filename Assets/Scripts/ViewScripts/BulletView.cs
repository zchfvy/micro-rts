using UnityEngine;
using Entitas.Unity;

public class BulletView : MonoBehaviour {

    private float? _speed;
    private Vector2 _targetPos;
    private float _destroyBy;

    public float TargetLerpRate = 0.8f;
    public float SpeedLerpRate = 0.2f;

    void Start() {
        var bullet = gameObject.GetEntityLink().entity as BulletEntity;
        _destroyBy = Time.time + bullet.timeToHit.value;
        UpdateEntitas();
    }

    void Update() {
        if (Time.time > _destroyBy) {
            gameObject.Unlink();
            Destroy(gameObject);
            return;
        }
        if (_targetPos != null && _speed.HasValue) {
            var vecTotarget = (new Vector3(_targetPos.x, _targetPos.y) - transform.position).normalized;
            transform.position += vecTotarget * _speed.Value * Time.deltaTime;
        }
    }

    void FixedUpdate() {
        UpdateEntitas();
    }

    void UpdateEntitas() {
        var link = gameObject.GetEntityLink();

        var myBullet = link.entity as BulletEntity;

        if (myBullet != null) {
            if (myBullet.hasTarget && myBullet.target.value != null && myBullet.target.value.hasPosition) {

                // Modify our target position to track smoothly
                if (_targetPos != null) {
                    _targetPos = Vector2.Lerp(_targetPos, myBullet.target.value.position.value, TargetLerpRate);
                } else {
                    _targetPos = myBullet.target.value.position.value;
                }

                float distance = Vector2.Distance(transform.position, myBullet.target.value.position.value);
                if (myBullet.hasTimeToHit) {
                    // Moderate speed to get there at the right time
                    float expectedSpeed = Mathf.Clamp(distance / myBullet.timeToHit.value, 0f, 10000f);
                    if (_speed.HasValue) {
                        _speed = Mathf.Lerp(_speed.Value, expectedSpeed, SpeedLerpRate);
                    } else {
                        _speed = expectedSpeed;
                    }

                } else {
                    // Get there in one game frame!
                    float expectedSpeed = distance / Time.fixedDeltaTime;
                    _speed = expectedSpeed;
                    // Set this too!
                    _targetPos = myBullet.target.value.position.value;
                }
            }
        }
    }
}
