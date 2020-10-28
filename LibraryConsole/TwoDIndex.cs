using System;

namespace LibraryConsole
{
    /// <summary>
    /// This class is to help you to know
    /// </summary>
    public class TwoDIndex
    {
        //Making field to be even use in ref
        public EditColum X;
        public int Y;

        public int MaxEditColum
        {
            get => Enum.GetValues(typeof(EditColum)).Length - 1;
        }
    }
}