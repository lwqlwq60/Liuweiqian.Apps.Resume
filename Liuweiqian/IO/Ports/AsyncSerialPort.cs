namespace Liuweiqian.IO.Ports
{
    using System.IO.Ports;
    using System.Threading.Tasks;
    using Liuweiqian.Threading.Tasks;
    /// <summary>
    /// 基于.Net SerialPort高性能异步串口
    /// </summary>
    public class AsyncSerialPort : SerialPort
    {
        public AsyncSerialPort() : base() { }

        public AsyncSerialPort(string portName) : base(portName) { }

        public AsyncSerialPort(string portName, int baudRate) : base(portName, baudRate) { }

        public AsyncSerialPort(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits) : base(portName, baudRate, parity, dataBits, stopBits) { }

        TimeoutTaskCompletionSource trigger;

        private void AsyncSerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (trigger != null)
                trigger.Complete();
        }

        public new void Open()
        {
            this.DataReceived += AsyncSerialPort_DataReceived;
            base.Open();
        }

        public new void Close()
        {
            this.DataReceived -= AsyncSerialPort_DataReceived;
            base.Close();
        }

        public void CancelRead()
        {
            if (trigger != null)
                trigger.Cancel();
        }

        internal Task<int> ReadAsyncInternal(byte[] buffer, int offset, int count)
        {
            return Task.Factory.FromAsync(
                  (targetBuffer, targetOffset, targetCount, callback, state) => ((SerialPort)state).BaseStream.BeginRead(targetBuffer, targetOffset, targetCount, callback, state),
                  asyncResult => ((SerialPort)asyncResult.AsyncState).BaseStream.EndRead(asyncResult),
                  buffer, offset, count, state: this);
        }

        public async Task<int> ReadAsync(byte[] buffer, int offset, int count)
        {
            trigger = new TimeoutTaskCompletionSource(this.ReadTimeout);
            if (this.BytesToRead > 0)
                return await ReadAsyncInternal(buffer, offset, count);
            else
            {
                await trigger.TimeoutTask;
                if (trigger.TimeoutTask.Result)
                    return await ReadAsyncInternal(buffer, offset, count);
                else
                    return 0;
            }
        }

        public Task WriteAsync(byte[] buffer, int offset, int count)
        {
            return Task.Factory.FromAsync(
               (targetBuffer, targetOffset, targetCount, callback, state) => ((SerialPort)state).BaseStream.BeginWrite(targetBuffer, targetOffset, targetCount, callback, state),
               asyncResult => ((SerialPort)asyncResult.AsyncState).BaseStream.EndWrite(asyncResult),
               buffer, offset, count, state: this);
        }
    }
}