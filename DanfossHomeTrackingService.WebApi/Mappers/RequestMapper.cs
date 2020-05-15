using DanfossHomeTrackingService.Application.Homes;

namespace DanfossHomeTrackingService.WebApi.Mappers
{
    public static class RequestMapper
    {
        public static EditHomeRequest ToApplicationRequest(this Models.EditHomeRequest request, int id)
        {
            return new EditHomeRequest
            {
                Id = id,
                Address = request.Address
            };
        }

        public static AddSensorRequest ToApplicationRequest(this Models.AddSensorRequest request, int id)
        {
            return new AddSensorRequest
            {
                HomeId = id,
                NewSensor = new AddSensorRequest.Sensor
                {
                    SensorType = request.SensorType,
                    SerialNumber = request.SerialNumber
                }
            };
        }

        public static AddSensorValueByHomeRequest ToApplicationRequest(
            this Models.AddSensorValueByHomeRequest request,
            int homeId, string sensorSerialNumber)
        {
            return new AddSensorValueByHomeRequest
            {
                HomeId = homeId,
                SensorSerialNumber = sensorSerialNumber,
                SensorValue = request.Value
            };
        }

        public static AddSensorValueBySensorRequest ToApplicationRequest(
            this Models.AddSensorValueBySensorRequest request,
            string serial)
        {
            return new AddSensorValueBySensorRequest
            {
                Serial = serial,
                Value = request.Value
            };
        }
    }
}