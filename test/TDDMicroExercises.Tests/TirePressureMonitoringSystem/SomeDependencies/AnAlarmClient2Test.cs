using TDDMicroExercises.TirePressureMonitoringSystem.SomeDependencies;
using Xunit;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class AnAlarmClient2Test
    {
        [Fact]
        public void ShouldWork()
        {
            var alarmClient = new AnAlarmClient2();

            Assert.NotNull(alarmClient);
        }
    }
}
