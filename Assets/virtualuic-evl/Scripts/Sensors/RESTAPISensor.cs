using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RESTAPISensor : MonoBehaviour
{

    [Serializable]
    public class SensorInfo
    {
        // Sensor Info
        public string time;
        public string c_device;
        public int c_id;
        public string c_location;
        public string c_name;
        public string c_position;
        public string manufactuererid;
        public string manufacturer;
        public string manufacturerid;
        public string product;
        public string productid;
        public string producttype;
        public bool ready;
        public string sensor;
        public string type;
    }

    [Serializable]
    public class SensorState
    {
        // Sensor Info
        public string name;
        public string time;
        public int c_id;
        public string label;

        public string sensor;
        public float value;

        public string units;

        // MultiSensor
        public bool isMultiSensor = false;
        public Dictionary<string, SensorState> multiSensor;
    }

    [Serializable]
    public class RoomStatus
    {
        public Dictionary<string, SensorState> sensors;
    }

    [SerializeField]
    protected string url = "https://iot.evl.uic.edu:4000/api/";

    [Header("APISensor")]
    [SerializeField]
    protected string sensorName = "";

    protected string dataType = "events";

    protected SensorInfo sensorInfo;
    protected SensorState sensorLastState;

    [SerializeField]
    bool updateOverTime = true;

    [SerializeField]
    float updateInterval = 5;

    [SerializeField]
    public bool debug;

    public enum DeviceType { Sensor, Display };
    DeviceType deviceType = DeviceType.Sensor;

    // Use this for initialization
    void Start()
    {
        GetInfo();
    }

    protected void GetInfo(DeviceType deviceType = DeviceType.Sensor)
    {
        this.deviceType = deviceType;
        StartCoroutine("GetInfoCR", url);
    }

    protected void GetLastState(string dataType = "events")
    {
        this.dataType = dataType;
        StartCoroutine("GetLastStateCR", url);
    }

    IEnumerator GetInfoCR(string url)
    {
        string deviceTypeString = "/sensors/";
        switch(deviceType)
        {
            case (DeviceType.Display): deviceTypeString = "displays/"; break;
            default: deviceTypeString = "/sensors/"; break;
        }

        if (debug)
            Debug.Log(url + deviceTypeString + sensorName);
        WWW www = new WWW(url + deviceTypeString + sensorName);
        yield return www;
        if (www.error == null)
        {
            sensorInfo = JsonUtility.FromJson<SensorInfo>(www.text);
            if (debug)
            {
                Debug.Log(www.text);
            }
        }
        else
        {
            Debug.Log("ERROR: " + www.error);
        }
    }

    private IEnumerator GetLastStateCR(string url)
    {
        bool runLoop = true;
        while (runLoop)
        {
            if (debug)
                Debug.Log(url + "/" + dataType + "/" + sensorName + "/last");
            WWW www = new WWW(url + "/"+ dataType + "/" + sensorName + "/last");
            yield return www;
            if (www.error == null)
            {
                sensorLastState = JsonUtility.FromJson<SensorState>(www.text);

                if (debug)
                {
                    Debug.Log(www.text);
                }
            }
            else
            {
                Debug.Log("ERROR: " + www.error);
            }
            if (updateOverTime)
            {
                yield return new WaitForSeconds(updateInterval);
            }
            else
            {
                runLoop = false;
            }
        }
    }

    public static string GMTToLocalTime(string time)
    {
        string[] timeArr = time.Split(':');
        int hours = 0;
        int minutes = 0;
        int seconds = 0;

        int.TryParse(timeArr[0], out hours);
        int.TryParse(timeArr[1], out minutes);
        int.TryParse(timeArr[2], out seconds);

        // hours += 1; // DST
        hours -= 6; // GMT -> CT
        if (hours < 0)
        {
            hours = 24 + hours;
        }
        return hours.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2");
    }
}
