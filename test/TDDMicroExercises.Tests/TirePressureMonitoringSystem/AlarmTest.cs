using System;
using Moq;
using Xunit;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class AlarmTest
    {
        [Fact]
        public void Constructor_ShouldWork_WithDefaultValues()
        {
            // Arrange and Act
            Alarm alarm = new();

            // Assert
            Assert.NotNull(alarm);
        }

        [Fact]
        public void Constructor_ShouldFail_WithInvalidSensor()
        {
            // Arrange, Act and Assert
            Assert.Throws<ArgumentNullException>(() => new Alarm(null, 10, 15));
        }

        [Fact]
        public void Constructor_ShouldFail_WithInvalidPsiPressureRange()
        {
            // Arrange, Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Alarm(new Sensor(), 15, 10));
        }

        [Theory]
        [InlineData(10, 20, 5, true)]
        [InlineData(10, 20, 10, false)]
        [InlineData(10, 20, 15, false)]
        [InlineData(10, 20, 20, false)]
        [InlineData(10, 20, 25, true)]
        public void Check_ShouldWork(double lowPressureThreshold, double highPressureThreshold, double psiPressureValue, bool alarmOn)
        {
            // Arrange
            Mock<ISensor> sensor = new();
            sensor
                .Setup(x => x.PopNextPressurePsiValue())
                .Returns(psiPressureValue);

            Alarm alarm = new(sensor.Object, lowPressureThreshold, highPressureThreshold);

            // Act
            alarm.Check();

            // Assert
            Assert.Equal(alarmOn, alarm.AlarmOn);
        }

        [Fact]
        public void Check_ShouldWork_AlarmStaysOnAfterPressureOutOfRange()
        {
            // Arrange
            var lowPressureThreshold = 10;
            var highPressureThreshold = 12;
            Mock<ISensor> sensor = new();
            sensor
                .SetupSequence(x => x.PopNextPressurePsiValue())
                .Returns(10)
                .Returns(11)
                .Returns(12)
                .Returns(13) // Out of range
                .Returns(10) // Inside range
                .Returns(11);

            Alarm alarm = new(sensor.Object, lowPressureThreshold, highPressureThreshold);

            // Act and Assert
            alarm.Check(); // 10
            Assert.False(alarm.AlarmOn);
            alarm.Check(); // 11
            Assert.False(alarm.AlarmOn);
            alarm.Check(); // 12
            Assert.False(alarm.AlarmOn);
            alarm.Check(); // 13, out of range, alarm is on
            Assert.True(alarm.AlarmOn);
            alarm.Check(); // 10, back inside the range, but alarm stays on
            Assert.True(alarm.AlarmOn);
            alarm.Check(); // 11, inside the range, but alarm is still on
            Assert.True(alarm.AlarmOn);
        }
    }
}
