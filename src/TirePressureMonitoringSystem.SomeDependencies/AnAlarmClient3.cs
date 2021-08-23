using System.Diagnostics.CodeAnalysis;

namespace TDDMicroExercises.TirePressureMonitoringSystem.SomeDependencies
{
    public class AnAlarmClient3
    {
        // A class with the only goal of simulating a dependency on Alert
        // that has impact on the refactoring.

        [SuppressMessage("Style", "IDE0044:Add readonly modifier", Justification = DependencyJustification.Legacy)]
        private Alarm _anAlarm;

        public AnAlarmClient3()
        {
            _anAlarm = new Alarm();
        }

        public void DoSomething() 
        {
			_anAlarm.Check();          
        }

        [SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = DependencyJustification.Legacy)]
        public void DoSomethingElse()
		{
			bool isAlarmOn = _anAlarm.AlarmOn;
		}
    }
}
