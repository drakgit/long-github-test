using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Diagnostics;

namespace System.Windows.Forms.Calendar
{
    /// <summary>
    /// Represents a day present on the <see cref="Calendar"/> control's view.
    /// </summary>
    public class CalendarDay
        : CalendarSelectableElement
    {
        #region Static

        private Size overflowSize = new Size(16, 16);
        private Padding overflowPadding = new Padding(5);

        #endregion

        #region Events

        #endregion

        #region Fields
        private List<CalendarItem> _containedItems;
        private Calendar _calendar;
     //   private CalendarDayTop _dayTop;
        private int _index;
        private bool _overflowStart;
        private bool _overflowEnd;
        private bool _overflowStartSelected;
        private bool _overlowEndSelected;
        private CalendarTimeScaleUnit[] _timeUnits;
        private String _lineId;
        private String _lineName;
        //private DateTime _fromDate;
        //private DateTime _toDate;
        #endregion



        #region Ctor

        /// <summary>
        /// Creates a new Day
        /// </summary>
        /// <param name="calendar">Calendar this day belongs to</param>
        /// <param name="date">Date of the day</param>
        /// <param name="index">Index of the day on the current calendar's view</param>
        internal CalendarDay(Calendar calendar, String lineId, int index)
            : base(calendar)
        {
            _containedItems = new List<CalendarItem>();
            _calendar = calendar;
      //      _dayTop = new CalendarDayTop(this);
       //     _date = date;
            _index = index;
            _lineId = lineId;
            //_fromDate = calendar.FromDate;
            //_toDate = calendar.ToDate;

            UpdateUnits();
        }

        #endregion

        #region Properties

        //public DateTime FromDate
        //{
        //    get { return _fromDate; }
        //    set { _fromDate = value; }
        //}

        //public DateTime ToDate
        //{
        //    get { return _toDate; }
        //    set { _toDate = value; }
        //}

        public String LineId
        {
            get { return _lineId; }
            set { _lineId = value; }
        }

        public String LineName
        {
            get { return _lineName; }
            set { _lineName = value; }
        }

        //public override DateTime Date
        //{
        //    get 
        //    {
        //        throw new Exception("Not exist date");
        //        //return _date; 
        //    }
        //}

        /// <summary>
        /// Gets a list of items contained on the day
        /// </summary>
        internal List<CalendarItem> ContainedItems
        {
            get { return _containedItems; }
        }

        /// <summary>
        /// Gets the DayTop of the day, the place where multi-day and all-day items are placed
        /// </summary>
        //public CalendarDayTop DayTop
        //{
        //    get { return _dayTop; }
        //}

        /// <summary>
        /// Gets the bounds of the body of the day (where time-based CalendarItems are placed)
        /// </summary>
        public Rectangle BodyBounds
        {
            get 
            {
                return Rectangle.FromLTRB(Bounds.Left, HeaderBounds.Bottom, Bounds.Right, Bounds.Bottom);
            }
        }

        /// <summary>
        /// Gets the date this day represents
        /// </summary>
        //public override DateTime Date
        //{
        //    get { return _date; }
        //}

        /// <summary>
        /// Gets the bounds of the header of the day
        /// </summary>
        public Rectangle HeaderBounds
        {
            get 
            {
                return new Rectangle(Bounds.Left, Bounds.Top, Bounds.Width, Calendar.Renderer.DayHeaderHeight);
            }
        }

        /// <summary>
        /// Gets the index of this day on the calendar
        /// </summary>
        public int Index
        {
            get { return _index; }
        }

        /// <summary>
        /// Gets a value indicating if the day is specified on the view (See remarks).
        /// </summary>
        /// <remarks>
        /// A day may not be specified on the view, but still present to make up a square calendar.
        /// This days should be drawn in a way that indicates it's necessary but unrequested presence.
        /// </remarks>
        //public bool SpecifiedOnView
        //{
        //    get 
        //    {
        //        return Date.CompareTo(Calendar.ViewStart) >= 0 && Date.CompareTo(Calendar.ViewEnd) <= 0;
        //    }
        //}

        /// <summary>
        /// Gets the time units contained on the day
        /// </summary>
        public CalendarTimeScaleUnit[] TimeUnits
        {
            get { return _timeUnits; }
        }

        /// <summary>
        /// /// <summary>
        /// Gets a value indicating if the day contains items not shown through the start of the day
        /// </summary>
        /// </summary>
        public bool OverflowStart
        {
            get { return _overflowStart; }
        }

        /// <summary>
        /// Gets the bounds of the <see cref="OverflowStart"/> indicator
        /// </summary>
        public virtual Rectangle OverflowStartBounds
        {
            get { return new Rectangle(new Point(Bounds.Right - overflowPadding.Right - overflowSize.Width, Bounds.Top + overflowPadding.Top), overflowSize); }
        }

        /// <summary>
        /// Gets a value indicating if the <see cref="OverflowStart"/> indicator is currently selected
        /// </summary>
        /// <remarks>
        /// This value set to <c>true</c> when user hovers the mouse on the <see cref="OverflowStartBounds"/> area
        /// </remarks>
        public bool OverflowStartSelected
        {
            get { return _overflowStartSelected; }
        }


        /// <summary>
        /// Gets a value indicating if the day contains items not shown through the end of the day
        /// </summary>
        public bool OverflowEnd
        {
            get { return _overflowEnd; }
        }

        /// <summary>
        /// Gets the bounds of the <see cref="OverflowEnd"/> indicator
        /// </summary>
        public virtual Rectangle OverflowEndBounds
        {
            get { return new Rectangle(new Point(Bounds.Right - overflowPadding.Right - overflowSize.Width, Bounds.Bottom - overflowPadding.Bottom - overflowSize.Height), overflowSize); }
        }

        /// <summary>
        /// Gets a value indicating if the <see cref="OverflowEnd"/> indicator is currently selected
        /// </summary>
        /// <remarks>
        /// This value set to <c>true</c> when user hovers the mouse on the <see cref="OverflowStartBounds"/> area
        /// </remarks>
        public bool OverflowEndSelected
        {
            get { return _overlowEndSelected; }
        }


        #endregion

        #region Public Methods

        //public override string ToString()
        //{
        //    return Date.ToShortDateString();
        //}

        #endregion

        #region Private Methods

        /// <summary>
        /// Adds an item to the <see cref="ContainedItems"/> list if not in yet
        /// </summary>
        /// <param name="item"></param>
        internal void AddContainedItem(CalendarItem item)
        {
            if (!ContainedItems.Contains(item))
            {
                ContainedItems.Add(item);
            }
        }

        /// <summary>
        /// Sets the value of he <see cref="OverflowEnd"/> property
        /// </summary>
        /// <param name="overflow">Value of the property</param>
        internal void SetOverflowEnd(bool overflow)
        {
            _overflowEnd = overflow;
        }

        /// <summary>
        /// Sets the value of the <see cref="OverflowEndSelected"/> property
        /// </summary>
        /// <param name="selected">Value to pass to the property</param>
        internal void SetOverflowEndSelected(bool selected)
        {
            _overlowEndSelected= selected;
        }

        /// <summary>
        /// Sets the value of he <see cref="OverflowStart"/> property
        /// </summary>
        /// <param name="overflow">Value of the property</param>
        internal void SetOverflowStart(bool overflow)
        {
            _overflowStart = overflow;
        }

        /// <summary>
        /// Sets the value of the <see cref="OverflowStartSelected"/> property
        /// </summary>
        /// <param name="selected">Value to pass to the property</param>
        internal void SetOverflowStartSelected(bool selected)
        {
            _overflowStartSelected = selected;
        }

        /// <summary>
        /// Updates the value of <see cref="TimeUnits"/> property
        /// </summary>
        internal void UpdateUnits()
        {
            int factor = 0;

            switch (Calendar.TimeScale)
            {
                case CalendarTimeScale.SixtyMinutes:    factor = 1;     break;
                case CalendarTimeScale.ThirtyMinutes:   factor = 2;     break;
                case CalendarTimeScale.FifteenMinutes:  factor = 4;     break;
                case CalendarTimeScale.TenMinutes:      factor = 6;     break;
                case CalendarTimeScale.SixMinutes:      factor = 10;    break;
                case CalendarTimeScale.FiveMinutes:     factor = 12;    break;
                default: throw new NotImplementedException("TimeScale not supported");
            }
            int totalHours = (int)((Calendar.ToDate - Calendar.FromDate).TotalHours + 0.5);

            //Console.WriteLine("Calendar.ToDate=" + Calendar.ToDate + " Calendar.FromDate=" + Calendar.FromDate + " totalHours=" + totalHours);

            _timeUnits = new CalendarTimeScaleUnit[totalHours * factor];
            
            int hourSum = 0;
            int minSum = 0;
            int daySum = 0;

            bool highlighted = false;

            DateTime startDate = Calendar.FromDate.Date;
            for (int i = 0; i < _timeUnits.Length; i++)
            {
                _timeUnits[i] = new CalendarTimeScaleUnit(this, i, startDate.Date, hourSum, minSum);
                _timeUnits[i].SetHighlighted(highlighted);
                //Console.WriteLine("_timeUnits[" + i + "]=" + _timeUnits[i].Highlighted);

                minSum += 60 / factor;

                if (minSum >= 60)
                {
                    minSum = 0;
                    hourSum++;
                }

                if (hourSum >= 24)
                {
                    hourSum = 0;
                    daySum++;
                    startDate = startDate.Date.AddDays(1);
                    highlighted = !highlighted;
                 //   Debug.WriteLine("startTime=" + startDate);
                }

            }

            UpdateHighlights();
        }

        /// <summary>
        /// Updates the highlights of the units
        /// </summary>
        internal void UpdateHighlights()
        {
            if (TimeUnits == null) 
                return;

            //for (int i = 0; i < TimeUnits.Length; i++)
            //{
            //    TimeUnits[i].SetHighlighted(TimeUnits[i].CheckHighlighted());
            //}
        }

        public CalendarTimeScaleUnit FindUnit(DateTime time)
        {
            DateTime newTime = new DateTime(time.Year, time.Month, time.Day, time.Hour, time.Minute, 0);

            foreach (CalendarTimeScaleUnit unit in _timeUnits)
            {
                if (unit.Date.CompareTo(newTime) == 0)
                {
                    return unit;
                }
            }

            return null;
        }

        public void ArrangeItem()
        {
            List<CalendarItem> contains = new List<CalendarItem>();

            for (int i = 0; i < Calendar.Items.Count; i++)
            {
                if (this.LineId == Calendar.Items[i].LineId)
                {
                    contains.Add(Calendar.Items[i]);
                }
            }

            contains.Sort(CalendarRenderer.CompareItems);

            for (int i = 0; i < contains.Count; i++)
            {
                CalendarItem currentItem = contains[i];
                CalendarItem nextItem = i + 1 <= contains.Count - 1 ? contains[i + 1] : null;

                if (nextItem != null)
                {
                    if (nextItem.StartDate.CompareTo(currentItem.EndDate) < 0)
                    {
                        TimeSpan duration = nextItem.Duration;
                        nextItem.StartDate = currentItem.EndDate;
                        nextItem.EndDate = nextItem.StartDate.Add(duration);
                    }
                }
            }
        }

        #endregion
    }
}
