using UnityEngine;

public interface IControlMode {
    string controlMode { get; }
    Vector3 GetMoveDirection();
    Vector3 GetAimDirection();
    bool Attack();
    bool Pause();
    bool Continue();
}