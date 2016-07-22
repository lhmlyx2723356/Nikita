using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace Nikita.Core
{
    /// <summary>
    /// 对串口进行操作的类，其中包括写和读操作,可用于串口电子称等读取
    /// </summary>
    public class CommPortHelper
    {
        private readonly SerialPort _serialPort;

        //默认构造函数1，操作COM1，速度为9600，没有奇偶校验，8位字节，停止位为1
        public CommPortHelper()
        {
            _serialPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
            SetSerialPort();
        }

        // 构造函数2
        public CommPortHelper(string comPortName)
        {
            _serialPort = new SerialPort(comPortName);
            SetSerialPort();
        }

        // 构造函数3,可以自定义串口的初始化参数
        // </summary>
        // <param name="comPortName">需要操作的COM口名称</param>
        // <param name="baudRate">COM的速度</param>
        // <param name="parity">奇偶校验位</param>
        // <param name="dataBits">数据长度</param>
        // <param name="stopBits">停止位</param>
        public CommPortHelper(string comPortName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
        {
            _serialPort = new SerialPort(comPortName, baudRate, parity, dataBits, stopBits);
            SetSerialPort();
        }

        //定义委托
        public delegate void SerialPortDataReceiveEventArgs(object sender, SerialDataReceivedEventArgs e, byte[] bits);

        //定义接收数据事件
        public event SerialPortDataReceiveEventArgs DataReceived;

        // 把字节型转换成十六进制字符串
        public static string ByteToString(byte[] inBytes)
        {
            string stringOut = "";
            foreach (byte inByte in inBytes)
            {
                stringOut = stringOut + String.Format("{0:X2} ", inByte);
            }
            return stringOut;
        }

        // 把十六进制字符串转换成字节型
        public static byte[] StringToByte(string inString)
        {
            var byteStrings = inString.Split(" ".ToCharArray());
            var byteOut = new byte[byteStrings.Length - 1];
            for (int i = 0; i == byteStrings.Length - 1; i++)
            {
                byteOut[i] = Convert.ToByte(("0x" + byteStrings[i]));
            }
            return byteOut;
        }

        // 关闭串口资源,操作完成后,一定要关闭串口
        public void ClosePort()
        {
            //如果串口处于打开状态,则关闭
            if (_serialPort.IsOpen)
                _serialPort.Close();
        }

        // 获得当前电脑上的所有串口资源
        public string[] GetSerials()
        {
            return SerialPort.GetPortNames();
        }

        public void WriteData(string dataStr)
        {
            //发送数据,并加加车符
            _serialPort.Write(dataStr + "\r");
        }

        // 接收串口数据事件
        private void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (DataReceived != null)
            {
                byte[] data = new byte[_serialPort.BytesToRead];
                _serialPort.Read(data, 0, data.Length);
                DataReceived(sender, e, data);
            }
        }

        // 接收数据出错事件
        private void _serialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
        }

        //打开串口资源
        private void OpenPort()
        {
            //如果串口是打开的，先关闭
            if (_serialPort.IsOpen)
                _serialPort.Close();
            //打开串口
            _serialPort.Open();
        }

        // 设置串口资源,还需重载多个设置串口的函数
        private void SetSerialPort()
        {
            if (_serialPort != null)
            {
                //设置触发DataReceived事件的字节数为1
                _serialPort.ReceivedBytesThreshold = 1;
                //接收到一个字节时，也会触发DataReceived事件
                _serialPort.DataReceived += _serialPort_DataReceived;
                //接收数据出错,触发事件
                _serialPort.ErrorReceived += _serialPort_ErrorReceived;
                //打开串口
                OpenPort();
            }
        }
    }
}