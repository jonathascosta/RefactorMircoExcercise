using System;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Alarm
    {
        private const double LowPressureThreshold = 17;
        private const double HighPressureThreshold = 21;

        private readonly ISensor _sensor;
        private readonly double _lowPressureThreshold;
        private readonly double _highPressureThreshold;

        public bool AlarmOn { get; private set; }

        public Alarm() : this(new Sensor(), LowPressureThreshold, HighPressureThreshold) { }

        public Alarm(
            ISensor sensor,
            double lowPressureThreshold = LowPressureThreshold,
            double highPressureThreshold = HighPressureThreshold)
        {
            _sensor = sensor ?? throw new ArgumentNullException(nameof(sensor));

            if (lowPressureThreshold > highPressureThreshold)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(lowPressureThreshold),
                    $"'{nameof(lowPressureThreshold)}' cannot be higher than '{nameof(highPressureThreshold)}'.");
            }

            _lowPressureThreshold = lowPressureThreshold;
            _highPressureThreshold = highPressureThreshold;
        }

        public void Check()
        {
            double psiPressureValue = _sensor.PopNextPressurePsiValue();

            if (psiPressureValue < _lowPressureThreshold || psiPressureValue > _highPressureThreshold)
            {
                AlarmOn = true;
            }
        }
    }
}
