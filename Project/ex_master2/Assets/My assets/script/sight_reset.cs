using UnityEngine;
using UnityEngine.SpatialTracking;

public class sight_reset : MonoBehaviour
{
    [SerializeField] GameObject vr_camera;
    [SerializeField] int wait_cnt = 100;
    [SerializeField] float player_height = 2.0f;
    [SerializeField] GameObject[] eventWalls;

    private bool set_flg = true;
    private int count = 0;

    private void Awake()
    {
        foreach (GameObject eventWall in eventWalls)
        {
            eventWall.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //initialization
        count++;
        if (set_flg && count > wait_cnt)
        {
            Reset();
            set_flg = false;
        }
    }

    //視点のリセット
    public void Reset()
    {

        TrackedPoseDriver tpd = vr_camera.GetComponent<TrackedPoseDriver>();
        tpd.trackingType = TrackedPoseDriver.TrackingType.PositionOnly;

        correct_rotation();
        correct_position();

        tpd.trackingType = TrackedPoseDriver.TrackingType.RotationAndPosition;

        Vector3 pos = vr_camera.transform.position;

        foreach (GameObject eventWall in eventWalls)
        {
            eventWall.SetActive(true);
        }

    }

    private void correct_position()
    {
        float pos_x = vr_camera.transform.position.x;
        float pos_y = vr_camera.transform.position.y;
        float pos_z = vr_camera.transform.position.z;

        Vector3 pos = this.transform.position;

        this.transform.position = new Vector3(pos.x - pos_x, pos.y - pos_y + player_height, pos.z - pos_z);
    }

    private void correct_rotation()
    {
        Quaternion rot_vr_Q = vr_camera.transform.localRotation;
        Vector3 rot_vr = rot_vr_Q.eulerAngles;

        rot_vr.x = 0;
        rot_vr.z = 0;
        rot_vr.y = -rot_vr.y;

        this.transform.rotation = Quaternion.Euler(rot_vr);
    }
}
