using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class PercolationTests
    {
        //Infiltrate tests
        [TestMethod()]
        public void InfiltrateTest_StraightPath()
        {
            bool[,] grid = new bool[,]
            {
                { true, true, true },
                { true, true, true },
                { true, true, true }
            };

            bool[,] expected = new bool[,]
            {
                { true, true, true },
                { true, true, true },
                { true, true, true }
            };

            bool[,] actual = Percolation.Infiltrate(grid);

            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void InfiltrateTest_Diagnal()
        {
            bool[,] grid = new bool[,]
            {
                { true, false },
                { false, true }
            };

            bool[,] expected = new bool[,]
            {
                { true, false },
                { false, false }
            };

            bool[,] actual = Percolation.Infiltrate(grid);

            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void InfiltrateTest_SidetoSide()
        {
            bool[,] grid = new bool[,]
            {
                { true,  false, false },
                { true,  true,  false },
                { false, true,  true  }
            };

            bool[,] expected = new bool[,]
            {
                { true,  false, false },
                { true,  true,  false },
                { false, true,  true }
            };

            bool[,] actual = Percolation.Infiltrate(grid);

            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void InfiltrateTest_NoOpenTopCells()
        {
            bool[,] grid = new bool[,]
            {
                { false, false },
                { true,  true }
            };

            bool[,] expected = new bool[,]
            {
                { false, false },
                { false, false }
            };

            bool[,] actual = Percolation.Infiltrate(grid);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InfiltrateTest_UpwardConnectivity()
        {
            bool[,] grid = new bool[,]
            {
                { true,  false, false, false },
                { true,  false, true,  false },
                { true,  true,  true,  false },
                { false, false, true,  false }
            };


            bool[,] expected = new bool[,]
            {
                { true,  false, false, false },
                { true,  false, true,  false },
                { true,  true,  true,  false },
                { false, false, true,  false }
            };

            bool[,] actual = Percolation.Infiltrate(grid);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InfiltrateTest_EmptyGrid()
        {
        
            bool[,] grid = new bool[0, 0];
            bool[,] expected = new bool[0, 0];
            bool[,] actual = Percolation.Infiltrate(grid);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InfiltrateTest_SingleCellOpen()
        {
          
            bool[,] grid = new bool[,] { { true } };
            bool[,] expected = new bool[,] { { true } };
            bool[,] actual = Percolation.Infiltrate(grid);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InfiltrateTest_SingleCellBlocked()
        {
        
            bool[,] grid = new bool[,] { { false } };
            bool[,] expected = new bool[,] { { false } };
            bool[,] actual = Percolation.Infiltrate(grid);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InfiltrateTest_AllBlocked()
        {
        
            bool[,] grid = new bool[,]
            {
                { false, false },
                { false, false }
            };

            bool[,] expected = new bool[,]
            {
                { false, false },
                { false, false }
            };

            bool[,] actual = Percolation.Infiltrate(grid);
            CollectionAssert.AreEqual(expected, actual);
        }

        //Percolating tests

        [TestMethod]
        public void IsPercolating_StraightPath()
        {
            bool[,] grid = new bool[,]
            {
                { true, true, true },
                { true, true, true },
                { true, true, true }
            };

            Assert.IsTrue(Percolation.IsPercolating(grid));
        }

        [TestMethod]
        public void IsPercolating_AllBlocked()
        {
            bool[,] grid = new bool[,]
            {
                { false, false },
                { false, false }
            };

            Assert.IsFalse(Percolation.IsPercolating(grid));
        }

        [TestMethod]
        public void IsPercolating_SidetoSide()
        {
            bool[,] grid = new bool[,]
            {
            { true,  false, false },
            { true,  true,  false },
            { false, true,  true  }
            };

            Assert.IsTrue(Percolation.IsPercolating(grid));
        }

        [TestMethod]
        public void IsPercolating_NoOpening()
        {
            bool[,] grid = new bool[,]
            {
                { false, false, false },
                { false, true,  false },
                { false, true,  false }
            };

            Assert.IsFalse(Percolation.IsPercolating(grid));
        }

        [TestMethod]
        public void IsPercolating_SingleOpenCell()
        {
            bool[,] grid = new bool[,]
            {
                { true }
            };

            Assert.IsTrue(Percolation.IsPercolating(grid));
        }

        [TestMethod]
        public void IsPercolating_SingleBlockedCell()
        {
            bool[,] grid = new bool[,]
            {
                { false }
            };

            Assert.IsFalse(Percolation.IsPercolating(grid));
        }
        [TestMethod]

        public void IsPercolating_BottomOpen()
        {
            bool[,] grid = new bool[,]
            {
            { false, false, false },
            { false, false, false },
            { true,  true,  true  }
            };

            Assert.IsFalse(Percolation.IsPercolating(grid));
        }

        [TestMethod]
        public void IsPercolating_EmptyGrid()
        {
            bool[,] grid = new bool[0, 0];
            Assert.IsFalse(Percolation.IsPercolating(grid));
        }

        [TestMethod]
        public void IsPercolating_IsolatedTopRow()
        {
 
            bool[,] grid = new bool[,]
            {
                { true,  true,  true },
                { false, false, false },
                { true,  true,  true }
            };
            Assert.IsFalse(Percolation.IsPercolating(grid));
        }




    }
}