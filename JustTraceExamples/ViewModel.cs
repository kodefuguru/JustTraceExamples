namespace JustTraceExamples
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows.Threading;

    public class ViewModel : INotifyPropertyChanged, IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); 
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                PropertyChanged = null;
            }
        }

        ~ViewModel()
        {
            Dispose(false);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName]
                                            string caller = "")
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }

        public static void InvokeOnUIThread(Action action)
        {
            Dispatcher currentDispatcher = Dispatcher.CurrentDispatcher;
            if (!currentDispatcher.CheckAccess())
            {
                currentDispatcher.BeginInvoke(action, new object[0]);
            }
            else
            {
                action();
            }
        }
    }
}