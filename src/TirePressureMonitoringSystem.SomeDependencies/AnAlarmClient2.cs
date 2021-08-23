using System.Diagnostics.CodeAnalysis;

namespace TDDMicroExercises.TirePressureMonitoringSystem.SomeDependencies
{
    public class AnAlarmClient2
    {
        // A class with the only goal of simulating a dependency on Alert
        // that has impact on the refactoring.

        [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = DependencyJustification.Legacy)]
        [SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = DependencyJustification.Legacy)]
        private void DoSomething()
        {
            Alarm anAlarm = new Alarm();
            anAlarm.Check();
            bool isAlarmOn = anAlarm.AlarmOn;
        }
    }
}
