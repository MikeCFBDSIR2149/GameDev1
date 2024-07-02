using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;    //相机追随目标
    public float xSpeed = 200;  //X轴方向拖动速度
    public float ySpeed = 200;  //Y轴方向拖动速度
    public float mSpeed = 10;   //放大缩小速度
    public float yMinLimit = -50; //在Y轴最小移动范围
    public float yMaxLimit = 50; //在Y轴最大移动范围
    public float distance = 10;  //相机视角距离
    public float minDistance = 2; //相机视角最小距离
    public float maxDistance = 30; //相机视角最大距离
    public float x;
    public float y;
    public float damping = 5.0f;
    public bool needDamping = true;

    private Transform thisTransform;

    private void Awake()
    {
        thisTransform = transform;
        var angle = thisTransform.eulerAngles;
        x = angle.y;
        y = angle.x;
    }

    
    private void LateUpdate() //处理相机部分
    {
        if (!target) 
            return;
        if (Input.GetMouseButton(1))
        {
            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
            y = ClamAngle(y, yMinLimit, yMaxLimit);

        }
        distance -= Input.GetAxis("Mouse ScrollWheel") * mSpeed;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);
        var rotation = Quaternion.Euler(y, x, 0.0f);
        var disVector = new Vector3(0.0f, 0.0f, -distance);
        var position = rotation * disVector + target.position;

        if (needDamping)
        {
            thisTransform.rotation = Quaternion.Lerp(thisTransform.rotation, rotation, Time.deltaTime * damping);
            thisTransform.position = Vector3.Lerp(thisTransform.position, position, Time.deltaTime * damping);
        }
        else
        {
            thisTransform.rotation = rotation;
            thisTransform.position = position;
        }
        
        thisTransform.LookAt(target);
    }

    private static float ClamAngle(float angle, float min, float max)
    {
        if (angle < -360)
        {
            angle += 360;
        }
        if (angle > 360)
        {
            angle -= 360;
        }
        return Mathf.Clamp(angle, min, max);
    }
}
