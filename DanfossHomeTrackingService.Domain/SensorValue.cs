using System;
using DanfossHomeTrackingService.Core;

namespace DanfossHomeTrackingService.Domain
{
    public class SensorValue
    {
        private SensorValue()
        {
        }

        public SensorValue(int value, DateTime date)
        {
            if (value < 0)
                throw new DanfossApplicationException($"Показатель счетчика не может быть отрицательным {value}.");
            
            Value = value;
            Date = date;
        }
        
        public int Id { get; }
        public int Value { get; }

        public DateTime Date { get; }

        public int SensorId { get; set; }
        public virtual Sensor Sensor { get; set; }
    }
}