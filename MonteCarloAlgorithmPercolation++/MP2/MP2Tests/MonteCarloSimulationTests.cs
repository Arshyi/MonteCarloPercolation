using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class MonteCarloSimulationTests
    {
        [TestMethod]
        public void Estimate_ProbabilityZero()
        {
            double result = MonteCarloSimulation.Estimate(5, 0.0, 10);
            Assert.AreEqual(0.0, result);
        }

        [TestMethod]
        public void Estimate_ProbabilityOne()
        {
            double result = MonteCarloSimulation.Estimate(5, 1.0, 10);
            Assert.AreEqual(1.0, result);
        }

        [TestMethod]
        public void Estimate_GuaranteedPercolation()
        {
            double result = MonteCarloSimulation.Estimate(1, 1.0, 10);
            Assert.AreEqual(1.0, result);
        }

        [TestMethod]
        public void Estimate_BetweenZeroAndONe()
        {
            double result = MonteCarloSimulation.Estimate(5, 0.5, 20);
            Assert.IsTrue(result >= 0.0 && result <= 1.0);
        }

        [TestMethod]

        public void Estimate_DimensionLessThanOrEqualToZero()
        {
            double result = MonteCarloSimulation.Estimate(0, 0.5, 10);
            Assert.AreEqual(0.0, result);
        }

        [TestMethod]
        public void Estimate_NegativeProbability()
        {
            double result = MonteCarloSimulation.Estimate(5, -0.2, 10);
            Assert.AreEqual(0.0, result);
        }

        [TestMethod]

        public void Estimate_GreaterThanOne()
        {
            double result = MonteCarloSimulation.Estimate(5, 1.2, 10);
            Assert.AreEqual(0.0, result);
        }

        [TestMethod]
        public void Estimate_TrialsLessThanOrEqualToZero()
        {
            double result = MonteCarloSimulation.Estimate(5, 0.5, 0);
            Assert.AreEqual(0.0, result);
        }

    }
}