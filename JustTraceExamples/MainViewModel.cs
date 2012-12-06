namespace JustTraceExamples
{
    using System;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows.Input;

    public class MainViewModel : ViewModel
    {
        private readonly ObservableCollection<Event> events = new ObservableCollection<Event>();
        private bool busy;
        private string timeText;
        private Stopwatch stopwatch = new Stopwatch();

        public MainViewModel()
        {
            this.LoadEventsCommand = new DelegateCommand(LoadEvents, () => !this.busy);
            this.ShowTimeCommand = new DelegateCommand(() => { }, () => !this.busy);
            this.TimeText = "Press Load Events...";
        }

        public ObservableCollection<Event> Events
        {
            get { return this.events; }
        }

        public void LoadEvents()
        {
            this.Busy = true;
            try
            {
                var dictionary = new EventParser().CountEvents("reallybigfile.xml");

                this.events.Clear();

                foreach (var kvp in dictionary)
                {
                    this.events.Add(new Event(kvp.Key, kvp.Value));
                }
            }
            finally
            {
                this.Busy = false;
            }
        }

        public bool Busy
        {
            get { return this.busy; }
            set
            {
                if (this.busy != value)
                {
                    if (this.busy = value)
                    {
                        stopwatch.Reset();
                        stopwatch.Start();
                        TimeText = "Please Wait...";
                    }
                    else
                    {
                        stopwatch.Stop();
                        TimeText = String.Format("Loading Time: {0:n0} ms", stopwatch.ElapsedMilliseconds);
                    }
                    this.RaisePropertyChanged();
                }
            }
        }

        public string TimeText
        {
            get { return this.timeText; }
            set
            {
                this.timeText = value;
                this.RaisePropertyChanged();
            }
        }

        public ICommand LoadEventsCommand { get; set; }
        public ICommand ShowTimeCommand { get; set; }
    }
}