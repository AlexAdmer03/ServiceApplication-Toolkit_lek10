using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ServiceApplication_Toolkit.Services
{
    public class DateTimeService
    {
        private readonly Timer _timer;

        public event Action? TimeUpdated;
        public string? CurrentTime { get; private set; }
        public string? CurrentDate { get; private set; }
        public DateTimeService()
        {
            SetCurrentDateTime();

            _timer = new Timer(1000);
            _timer.Elapsed += (s, e) => SetCurrentDateTime();
        }

        

        private void SetCurrentDateTime()
        {

            CurrentDate = DateTime.Now.ToString("HH:mm:ss");
            CurrentTime = DateTime.Now.ToString("dddd, dd MMMM yyyy");

            TimeUpdated?.Invoke();
        }
    }
}
