using System;

namespace DanfossHomeTrackingService.Core
{
    public class DanfossApplicationException : Exception
    {
        public DanfossApplicationException(string message)
            : base(message)
        {

        }

        public static DanfossApplicationException HomeNotFoundException(int homeId)
        {
            return new DanfossApplicationException($"Home by Id:{homeId} not found");
        }

        public static DanfossApplicationException SensorNotFoundException(string sensorSerialNumber)
        {
            return new DanfossApplicationException($"Sensor by Serial Number:{sensorSerialNumber} not found");
        }
    }
}