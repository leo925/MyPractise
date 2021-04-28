using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExamine
{
    public class DisposableComponent : IDisposable
    {
        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if(disposed)
            {
                return;
            }
            if (disposing)
            {
                //dispose managed resource
            }
            //dispose un-managed resource
            //socek.close()
            //sqlconnection.close()
            disposed = true;

        }

        ~DisposableComponent()
        {
            Dispose(false);
        }
    }


}
