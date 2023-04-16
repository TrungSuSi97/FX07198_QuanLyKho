using System;

namespace TPH.LIS.Common.Barcode
{
    public class BarcodeProperties
    {
        private int _numberOfCopy = 1;
        public bool KSKMode = false;
        public int NumberOfCopy
        {
            get { return _numberOfCopy; }
            set { _numberOfCopy = value; }
        }

        DateTime _dateIn = DateTime.Now;

        public DateTime DateIn
        {
            get { return _dateIn; }
            set { _dateIn = value; }
        }
        private string _barcodeNumber = string.Empty;

        public string BarcodeNumber
        {
            get { return _barcodeNumber; }
            set { _barcodeNumber = value; }
        }
        private string _sid = string.Empty;

        public string Sid
        {
            get { return _sid; }
            set { _sid = value; }
        }
        private string _patientName = string.Empty;

        public string PatientName
        {
            get { return _patientName; }
            set { _patientName = value; }
        }
        private string _departmentID = string.Empty;
        public string DepartmentID
        {
            get { return _departmentID; }
            set { _departmentID = value; }
        }

        private string _sex = string.Empty;

        public string Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }
        private string _age = string.Empty;

        public string Age
        {
            get { return _age; }
            set { _age = value; }
        }
        private string _barcodeLabel = string.Empty;

        public string BarcodeLabel
        {
            get { return _barcodeLabel; }
            set { _barcodeLabel = value; }
        }
        private string _soTT = string.Empty;
        public string SoTT
        {
            get
            {
                return _soTT;
            }

            set
            {
                _soTT = value;
            }
        }
    }
}
