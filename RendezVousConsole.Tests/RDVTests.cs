using RendezVousConsole;
using System;
using System.IO;
using Xunit;

namespace RendezVousConsole.Tests
{
    public class RDVTests
    {
        [Fact]
        public void Print_ShouldOutputCorrectFormat()
        {
            // Arrange
            var rdv = new RDV { DateTime = new DateTime(2025, 10, 15, 14, 0, 0), Duration = 30 };
            using var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            rdv.Print();

            // Assert
            var expected = $"{rdv.DateTime} {rdv.Duration}{Environment.NewLine}";
            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        public void OverLap_ShouldReturnTrue_WhenDateTimesAreEqual()
        {
            var dt = new DateTime(2025, 10, 15, 14, 0, 0);
            var rdv1 = new RDV { DateTime = dt, Duration = 30 };
            var rdv2 = new RDV { DateTime = dt, Duration = 45 };

            Assert.True(rdv1.OverLap(rdv2));
        }

        [Fact]
        public void OverLap_ShouldReturnTrue_WhenIntervalsOverlap()
        {
            var rdv1 = new RDV { DateTime = new DateTime(2025, 10, 15, 14, 0, 0), Duration = 60 };
            var rdv2 = new RDV { DateTime = new DateTime(2025, 10, 15, 14, 30, 0), Duration = 30 };

            Assert.True(rdv1.OverLap(rdv2));
        }

        [Fact]
        public void OverLap_ShouldReturnFalse_WhenIntervalsDoNotOverlap()
        {
            var rdv1 = new RDV { DateTime = new DateTime(2025, 10, 15, 14, 0, 0), Duration = 30 };
            var rdv2 = new RDV { DateTime = new DateTime(2025, 10, 15, 15, 0, 0), Duration = 30 };

            Assert.False(rdv1.OverLap(rdv2));
        }
    }
}
