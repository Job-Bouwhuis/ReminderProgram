using SnowLibrary.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderProgram.Data;

public class UserTask
{
    public string taskName;
    public string taskDescription;
    public DateTime startDate;
    public DateTime endDate;
    public int priority;
    public bool Expiring = false;


    [ExcludeFromSerialization]
    public UserTaskNotificationControl NototificationControl = new(0, 0, 0);

    public UserTask(string taskName, string taskDescription, DateTime startDate, DateTime endDate, int priority)
    {
        this.taskName = taskName;
        this.taskDescription = taskDescription;
        this.startDate = startDate;
        this.endDate = endDate;
        this.priority = priority;
    }
    public UserTask()
    {
        taskName = "";
        taskDescription = "";
        startDate = new();
        endDate = new();
        priority = 0;
    }
}



public class UserTaskNotificationControl
{
    public int min60Notifications = 0;
    public int min30Notifications = 0;
    public int min10Notifications = 0;

    public int hour2Notifications = 0;
    public int hour8Notifications = 0;
    public int hour24Notifications = 0;
    public int hour48Notifications = 0;

    public UserTaskNotificationControl(int min60, int min30, int min10)
    {
        min60Notifications = min60;
        min30Notifications = min30;
        min10Notifications = min10;
    }
    public UserTaskNotificationControl() { }
}

