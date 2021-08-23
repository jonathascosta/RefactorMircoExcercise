using TDDMicroExercises.TirePressureMonitoringSystem.SomeDependencies;
using Xunit;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class AnAlarmClient1Test
    {
        [Fact]
        public void ShouldWork()
        {
            var alarmClient = new AnAlarmClient1();

            Assert.NotNull(alarmClient);
        }
    }
}
