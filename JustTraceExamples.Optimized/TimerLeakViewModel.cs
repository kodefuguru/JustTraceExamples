namespace JustTraceExamples
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using System.Windows.Input;

    
    public class TimerLeakViewModel : ViewModel
    {
        private string displayTime;
        private readonly Timer timer;

        public TimerLeakViewModel()
        {
            this.timer = new Timer
            {
                Interval = 1000
            };
            ChangeTimeDisplay(null, null);
            this.timer.Tick += ChangeTimeDisplay;
            timer.Start();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            timer.Stop();
        }
  
        private void ChangeTimeDisplay(object o, EventArgs e)
        {
            this.DisplayTime = DateTime.Now.ToString();
        }

        public string DisplayTime
        {
            get
            {
                return this.displayTime;
            }
            set
            {
                this.displayTime = value;
                RaisePropertyChanged();
            }
        }
    }
}
