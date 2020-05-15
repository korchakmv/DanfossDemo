using System;
using System.Collections.Generic;

namespace DanfossHomeTrackingService.Domain
{
    public class Sensor
    {
        private readonly List<SensorValue> _values = new List<SensorValue>();
        
        private Sensor()
        {
            
        }
        
        public Sensor(string serialNumber, SensorType sensorType, Home home)
        {
            SerialNumber = serialNumber;
            SensorType = sensorType;
            Home = home;
        }
        
        public int Id { get; set; }
        public string SerialNumber { get; }
        public SensorType SensorType { get; }
        
        public int HomeId { get; }
        public virtual Home Home { get; }

        public virtual IReadOnlyCollection<SensorValue> Values => _values;

        public void AddValue(int value)
        {
            var sensorValue = new SensorValue(value, DateTime.Now);
            _values.Add(sensorValue);
        }
    }
}