/******************************************************************************************************
 **   
 ** file: AsyncFileStream          
 ** auth: liuweiqian                                                                                  
 ** date: 2018/2/9 13:09:25                                                                                    
 ** desc: 描述                                                                                     
 **                                                                                                  
 ******************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Liuweiqian.IO
{
    public class AsyncFileStream : FileStream
    {
        public AsyncFileStream(string path, FileMode mode, FileAccess access) : base(path, mode, access) { }

        public Task<int> ReadAsync(byte[] buffer, int offset, int count)
        {
            return Task.Factory.FromAsync(
           (targetBuffer, targetOffset, targetCount, callback, state) => ((FileStream)state).BeginRead(targetBuffer, targetOffset, targetCount, callback, state),
           asyncResult => ((FileStream)asyncResult.AsyncState).EndRead(asyncResult),
           buffer, offset, count, state: this);
        }

        public Task WriteAsync(byte[] buffer, int offset, int count)
        {
            return Task.Factory.FromAsync(
               (targetBuffer, targetOffset, targetCount, callback, state) => ((FileStream)state).BeginWrite(targetBuffer, targetOffset, targetCount, callback, state),
               asyncResult => ((FileStream)asyncResult.AsyncState).EndWrite(asyncResult),
               buffer, offset, count, state: this);
        }
    }
}
