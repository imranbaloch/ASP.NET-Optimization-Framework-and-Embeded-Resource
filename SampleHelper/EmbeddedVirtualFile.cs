using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Hosting;

namespace ImranB
{
    public class EmbeddedVirtualFile : VirtualFile
    {
        private Stream _stream;

        public EmbeddedVirtualFile(string virtualPath, Stream stream)
            : base(virtualPath)
        {
            _stream = stream;
        }

        public override Stream Open()
        {
            return _stream;
        }
    } 
}
