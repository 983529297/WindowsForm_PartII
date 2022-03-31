﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.Tests
{
    [TestClass()]
    public class EllipseTests
    {
        //test
        [TestMethod()]
        public void SetLeftUpTest()
        {
            Model model = new Model();
            Ellipse circle = new Ellipse(model);
            circle.SetLeftUp(10, 20);
            Assert.AreEqual(10, circle._x1);
            Assert.AreEqual(20, circle._y1);
        }

        //test
        [TestMethod()]
        public void SetRightDownTest()
        {
            Model model = new Model();
            Ellipse circle = new Ellipse(model);
            circle.SetRightDown(20, 10);
            Assert.AreEqual(20, circle._x2);
            Assert.AreEqual(10, circle._y2);
        }

        //test
        [TestMethod()]
        public void CheckContainTest()
        {
            Model model = new Model();
            Ellipse rec = new Ellipse(model);
            rec.SetLeftUp(10, 20);
            rec.SetRightDown(20, 30);

            Assert.AreEqual(true, rec.CheckContain(15, 25));
            Assert.AreEqual(false, rec.CheckContain(50, 50));
        }

        //test
        [TestMethod()]
        public void GetPositionTest()
        {
            Model model = new Model();
            Ellipse rec = new Ellipse(model);
            rec.SetLeftUp(10, 20);
            rec.SetRightDown(20, 30);
            Assert.AreEqual(10, rec.GetPosition()[0]);
            Assert.AreEqual(20, rec.GetPosition()[1]);
            Assert.AreEqual(20, rec.GetPosition()[2]);
            Assert.AreEqual(30, rec.GetPosition()[3]);
        }
    }
}