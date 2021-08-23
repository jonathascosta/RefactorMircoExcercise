using System.Diagnostics.CodeAnalysis;

namespace TDDMicroExercises.TirePressureMonitoringSystem.SomeDependencies
{
    public class ASensorClient      
    {
        // A class with the only goal of simulating a dependency on Sensor
        // that has impact on the refactoring.

        [SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = DependencyJustification.Legacy)]
        public ASensorClient()
        {
            Sensor sensor = new Sensor();

			double value = sensor.PopNextPressurePsiValue();
			value = sensor.PopNextPressurePsiValue();
			value = sensor.PopNextPressurePsiValue();
			value = sensor.PopNextPressurePsiValue();
		}
    }
}
