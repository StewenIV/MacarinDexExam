using System.Drawing;
using Buildings.Domain.Models;
using SensorAccounting.App.Interfaces;

namespace SensorAccounting.App.Services;

public class MonitoringService
{
        private readonly IPersonStorage _personStorage;
        private readonly IBuildingStorage _buildingStorage;
        private readonly ISensorStorage _sensorStorage;
        private readonly INotificationStorage _notificationStorage;

        public MonitoringService(IPersonStorage personStorage, IBuildingStorage buildingStorage, ISensorStorage sensorStorage, INotificationStorage notificationStorage)
        {
            _personStorage = personStorage;
            _buildingStorage = buildingStorage;
            _sensorStorage = sensorStorage;
            _notificationStorage = notificationStorage;
        }
        
        public void PurchaseSensors(Guid userId, List<Sensor> sensors)
        {
            foreach (var sensor in sensors)
            {
                sensor.Id = Guid.NewGuid();
                sensor.ChargeLevel = 100;
                sensor.OnLowBattery += message => NotifyLowBattery(sensor.Id, message);
                sensor.OnOutOfRange += message => NotifyOutOfRange(sensor.Id, message);

                _sensorStorage.Add(sensor);
            }
        }
        
        public void RegisterUser(Person user)
        {
            user.Id = Guid.NewGuid();
            _personStorage.Add(user);
        }
        
        public void AddBuilding(Guid userId, Building building)
        {
            building.Id = Guid.NewGuid();
            building.IdPerson = userId;
            _buildingStorage.Add(building);
        }
        
        public void RegisterSensor(Guid buildingId, Sensor sensor)
        {
            sensor.Id = Guid.NewGuid();
            sensor.IdBuilding = buildingId;
            sensor.OnLowBattery += message => NotifyLowBattery(sensor.Id, message);
            sensor.OnOutOfRange += message => NotifyOutOfRange(sensor.Id, message);
            _sensorStorage.Add(sensor);
        }
        
        public void UpdateSensorLocation(Guid sensorId, string? urlPhoto, int x, int y)
        {
            var sensor = _sensorStorage.GetById(sensorId).Result;
            if (sensor != null)
            {
                sensor.UrlPhoto = urlPhoto;
                sensor.Location = new Location(){
                    X = x,
                    Y = y
                };
                _sensorStorage.Update(sensor);
            }
        }
    
        public void UpdateUserInfo(Person user)
        {
            _personStorage.Update(user);
        }
        
        private void NotifyLowBattery(Guid sensorId, string message)
        {
            var notification = new Notification
            {
                IdSensor = sensorId,
                Date = DateTime.UtcNow,
                Message = message
            };
            _notificationStorage.Add(notification);
        }

        private void NotifyOutOfRange(Guid sensorId, string message)
        {
            var notification = new Notification
            {
                IdSensor = sensorId,
                Date = DateTime.UtcNow,
                Message = message
            };
            _notificationStorage.Add(notification);
        }
}