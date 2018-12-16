using System;

namespace Common
{
    public abstract class IBaseInterface : IDisposable
    {
        // NOTE: Leave out the finalizer altogether if this class doesn't
        // own unmanaged resources, but leave the other methods
        // exactly as they are.
        ~IBaseInterface()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {

        }
        /// <summary>
        /// Calls the default dispose method on a object
        /// </summary>
        /// <param name="item">Item to dispose.</param>
        public void DisposeItem<TItem>(ref TItem item) {
            if(item != null) {
                var method = item.GetType().GetMethod("Dispose");
                if (method.IsNotNull()) {
                    method.Invoke(item, null);
                    item = default(TItem);
                }
            }
        }
    }
}
