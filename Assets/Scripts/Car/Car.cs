using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CarChassis))]
public class Car : MonoBehaviour
{
    

    [SerializeField] private AudioSource boxSound;

    [SerializeField] private float maxStreetAngle;
    [SerializeField] private float maxBrakeTorque;

    [Header("Engine")]
    [SerializeField] private AnimationCurve engineTorqueCurve;
    [SerializeField] private float engineMaxTorque;
    [SerializeField] private float engineTorque;
    [SerializeField] private float engineRpm;
    [SerializeField] private float engineMinRpm;
    [SerializeField] private float engineMaxRpm;

    [Header("Gearbox")]
    [SerializeField] private float[] gears;
    [SerializeField] private float finalDriveRatio;

    [SerializeField] private int selectedGearIndex;
    [SerializeField] private float selectedGear;
    [SerializeField] private float rearGear;


    [SerializeField] private float upShiftEngineRpm;
    [SerializeField] private float downShiftEngineRpm;


    [SerializeField] private int maxSpeed;

    public float ThrottleControl;
    public float SteerControl;
    public float BrakeControl;

    private bool CheckBox;

    public int SelectedGearIndex => selectedGearIndex;
    public float EngineRPM => engineRpm;
    public float EngineMaxRPM => engineMaxRpm;

    public float LinearVelocity => chassis.LinearVelocity;
    public float NormalizeLinearVelocity => chassis.LinearVelocity / maxSpeed;
    public float WheelSpeed => chassis.GetWheelSpeed();
    public int MaxSpeed => maxSpeed;

    [SerializeField] private float linearVelocity;

    private CarChassis chassis;
    public Rigidbody Rigidbody => chassis == null? GetComponent<CarChassis>().Rigidbody : chassis.Rigidbody;

    private void Start()
    {
        chassis = GetComponent<CarChassis>();
    }

    private void Update()
    {
        linearVelocity = LinearVelocity;

        UpdateEngineTorque();
        AutoGearShift();

        if (LinearVelocity >= maxSpeed)
        {
            engineTorque = 0;
        }

        chassis.MotorTorque = engineTorque * ThrottleControl;
        chassis.SteerAngel = maxStreetAngle * SteerControl;
        chassis.BreakTorque = maxBrakeTorque * BrakeControl;
    }

    // GearBox

    private void AutoGearShift()
    {
        if (engineRpm >= upShiftEngineRpm)
        {
            if(engineTorque > 0)
            {
                UpGear();
            }

            //UpGear(); !!!!!!!!!!
        }

        if (engineRpm <= downShiftEngineRpm)
        {
            if (selectedGearIndex == 0) return;
            
            DownGear();
        }
    }

    public void UpGear()
    {
        ShifGear(selectedGearIndex + 1);
        if (boxSound != null)
        {
            boxSound.Stop();
            boxSound.Play();
            CheckBox = false;
        }
    }

    public void DownGear()
    {
        ShifGear(selectedGearIndex - 1);
        if (boxSound != null)
        {
            boxSound.Stop();
            boxSound.Play();
            CheckBox = false;
        }
    }

    public void ShiftToReverseGear()
    {
        if (boxSound != null)
        {
            boxSound.Stop();
            boxSound.Play();
            CheckBox = false;
        }
        CheckBox = true;
        selectedGear = rearGear;
    }

    public void ShiftToFirstGear()
    {
        
        if (boxSound != null && CheckBox == true)
        {
            boxSound.Stop();
            boxSound.Play();
            CheckBox = false;
        }
        ShifGear(0);
    }

    public void ShiftToNetral()
    {
        selectedGear = 0;
    }


    private void ShifGear(int gearIndex)
    {
        gearIndex = Mathf.Clamp(gearIndex, 0, gears.Length - 1);
        selectedGear = gears[gearIndex];
        selectedGearIndex = gearIndex;
    }

    private void UpdateEngineTorque()
    {
        engineRpm = engineMinRpm + Mathf.Abs(chassis.GetAverageRpm() * selectedGear * finalDriveRatio);
        engineRpm = Mathf.Clamp(engineRpm, engineMinRpm, engineMaxRpm);

        engineTorque = engineTorqueCurve.Evaluate(engineRpm / engineMaxRpm) * engineMaxTorque * finalDriveRatio * Mathf.Sign(selectedGear) * gears[0];
    }

    public void Reset()
    {
        chassis.Reset();
        chassis.MotorTorque = 0;
        chassis.BreakTorque = 0;
        chassis.SteerAngel = 0;

        ThrottleControl = 0;
        BrakeControl = 0;
        SteerControl = 0;
    }

    public void Respawn(Vector3 position,Quaternion rotation)
    {
        Reset();

        transform.position = position;
        transform.rotation = rotation;
    }

}
