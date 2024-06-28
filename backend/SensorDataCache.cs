using System.Collections.Concurrent;
using System.Collections.Generic;
// using iJerkPro.Models;
public class SensorDataCache{
    private readonly ConcurrentBag<JerkModel> _sensorDataList;

    public SensorDataCache()
    {
        this._sensorDataList = new ConcurrentBag<JerkModel>();
    }

    public void AddSensorData(JerkModel data){
        _sensorDataList.Add(data);
    }

    public IEnumerable<JerkModel> GetAllSensorData(){
        return _sensorDataList;
    }
}