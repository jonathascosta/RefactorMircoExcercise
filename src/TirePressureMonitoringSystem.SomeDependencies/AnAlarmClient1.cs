using System.Diagnostics.CodeAnalysis;

namespace TDDMicroExercises.TirePressureMonitoringSystem.SomeDependencies
{
    public class AnAlarmClient1
    {
        // A class with the only goal of simulating a dependency on Alert
        // that has impact on the refactoring.

        [SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = DependencyJustification.Legacy)]
        public AnAlarmClient1()
        {
            Alarm anAlarm = new Alarm();
            anAlarm.Check();
            bool isAlarmOn = anAlarm.AlarmOn;
        }
    }
}
