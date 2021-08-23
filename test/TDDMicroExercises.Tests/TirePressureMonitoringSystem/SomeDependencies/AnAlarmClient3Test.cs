using TDDMicroExercises.TirePressureMonitoringSystem.SomeDependencies;
using Xunit;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class AnAlarmClient3Test
    {
        [Fact]
        public void ShouldWork()
        {
            var alarmClient = new AnAlarmClient3();
            alarmClient.DoSomething();
            alarmClient.DoSomethingElse();

            Assert.NotNull(alarmClient);
        }
    }
}
