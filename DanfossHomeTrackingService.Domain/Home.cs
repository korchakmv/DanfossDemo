using System.Collections.Generic;
using System.Linq;
using DanfossHomeTrackingService.Core;

namespace DanfossHomeTrackingService.Domain
{
    public class Home
    {
        private readonly List<Sensor> _sensors = new List<Sensor>();

        private Home()
        {
            
        }
        
        public Home(string address)
        {
            Address = address;
        }
        
        public int Id { get; }
        public string Address { get; set; }

        public virtual IReadOnlyCollection<Sensor> Sensors => _sensors;

        public void AddSensor(Sensor sensor)
        {
            if (Sensors.Any(x => x.SensorType == sensor.SensorType))
                throw new DanfossApplicationException($"Home Id:{Id} already contains sensor of type {sensor.SensorType.ToString()}");
            
            _sensors.Add(sensor);
        }
    }
}