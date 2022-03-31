using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestDrawing
{
    [TestClass()]
    public class UnitTest1
    {
        const string RECTANGLE = "Rectangle";
        const string ELLIPSE = "Ellipse";
        const string LINE = "Line";
        const string CLEAR = "Clear";
        const string CANVAS = "_canvas";
        const int FOUR = 4;
        private Robot _robot;
        private const string APP_NAME = "D:/Mydata/視窗程式設計/Drawing/DrawingForm/bin/Debug/DrawingForm.exe";
        private const string START_UP_FORM = "Draw";

        // init
        [TestInitialize]
        public void Initialize()
        {
            //var projectName = "HTMLParser";
            //string solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "D:\\Mydata\\視窗程式設計\\_homeWork - 複製\\"));
            //targetAppPath = Path.Combine(solutionPath, projectName, "bin", "Debug", "_homeWork.exe");
            _robot = new Robot(APP_NAME, START_UP_FORM);

        }

        //關閉
        [TestCleanup()]

        public void CleanUp()
        {
            _robot.CleanUp();
        }

        //test
        private void function()
        {
            _robot.Sleep(1);
            _robot.ClickButton(RECTANGLE);
            _robot.DragAndDrop(CANVAS, -10, 100, 50, 50);
            _robot.Click();
            //_robot.Sleep(5);
            _robot.AssertText("_position", "Select : Rectangle(50,133,90,173)");
            _robot.ClickButton(ELLIPSE);
            _robot.DragAndDrop(CANVAS, -10, 100, 50, 50);
            _robot.Click();
            //_robot.Sleep(5);
            _robot.AssertText("_position", "Select : Ellipse(272,133,312,173)");
        }

        //test
        private void function1()
        {
            _robot.Sleep(1);
            _robot.ClickButton(RECTANGLE);
            _robot.DragAndDrop(CANVAS, -10, 100, 50, 50);
            _robot.Click();
            //_robot.Sleep(5);
            _robot.AssertText("_position", "Select : Rectangle(50,133,90,173)");
            _robot.DragAndDrop(CANVAS, 0, 0, 100, 100);
            _robot.Click();
            _robot.AssertText("_position", "Select : Rectangle(130,213,170,253)");
            _robot.Sleep(1);
            _robot.ClickButton(ELLIPSE);
        }

        //測試
        [TestMethod()]

        public void TestFirst()
        {
            function();
            _robot.ClickButton(LINE);
            _robot.DragAndDrop(CANVAS, -100, 110, 250, 0);
            //_robot.Sleep(2);
            _robot.ClickButton(CLEAR);
        }
        
        //測試
        [TestMethod()]

        public void TestSecond()
        {
            function1();
            _robot.DragAndDrop(CANVAS, -10, 100, 50, 50);
            _robot.Click();
            //_robot.Sleep(5);
            _robot.AssertText("_position", "Select : Ellipse(272,133,312,173)");
            _robot.DragAndDrop(CANVAS, 0, 0, 100, 100);
            _robot.Click();
            _robot.AssertText("_position", "Select : Ellipse(352,213,392,253)");
        }

        //測試
        [TestMethod()]

        public void TestThree()
        {
            function1();
            _robot.DragAndDrop(CANVAS, -10, 100, 50, 50);
            _robot.Click();
            //_robot.Sleep(5);
            _robot.AssertText("_position", "Select : Ellipse(272,133,312,173)");
            _robot.DragAndDrop(CANVAS, 0, 0, 100, 100);
            _robot.Click();
            _robot.AssertText("_position", "Select : Ellipse(352,213,392,253)");
            _robot.ClickButton(LINE);
            _robot.DragAndDrop(CANVAS, 0, 210, 250, 0);
            for (int i = 0; i < FOUR; i++)
                _robot.ClickRedoUndo("Undo");
            for (int i = 0; i < FOUR; i++)
                _robot.ClickRedoUndo("Redo");
        }

        //測試
        [TestMethod()]

        public void TestFour()
        {
            _robot.Sleep(3);
            _robot.ClickButton(ELLIPSE);
            _robot.DragAndDrop(CANVAS, -270, 100, 500, 250);
            _robot.ClickButton(RECTANGLE);
            _robot.DragAndDrop(CANVAS, 180, 150, 50, 50);
            _robot.ClickButton(RECTANGLE);
            _robot.DragAndDrop(CANVAS, 280, 150, 50, 50);
            _robot.ClickButton(RECTANGLE);
            _robot.DragAndDrop(CANVAS, 230, 300, 50, 50);
            _robot.ClickButton(RECTANGLE);
            _robot.DragAndDrop(CANVAS, 600, 100, 50, 50);
            _robot.Click();
            _robot.DragAndDrop(CANVAS, 0, 0, -100, 50);
            _robot.ClickRedoUndo("Undo");
            _robot.ClickButton(LINE);
            _robot.DragAndDrop(CANVAS, 500, 110, -170, 50);
            _robot.ClickRedoUndo("Undo");
            _robot.ClickRedoUndo("Redo");
            _robot.ClickButton("Save");
            _robot.SwitchTo("Check");
            _robot.Sleep(1);
            _robot.ClickButton("Yes");
            _robot.Sleep(1);
            _robot.ClickButton("Clear");
            _robot.ClickButton("Load");
            _robot.Sleep(1);
            _robot.ClickButton("Yes");
            _robot.Sleep(1);
        }
    }
}
