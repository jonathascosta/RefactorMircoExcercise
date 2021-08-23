using TDDMicroExercises.TirePressureMonitoringSystem.SomeDependencies;
using Xunit;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class ASensorClientTest
    {
        [Fact]
        public void ShouldWork()
        {
            var sensorClient = new ASensorClient();

            Assert.NotNull(sensorClient);
        }
    }
}
